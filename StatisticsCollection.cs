using System;
using System.Collections.Generic;
using System.Collections;
using System.IO;
using System.Text;

namespace SEA
{
    /// <summary>
    /// StatisticsCollection represents a collection of all of the statistics to be run
    /// for a given analysis
    /// </summary>
    class StatisticsCollection
    {
        /// <summary>
        /// The list of statistics
        /// </summary>
        private ArrayList _arEntries;
        /// <summary>
        /// Collection for by-name access
        /// </summary>
        private Hashtable _hsEntries;

        // constants denoting the column position of the statistics entry descriptions in the file
        const int COL_NAME = 0;
        const int COL_R_EXPR = 1;
        const int COL_NUM_INPUTS = 2;
        const int COL_OUTPUT_TYPE = 3;

        public StatisticsCollection()
        {
            _arEntries = new ArrayList();
            _hsEntries = new Hashtable();
        }

        public void Add(StatisticsEntry stat)
        {
            _arEntries.Add(stat);
            _hsEntries.Add(stat.Name, stat);
        }

        public int Count
        {
            get
            {
                return _arEntries.Count;
            }
        }

        public ArrayList Entries
        {
            get
            {
                return _arEntries;
            }
        }

        /// <summary>
        /// Return a given statistics entry
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public StatisticsEntry Item(string name)
        {
            return (StatisticsEntry)_hsEntries[name];
        }

        /// <summary>
        /// LoadFromFile loads a statistics collection from a file.
        /// </summary>
        /// <param name="filename">The fully qualified filename of the file to be loaded</param>
        public void LoadFromFile(string filename)
        {
            _arEntries.Clear();
            _hsEntries.Clear();
            char[] delim = new char[] { '\t' };
            StreamReader sra = new StreamReader(filename);

            // discard first header line
            sra.ReadLine();

            // read remainder of lines and create new Statistics Entries
            while (!sra.EndOfStream)
            {
                string[] thisLine = sra.ReadLine().Split(delim);
                // set lines that begin with "#" to not be run
                bool perform = true;
                if (thisLine[0].StartsWith("#"))
                {
                    perform = false;
                }
                StatisticsEntry se = new StatisticsEntry(thisLine[COL_NAME].Replace("#", ""), thisLine[COL_R_EXPR], Convert.ToInt32(thisLine[COL_NUM_INPUTS]), thisLine[COL_OUTPUT_TYPE]);
                this.Add(se);
                se.Perform = perform;
            }

            sra.Close();
        }

        /// <summary>
        /// Return a copy of this StatisticsCollection
        /// </summary>
        /// <returns></returns>
        public StatisticsCollection Copy()
        {
            StatisticsCollection _return = new StatisticsCollection();
            foreach (StatisticsEntry stat in _arEntries)
            {
                _return.Add(stat.Copy());
            }
            return _return;
        }

        /// <summary>
        /// Calculate all the statistics for this collection
        /// </summary>
        /// <param name="stat"></param>
        /// <param name="inputData"></param>
        /// <param name="isMasterResult"></param>
        public void Calculate(STATCONNECTORSRVLib.StatConnector stat, double[] inputData, bool isMasterResult)
        {
            foreach (StatisticsEntry statEntry in _arEntries)
            {
                if (statEntry.Perform)
                {
                    statEntry.Calculate(stat, inputData, isMasterResult);
                }
            }
        }

    }
}
