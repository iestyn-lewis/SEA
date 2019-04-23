using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using STATCONNECTORSRVLib;

namespace SEA
{
    /// <summary>
    /// The class responsible for running an analysis.  Doesn't do much besides hold references to a set of assay results
    /// and a substructure library, and call the appropriate methods when Run is call.d
    /// </summary>
    class SEAAnalysis
    {
        private SubstructureLibrary _substructureLibrary;
        private Hashtable _hsAssayResults;
        // parameters for the analysis
        /// <summary>
        /// Minimum number of compounds per entry that the analysis will test - not currently used
        /// </summary>
        private int _minCompoundsPerEntry;
        /// <summary>
        /// Maximum number of compounds per entry that the analysis will test - not currently used
        /// </summary>
        private int _maxCompoundsPerEntry;
        private StatisticsCollection _stats;
        private string _customFunctionsDir;

        public SEAAnalysis(SubstructureLibrary library, Hashtable results, StatisticsCollection stats, string CustomFunctionsDir)
        {
            _substructureLibrary = library;
            _hsAssayResults = results;
            _stats = stats;
            _customFunctionsDir = CustomFunctionsDir;
        }

        public SEAAnalysis(Hashtable results, SEAEnvironment environment)
        {
            _substructureLibrary = environment.subsLib;
            _hsAssayResults = results;
            _stats = environment.stats;
            _customFunctionsDir = environment.CustomFunctionsDir;
        }

        public int MaxCompoundsPerEntry
        {
            set
            {
                _maxCompoundsPerEntry = value;
            }
        }

        public int MinCompoundsPerEntry
        {
            set
            {
                _minCompoundsPerEntry = value;
            }
        }

        public void Run()
        {
            // fire up R
            STATCONNECTORSRVLib.StatConnector statConn = new StatConnector();
            statConn.Init("R");

            // read the custom functions from the dir
            RFunctions rfunc = new RFunctions(_customFunctionsDir, statConn);
            rfunc.Reload();

            // for each set of assay results, associate the results with the substructure libraries
            foreach (AssayResults aResults in _hsAssayResults.Values)
            {
                // associate the stats collection with the results
                aResults.StatCollection = _stats.Copy();
                // associate the results with the substructure library
                _substructureLibrary.AddResults(aResults);
                // now, calculate the statistics for this result set (which will also calculate statistics for 
                // all results sets that were added to the substructure library entries).
                aResults.CalculateStatistics(statConn);
            }
            // close the connection
            statConn.Close();
        }
    }
}
