using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using System.IO;

namespace SEA
{
    /// <summary>
    /// Class to hold information about a particular class of assay results.  The results are contained in a hashtable,
    /// the keys being the compound ids, the results being the values.  The results are also kept in an array for fast access.
    /// Another set of AssayResults may be used as a comparison or control set to determine a t-test value.
    /// </summary>
    class AssayResults
    {
        /// <summary>
        /// The name of the set of results.
        /// </summary>
        private string _name;
        /// <summary>
        /// Key - Compound ID - Value - result
        /// </summary>
        private Hashtable _hsResults;
        /// <summary>
        /// Second column in data file - omit results
        /// </summary>
        private Hashtable _hsOmits;
        /// <summary>
        /// array of result values
        /// </summary>
        private double[] _results;
        /// <summary>
        /// The file column number where the structure ids are found
        /// </summary>
        private long _sidColumn;
        /// <summary>
        /// The file column number where the result may be found
        /// </summary>
        private long _resultColumn;
        /// <summary>
        /// The file column number where the "omit" column may be found - which values to omit
        /// </summary>
        private long _omitColumn;
        /// <summary>
        /// true if this list is a Master Result list - ie, all results for a given assay type
        /// </summary>
        private bool _isMasterResults;
        /// <summary>
        /// Reference to the master results for this set of assay results
        /// </summary>
        private AssayResults _masterResults;
        /// <summary>
        /// List of the subresults associated with this master list
        /// </summary>
        private ArrayList _subResultList;

        // state variables for doing interactive statistics runs
        private IEnumerator _enum;
        private AssayResults _currResults;

        // statistical figures 
        private StatisticsCollection _stats;

        // filtering objects
        private AssayResultsFilter _filter;
        private AssayResults _filteredResults;

        #region propertyAccessors
        public AssayResultsFilter Filter
        {
            get
            {
                return _filter;
            }
        }

        public StatisticsCollection StatCollection {
            get {
                return _stats;
            }
            set {
                // set all sub results
                _stats = value;
            }
        }

        public string propertyString
        {
            get
            {
                return _hsResults.Count + " entries." + "\r\nMaximum: " + maxValue + "\r\nMinimum: " + minValue + "\r\nMean: " + meanValue + "\r\nSD: " + sdValue;
            }
        }
        public double maxValue
        {
            get
            {
                return SEAMath.Max(_results);
            }
        }
        public double minValue
        {
            get
            {
                return SEAMath.Min(_results);
            }
        }

        public double meanValue
        {
            get
            {
                return SEAMath.Mean(_results);
            }
        }

        public double sdValue
        {
            get
            {
                return SEAMath.StandardDeviation(_results);
            }
        }


        #endregion

        /// <summary>   
        /// Constructor for Master Assay Results - using this constructor will generate a Master Assay Results object
        /// </summary>
        /// <param name="name">name of this assay</param>
        /// <param name="filename">filename to read results from</param>
        public AssayResults(string name, string filename)
        {
            // temp - hardcode columns
            _sidColumn = 0;
            _omitColumn = 1;
            _resultColumn = 2;
            _name = name;
            _isMasterResults = true;
            _subResultList = new ArrayList();
            _hsResults = new Hashtable();
            _hsOmits = new Hashtable();
            if (filename != "")
            {
                LoadFromFile(filename);
            }
        }

        /// <summary>
        /// Construct an AssayResults object from an existing assay results object and a filter
        /// </summary>
        /// <param name="original"></param>
        /// <param name="filter"></param>
        public AssayResults(AssayResults original, AssayResultsFilter filter) : this(original.Name, "")
        {
            // copy all values that match the filter criteria
            bool pass = true;
            double mean = original.meanValue;
            double sd = original.sdValue;
            foreach (string s in original.ResultHash.Keys)
            {
                pass = true;
                double val = (double)original.ResultHash[s];
                if (val > filter.HighCutoff) pass = false;
                if (val < filter.LowCutoff) pass = false;
                if (val > mean + filter.HighSDCutoff * sd) pass = false;
                if (val < mean - filter.LowSDCutoff * sd) pass = false;
                if (filter.ExcludeString != "" && original.OmitHash[s].ToString() == filter.ExcludeString) pass = false;
                if (pass)
                {
                    _hsResults.Add(s, val);
                }
            }
            // convert hashtable values to array
            _results = (double[])(new ArrayList(_hsResults.Values).ToArray(typeof(double)));
        }

        public AssayResults ApplyFilter(AssayResultsFilter filter)
        {
            _filter = filter;
            _filteredResults = new AssayResults(this, filter);
            return _filteredResults;
        }

        /// <summary>
        /// return either the filtered results or the unfiltered results
        /// </summary>
        public AssayResults FilteredResults
        {
            get
            {
                if (!(_filteredResults == null))
                {
                    return _filteredResults;
                }
                else
                {
                    return this;
                }
            }
        }

        /// <summary>
        /// Constructor for a list of assay results for a given substructure - using this constructor will generate a 
        /// list of Assay results for a given Substructure Entry
        /// </summary>
        /// <param name="subEntry">SubstructureEntry object to associate these results to</param>
        /// <param name="masterResults">Master Result list which will be used to generate values for this set of results</param>
        public AssayResults(SubstructureEntry subEntry, AssayResults masterResults)
        {
            _hsResults = new Hashtable();
            _hsOmits = new Hashtable();
            _masterResults = masterResults;
            // add ourselves to the master results' list of subresults
            _masterResults.AddSubResults(this);
            string[] ids = subEntry.Ids;
            // go through the list of ids and pull out results for this substructure library
            for (int i = 0; i < ids.GetLength(0); i++)
            {
                // only add results for which a value is found
                if (masterResults.ResultHash.ContainsKey(ids[i].ToString()))
                {
                    _hsResults.Add(ids[i].ToString(), Convert.ToDouble(masterResults.ResultHash[ids[i].ToString()]));
                }
            }
            // convert hashtable values to array
            _results = (double[])(new ArrayList(_hsResults.Values).ToArray(typeof(double)));
        }

        // property accessors
        public Hashtable ResultHash
        {
            get
            {
                return _hsResults;
            }
        }

        public Hashtable OmitHash
        {
            get {
                return _hsOmits;
            }
        }

        public double[] Results
        {
            get
            {
                return _results;
            }
        }

        public string Name
        {
            get
            {
                return _name;
            }
        }

        /// <summary>
        /// Add a subresult list to our list of subresults - this is used only if we are a master list
        /// </summary>
        /// <param name="arSub"></param>
        protected void AddSubResults(AssayResults arSub)
        {
            _subResultList.Add(arSub);
        }

        public void ClearSubResults()
        {
            _subResultList.Clear();
        }

        /// <summary>
        /// Read results from a file.  Structure ids come from one column, the single column of results from another.
        /// </summary>
        /// <param name="filename"></param>
        private void LoadFromFile(string filename) 
        {
            _hsResults.Clear();
            _hsOmits.Clear();
            StreamReader sra = new StreamReader(filename);
            string[] sLine;
            // read and discard two header lines
            sra.ReadLine();     // contains assay name
            sra.ReadLine();     // contains header info
            // now read the remainder of the lines
            while (!sra.EndOfStream)
            {
                sLine = sra.ReadLine().Split(new char[] { '\t' });
                _hsResults.Add(sLine[_sidColumn].ToString(), Convert.ToDouble(sLine[_resultColumn]));
                _hsOmits.Add(sLine[_sidColumn].ToString(), sLine[_resultColumn].ToString());
            }
            // convert hashtable values to array
            _results = (double[])(new ArrayList(_hsResults.Values).ToArray(typeof(double)));
        }

        /// <summary>
        /// Calculate the statistics for this set of assay results, comparing it to the master list if relevant
        /// If this method is called on a master result list, it will call CalculateStatistics on all of its 
        /// child sub-results.
        /// </summary>
        /// <param name="stat">The StatConnector used to calculate statistics</param>
        public void CalculateStatistics(STATCONNECTORSRVLib.StatConnector stat)
        {
            _stats.Calculate(stat, _results, _isMasterResults);
            if (_isMasterResults)
            {
                // now go through the list of subresults and call CalculateStatistics on the subresults
                foreach (AssayResults ar in _subResultList)
                {
                    ar.StatCollection = _stats.Copy();
                    ar.CalculateStatistics(stat);
                }
            }
        }

        // prepare for an interactive statistics run
        public void PrepInteractiveStatisticsRun(STATCONNECTORSRVLib.StatConnector stat)
        {
            // we can assume we are the master list in this case, so we calculate our overall statistics
            _stats.Calculate(stat, _results, _isMasterResults);
            _enum = _subResultList.GetEnumerator();
        }

        /// <summary>
        /// Calculate the statistics for this set of assay results, comparing it to the master list if relevant
        /// Returns after each call to its subresults calculatestatistics
        /// </summary>
        /// <param name="stat">The StatConnector used to calculate statistics</param>
        public bool CalculateStatisticsInteractive(STATCONNECTORSRVLib.StatConnector stat)
        {
            if (_enum.MoveNext())
            {
                _currResults = (AssayResults)_enum.Current;
                _currResults.StatCollection = _stats.Copy();
                _currResults.CalculateStatistics(stat);
                return true;
            }
            else
            {
                return false;
            }
        }
        
        /// <summary>
        /// Given a substructure library, return the coverage as a percentage (how many compounds in the assay are found in this substructure library)
        /// </summary>
        /// <param name="assayName"></param>
        /// <returns></returns>
        public double Coverage(SubstructureLibrary slib)
        {
            Hashtable rh = _hsResults;
            long resultCount = rh.Count;
            long cpdCount = 0;
            foreach (string s in rh.Keys)
            {
                if (slib.UniqueIds.ContainsKey(s))
                {
                    cpdCount++;
                }
            }
            return Math.Round((double)((double)cpdCount / (double)resultCount * 100), 2);
        }

    }
}
