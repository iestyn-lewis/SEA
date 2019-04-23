using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using STATCONNECTORSRVLib;

namespace SEA
{
    /// <summary>
    /// Holds information about the local environment that SEA is run in (directories, etc).
    /// </summary>
    class SEAEnvironment
    {
        // special directories which must be present
        string _appPath;
        string _subLibPath;
        string _outputPath;
        string _statisticsFile;
        string _functionsDir;
        static string OUTPUT_DIR = "Output";
        static string SUBSTRUCTURE_DIR = "Substructure Libraries";
        static string STATISTICS_DIR = "Statistics";
        static string STATISTICS_FILE = "statistics.txt";
        static string FUNCTIONS_DIR = "Functions";
        static string HELP_DIR = "Help";

        // member objects
        StatisticsCollection _stats;
        SubstructureLibrary _subsLib;
        SubstructureLibraryFilter _subsFilter;
        Hashtable _hsAssayResults;
        RFunctions _rfunc;
        STATCONNECTORSRVLib.StatConnector _statConn;

        // state variables to use when running analysis in an interactive manner
        long _analysisSize;
        long _analysisCount;
        // enumerator to iterate through the hashtable
        IDictionaryEnumerator _enum;
        AssayResults _currResults;

        // accessors

        public string helpPath
        {
            get
            {
                return _appPath + "\\" + HELP_DIR;
            }
        }

        public string subLibPath
        {
            get
            {
                return _subLibPath;
            }
        }

        public SubstructureLibrary subsLib {
            get {
                return _subsLib;
            }
        }

        public StatisticsCollection stats
        {
            get
            {
                return _stats;
            }
        }

        public Hashtable AssayResultsHash
        {
            get
            {
                return _hsAssayResults;
            }
            set
            {
                _hsAssayResults = value;
            }
        }

        /// <summary>
        /// Convenience method to return a given assay results item
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public AssayResults AssayResultsItem(string item)
        {
            return (AssayResults)_hsAssayResults[item];
        }

        public string CustomFunctionsDir {
            get
            {
                return _functionsDir;
            }
        }

        public string OutputPath
        {
            get
            {
                return _outputPath;
            }
        }

        public SEAEnvironment()
        {
            // set application paths
            _appPath = System.IO.Path.GetDirectoryName(System.Windows.Forms.Application.ExecutablePath);
            _subLibPath = _appPath + "\\" + SUBSTRUCTURE_DIR;
            _outputPath = _appPath + "\\" + OUTPUT_DIR;
            _statisticsFile = _appPath + "\\" + STATISTICS_DIR + "\\" + STATISTICS_FILE;
            _functionsDir = _appPath + "\\" + STATISTICS_DIR + "\\" + FUNCTIONS_DIR;

            _stats = new StatisticsCollection();
            _subsLib = new SubstructureLibrary("Substructure Library");
            _hsAssayResults = new Hashtable();
        }

        /// <summary>
        /// check to see that R is present - if it is, initiate the R connection
        /// </summary>
        public string CheckREnvironment() {
            // fire up R
            String ret = "";
            try {
                _statConn = new StatConnector();
                _statConn.Init("R");
            } catch (Exception e) {
                ret = e.Message;
            }
            return ret;
        }

        public void ApplySubstructureLibraryFilter(SubstructureLibraryFilter filt)
        {
            _subsLib.ApplyFilter(filt);
        }

        public void ReloadRFunctions()
        {
            _rfunc.Reload();
        }

        public void ReloadStatistics()
        {
            _stats.LoadFromFile(_statisticsFile);
        }

        /// <summary>
        /// Run the analysis in a piecewise fashion, so progress can be reported and 
        /// analysis stopped if necessary.  Returns the percentage of analysis done.
        /// </summary>
        public int RunAnalysisInteractive()
        {
            int percentDone = -1;
            bool b = _currResults.CalculateStatisticsInteractive(_statConn);
            // if return value was false, then the statistics are done for this assay result,
            // and we should try to move to the next
            if (!b)
            {
                if (_enum.MoveNext())
                {
                    _currResults = ((AssayResults)_enum.Value).FilteredResults;
                    // associate the stats collection with the results
                    _currResults.StatCollection = _stats.Copy();
                    // associate the results with the substructure library
                    _subsLib.FilteredLibrary.AddResults(_currResults);
                    // prep the statistics run
                    _currResults.PrepInteractiveStatisticsRun(_statConn);
                    b = _currResults.CalculateStatisticsInteractive(_statConn);
                }
            }
            // if we have a true return value from CalculateStatisticsInteractive, then we can increment the count
            if (b)
            {
                _analysisCount ++;
                percentDone = Convert.ToInt32((double)_analysisCount / (double)_analysisSize * 100);
            }
            return percentDone;
        }

        /// <summary>
        /// prepare to perform the analysis
        /// </summary>
        public void PrepAnalysisInteractive()
        {
            CheckREnvironment();
            // clear out the library
            _subsLib.FilteredLibrary.ClearResults();

            // read the custom functions from the dir
            _rfunc = new RFunctions(_functionsDir, _statConn);
            _rfunc.Reload();

            // get the size of this run so we can update interested parties
            _analysisSize = _subsLib.FilteredLibrary.NumEntries * _hsAssayResults.Count;
            _analysisCount = 0;

            _enum = _hsAssayResults.GetEnumerator();
            // Enumerators start out _before_ the beginning of the collection, so we have to
            // MoveNext to be at the first value
            _enum.MoveNext();
            _currResults = ((AssayResults)_enum.Value).FilteredResults;
            // associate the stats collection with the results
            _currResults.StatCollection = _stats.Copy();
            // clear subresults
            _currResults.ClearSubResults();
            // associate the results with the substructure library
            _subsLib.FilteredLibrary.AddResults(_currResults);
            // prep the statistics run
            _currResults.PrepInteractiveStatisticsRun(_statConn);
        }

        /// <summary>
        /// Non-interactive, one-shot method of running analysis
        /// </summary>
        public void RunAnalysis()
        {
            // read the custom functions from the dir
            _rfunc = new RFunctions(_functionsDir, _statConn);
            _rfunc.Reload();

            // for each set of assay results, associate the results with the substructure libraries
            foreach (AssayResults aResults in _hsAssayResults.Values)
            {
                // associate the stats collection with the results
                aResults.FilteredResults.StatCollection = _stats.Copy();
                // associate the results with the substructure library
                _subsLib.FilteredLibrary.AddResults(aResults.FilteredResults);
                // now, calculate the statistics for this result set (which will also calculate statistics for 
                // all results sets that were added to the substructure library entries).
                aResults.FilteredResults.CalculateStatistics(_statConn);
            }
            // close the connection
            _statConn.Close();
        }

    }
}
