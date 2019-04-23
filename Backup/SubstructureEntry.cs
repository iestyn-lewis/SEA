using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;

namespace SEA
{
    /// <summary>
    /// SubstructureEntry represents a group of related structures from a library.  It consists of a name and a list of ids
    /// from a library.  It also may contain a hashtable of arrays of biological results.  These results are associated
    /// with this group of related substructures, and statistical calculations are carried out over these results.
    /// These results may then be compared with the full set of results to determine whether a significant difference
    /// exists between the substructure group and the full set of results.
    /// </summary>
    class SubstructureEntry
    {
        private string _name;
        private string _SMILES;
        /// <summary>
        /// ids of structures which contain this substructure
        /// </summary>
        private string[] _ids;
        private long _numEntries;
        /// <summary>
        /// The AssayResults objects representing the different types of assay results for this structure group
        /// </summary>
        private Hashtable _hsAssayResults;

        public SubstructureEntry(string name, string SMILES, string[] ids)
        {
            _name = name;
            _SMILES = SMILES;
            _ids = ids;
            _hsAssayResults = new Hashtable();
            _numEntries = _ids.Length;
        }

        /// <summary>
        /// return a copy of this substructure entry
        /// </summary>
        /// <returns></returns>
        public SubstructureEntry Copy()
        {
            return new SubstructureEntry(_name, _SMILES, _ids);
        }

        public string Name
        {
            get
            {
                return _name;
            }
        }

        public string[] Ids
        {
            get
            {
                return _ids;
            }
        }

        public long NumEntries
        {
            get
            {
                return _numEntries;
            }
        }

        public Hashtable AssayResultsHash
        {
            get
            {
                return _hsAssayResults;
            }
        }

        /// <summary>
        /// clear all results from the entry
        /// </summary>
        public void ClearResults()
        {
            _hsAssayResults.Clear();
        }

        /// <summary>
        /// Add a set of Assay results for this library
        /// </summary>
        /// <param name="arMaster">The master set of assay results</param>
        public void AddResults(AssayResults arMaster)
        {
            // create a new AssayResults objects from me and the master set of results,
            // and put it into the hashtable of results
            _hsAssayResults.Add(arMaster.Name, new AssayResults(this, arMaster));
        }
    }
}
