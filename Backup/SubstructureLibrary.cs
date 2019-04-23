using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using System.IO;

namespace SEA
{
    /// <summary>
    /// SubstructureLibrary provides management of a Substructure Library.  It cotains a list of SubstructureEntry objects, representing
    /// the different subsets of structures within the library, and a list of AssayResutlts objects, representing the
    /// different types of assay results to be analyzed against the library.
    /// </summary>
    class SubstructureLibrary
    {
        private string _name;
        private string _filename;
        /// <summary>
        /// substructure entry objects
        /// </summary>
        private ArrayList _arEntries;
        /// <summary>
        /// Keys - Assay result names, keys, AssayResults objects
        /// </summary>
        private Hashtable _hsAssayResults;
        /// <summary>
        /// keys - unique chemical identifiers in this substructure library
        /// </summary>
        private Hashtable _hsChemIds;
        private string _propertyString;

        // filtering objects - if a filter is associated with the substructure library
        // it will have a member Substructure Library filtered object
        private SubstructureLibraryFilter _filter;
        private SubstructureLibrary _filteredLib;


        /// <summary>
        /// Constructor for a SubstructureLibrary.
        /// </summary>
        /// <param name="name">The name of the SubstructureLibrary</param>
        public SubstructureLibrary(string name)
        {
            _name = name;
            _arEntries = new ArrayList();
            _hsAssayResults = new Hashtable();
            _hsChemIds = new Hashtable();
            _propertyString = "Not loaded from file.";
        }

        /// <summary>
        /// Return a filtered substructure library
        /// </summary>
        /// <param name="original"></param>
        /// <param name="filt"></param>
        public SubstructureLibrary(SubstructureLibrary original, SubstructureLibraryFilter filt)
        {
            _name = original.Name;
            _arEntries = new ArrayList();
            _hsAssayResults = new Hashtable();
            _hsChemIds = new Hashtable();
            _propertyString = "Not loaded from file.";
            // copy the entries from the previous library, but only if they are within range
            foreach(SubstructureEntry ent in original.Entries) {
                if (filt.EntryName != "") {
                    if (ent.Name == filt.EntryName) {
                        _arEntries.Add(ent.Copy());
                    }
                } else {
                    if (ent.NumEntries >= filt.MinCompounds && ent.NumEntries <= filt.MaxCompounds)
                    {
                        _arEntries.Add(ent.Copy());
                    }
                }
            }
        }

        /// <summary>
        /// Apply a filter to this substructure library and return the filtered library
        /// This will also set the _filteredLib property of this object
        /// </summary>
        /// <param name="filt"></param>
        /// <returns></returns>
        public SubstructureLibrary ApplyFilter(SubstructureLibraryFilter filter)
        {
            _filter = filter;
            _filteredLib = new SubstructureLibrary(this, filter);
            return _filteredLib;
        }

        public SubstructureLibrary FilteredLibrary
        {
            // return the filtered library, or this, as appropriate
            get
            {
                if (_filteredLib != null)
                {
                    return _filteredLib;
                }
                else
                {
                    return this;
                }
            }
        }

        public Hashtable UniqueIds
        {
            get
            {
                return _hsChemIds;
            }
        }

        public long NumEntries
        {
            get
            {
                return _arEntries.Count;
            }
        }

        public string Name
        {
            get
            {
                return _name;
            }
        }

        public string propertyString
        {
            get
            {
                return _arEntries.Count + " entries." + "\r\n" + "Maximum number of compounds: " + maxCompounds + "\r\n" + "Minimum number of compounds: " + minCompounds; 
            }
        }

        public long maxCompounds
        {
            get
            {
                long max = 0;
                foreach (SubstructureEntry entry in _arEntries)
                {
                    max = Math.Max(max, entry.NumEntries);
                }
                return max;
            }
        }

        public ArrayList Entries
        {
            get
            {
                return _arEntries;
            }
        }

        public long minCompounds {
            get {
                long min = 100000000;
                foreach (SubstructureEntry entry in _arEntries)
                {
                    min = Math.Min(min, entry.NumEntries);
                }
                return min;
            }
        }

        /// <summary>
        /// clear out the results
        /// </summary>
        public void ClearResults()
        {
            _hsAssayResults.Clear();
            foreach (SubstructureEntry entry in _arEntries)
            {
                entry.ClearResults();
            }
        }

        /// <summary>
        /// Add a set of assay results to the substructure library
        /// </summary>
        /// <param name="ar"></param>
        public void AddResults(AssayResults ar)
        {
            _hsAssayResults.Add(ar.Name, ar);
            // associate the results with each substructure entry
            foreach (SubstructureEntry entry in _arEntries)
            {
                entry.AddResults(ar);
            }
        }

        /// <summary>
        /// LoadFromFile loads a tab-delimited substructure library from a file.  The format of the file is
        /// assumed to be a header line of substructure names, followed by a second header line
        /// of SMILES string representations of the substructures, followed by a list of ids that
        /// match this substructure.
        /// </summary>
        /// <param name="filename">The fully qualified filename of the file to be loaded</param>
        public void LoadFromFile(string filename)
        {
            _filename = filename;
            _arEntries.Clear();
            StreamReader sra = new StreamReader(filename);
            // handle csv files and tab-delim text files
            char[] delim;
            if (filename.Contains(".csv"))
            {
                delim = new char[] { ',' };
            }
            else
            {
                delim = new char[] { '\t' };
            }

            // read first line and extract header names into an array
            string[] headerArray = sra.ReadLine().Split(delim);

            bool bNewFormat = false;
            // decide if we are going to throw away the first column
            if (headerArray[0].ToString().ToLower() == "index")
            {
                bNewFormat = true;
            }

            string[] smilesArray = null;
            if (!bNewFormat)
            {
                // read second line and extract SMILES strings into an array
                smilesArray = sra.ReadLine().Split(delim);
            }

            // construct temporary data structures - a hashtable of ArrayLists
            // each ArrayList will contain the substructure ids for a given substructure
            Hashtable hsEntries = new Hashtable();
            foreach (string s in headerArray)
            {
                if (!bNewFormat || s.ToLower() != "index") 
                    hsEntries.Add(s, new ArrayList());
            }

            // read remainder of lines and associate items with correct arrayLists
            int istart = 0;
            if (bNewFormat) istart = 1;
            while (!sra.EndOfStream)
            {
                string[] thisLine = sra.ReadLine().Split(delim);
                for(int i=istart; i<thisLine.GetLength(0); i++)
                {
                    string s = thisLine[i].Trim();
                    if (s != "") {
                        ((ArrayList)hsEntries[headerArray[i].ToString()]).Add(s);
                    }
                }
            }

            // now construct SubstructureEntry objects and add ids to our master list
            for (int i=istart; i<headerArray.GetLength(0); i++)
            {
                ArrayList tmp = ((ArrayList)hsEntries[headerArray[i].ToString()]);
                _arEntries.Add(new SubstructureEntry(headerArray[i].ToString(), bNewFormat ? "" : smilesArray[i].ToString(), (String[])tmp.ToArray(typeof(string))));
                // add ids to master list
                foreach (string s in tmp)
                {
                    if (!_hsChemIds.ContainsKey(s))
                    {
                        _hsChemIds.Add(s, s);
                    }
                }
            }
        }

        /// <summary>
        /// Write out all files for all individual assay results versus this substructure library
        /// </summary>
        /// <param name="dirName"></param>
        public void WriteAllAssayAnalysisFiles(string dirName)
        {
            foreach (string arName in _hsAssayResults.Keys)
            {
                WriteAssayAnalysisFile(arName, dirName);
            }
        }

        /// <summary>
        /// Write out a file containing stats for an individual assay result versus this substructure library
        /// </summary>
        /// <param name="assayName"></param>
        public void WriteAssayAnalysisFile(string assayName, string dirName)
        {
            AssayResults ar = (AssayResults)_hsAssayResults[assayName];
            string filename = dirName + "\\" + assayName + ".txt";
            StreamWriter sw = new StreamWriter(filename);
            StringBuilder sb = new StringBuilder();
            StatisticsCollection stats = ar.StatCollection;

            // output the statistics results
            foreach (StatisticsEntry stat in stats.Entries)
            {
                if (stat.Perform)
                {
                    sb.Length = 0;
                    sb.Append(stat.Name);
                    sb.Append("\t" + stat.Result.ToString());
                    foreach (SubstructureEntry ent in _arEntries)
                    {
                        sb.Append("\t" + ((AssayResults)ent.AssayResultsHash[assayName]).StatCollection.Item(stat.Name).Result);
                    }
                    sw.WriteLine(sb.ToString());
                }
            }

            //column headers
            sb.Length = 0;
            sb.Append("SID\tAll Results");
            foreach (SubstructureEntry ent in _arEntries)
            {
                sb.Append("\t" + ent.Name);
            }
            sw.WriteLine(sb.ToString());
            // following lines - all SIDs for the library, followed by the individual result for that substructure library,
            // if it exists
            foreach (string SID in ar.ResultHash.Keys)
            {
                sb.Length = 0;
                sb.Append(SID + "\t" + ar.ResultHash[SID].ToString());
                foreach (SubstructureEntry ent in _arEntries)
                {
                    sb.Append("\t");
                    if (((AssayResults)ent.AssayResultsHash[assayName]).ResultHash.ContainsKey(SID))
                    {
                        sb.Append(((AssayResults)ent.AssayResultsHash[assayName]).ResultHash[SID].ToString());
                    }
                }
                sw.WriteLine(sb.ToString());
            }
            // close file
            sw.Close();
        }

        /// <summary>
        /// Write out the summary file containing stats for the library's performance against all screens
        /// </summary>
        /// <param name="filename"></param>
        public void WriteSummaryFile(string filename)
        {
            StreamWriter sw = new StreamWriter(filename);
            // first header line, with blank first column, then groups repeated assay names
            StringBuilder sb = new StringBuilder("");
            foreach (AssayResults ar in _hsAssayResults.Values)
            {
                foreach (StatisticsEntry stat in ar.StatCollection.Entries)
                {
                    if (stat.Perform)
                    {
                        sb.Append("\t" + ar.Name);
                    }
                }
            }
            sw.WriteLine(sb.ToString());
            // second header line, with blank first column, then names of statistics
            sb.Length = 0;
            foreach (AssayResults ar in _hsAssayResults.Values)
            {
                foreach (StatisticsEntry stat in ar.StatCollection.Entries)
                {
                    if (stat.Perform)
                    {
                        sb.Append("\t" + stat.Name);
                    }
                }
            }
            sw.WriteLine(sb.ToString());
            // write out results for the assay result set as a whole
            sb.Length = 0;
            sb.Append("All Results");
            foreach (AssayResults ar in _hsAssayResults.Values)
            {
                foreach (StatisticsEntry stat in ar.StatCollection.Entries)
                {
                    if (stat.Perform)
                    {
                        sb.Append("\t" + stat.Result.ToString());
                    }
                }
            }
            sw.WriteLine(sb.ToString());
            // now write out substructure entry results - one line for each substructure entry, one 
            // column set for each assay result type
            foreach (SubstructureEntry sent in _arEntries)
            {
                sb.Length = 0;
                // start each line with substructure entry name
                sb.Append(sent.Name);
                foreach (AssayResults ar in _hsAssayResults.Values) {
                    string arName = ar.Name;
                    foreach (StatisticsEntry stat in ar.StatCollection.Entries)
                    {
                        if (stat.Perform)
                        {
                            sb.Append("\t" + ((AssayResults)sent.AssayResultsHash[arName]).StatCollection.Item(stat.Name).Result.ToString());
                        }
                    }
                }
                sw.WriteLine(sb.ToString());
            }
            // close file
            sw.Close();
        }
    }
}
