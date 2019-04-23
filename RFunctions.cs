using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace SEA
{
    /// <summary>
    /// This class simply loads custom functions into R from a set of files
    /// </summary>
    class RFunctions
    {
        private string _dir;
        private STATCONNECTORSRVLib.StatConnector _stat;

        public RFunctions(string dir, STATCONNECTORSRVLib.StatConnector stat)
        {
            _dir = dir;
            _stat = stat;
        }

        /// <summary>
        /// Reload all functions found in the given directory
        /// </summary>
        public void Reload() {
            DirectoryInfo di = new DirectoryInfo(_dir);
            FileInfo[] rgFiles = di.GetFiles("*.txt");
            foreach (FileInfo fi in rgFiles)
            {  
               _stat.EvaluateNoReturn("source(\"" + fi.FullName.Replace("\\", "/") + "\")");
            }
        }
    }
}
