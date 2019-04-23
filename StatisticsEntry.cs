using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using System.Windows.Forms;

namespace SEA
{
    /// <summary>
    /// StatisticsEntry represents a single statistic to be calculated.
    /// </summary>
    class StatisticsEntry
    {
        private string _name;
        /// <summary>
        /// Number of inputs to this statistic calculation
        /// </summary>
        private int _numInputs;
        /// <summary>
        /// The call to make to R to calculate this statistic
        /// The call should have a placeholder of <INPUT_X>, where X is the number of the input, which will be replaced by 
        /// the appropriate vector name at runtime
        /// </summary>
        private string _RCall;
        /// <summary>
        /// One of the OUTPUT_ constants, denoting the output type of this statistic.
        /// </summary>
        private string _outputType;
        /// <summary>
        /// The result of the statistic.  This will then be cast to the appropriate type
        /// by the caller, based on the info in OutputType.
        /// </summary>
        private object _result;
        /// <summary>
        /// Set this to false to NOT run this statistic
        /// </summary>
        private bool _perform;

        private const string INPUT_1 = "<INPUT_1>";
        private const string INPUT_2 = "<INPUT_2>";

        public const string OUTPUT_INT = "INT";
        public const string OUTPUT_DOUBLE = "DOUBLE";
        public const string OUTPUT_STRING = "STRING";

        #region propertyAccessors
        public string Name
        {
            get
            {
                return _name;
            }
        }
        public object Result
        {
            get
            {
                return _result;
            }
        }
        public string OutputType {
            get {
                return _outputType;
            }
        }

        public bool Perform
        {
            get
            {
                return _perform;
            }
            set
            {
                _perform = value;
            }
        }
        #endregion

        public StatisticsEntry(string name, string RCall, int numInputs, string outputType)
        {
            _name = name;
            _RCall = RCall;
            _numInputs = numInputs;
            _outputType = outputType;
            _result = null;
            _perform = true;
        }

        /// <summary>
        /// return a duplicate of this StatisticsEntry, except for the result
        /// </summary>
        /// <returns></returns>
        public StatisticsEntry Copy()
        {
            StatisticsEntry copy = new StatisticsEntry(_name, _RCall, _numInputs, _outputType); 
            copy.Perform = _perform;
            return copy;
        }

        public void Calculate(STATCONNECTORSRVLib.StatConnector stat, double[] inputData,  bool isMasterResult)
        {
            string symbol = "subresults";
            if (isMasterResult)
            {
                symbol = "masterresults";
            }
            // simple use of the StatConnector - SetSymbol associates a name with an array of values
            // Evaluate can be passed any piece of R code.  A single StatConnector instance acts as 
            // a single R session, so any variables set within the instance may be accessed later in the session.
            stat.SetSymbol(symbol, inputData);
            string RExp = _RCall.Replace(INPUT_1, symbol);
            // if this is a comparison statistic, set up the other vector
            // TODO - extend this to an arbitrary number of inputs
            if (_numInputs > 1)
            {
                RExp = _RCall.Replace(INPUT_1, "masterresults");
                if (isMasterResult)
                {
                    RExp = RExp.Replace(INPUT_2, "masterresults");
                }
                else
                {
                    RExp = RExp.Replace(INPUT_2, "subresults");
                }
            }
            // Evaluate the result - do not evaluate if it is trying to compare the master results to the master results
            if (_numInputs > 1 && isMasterResult)
            {
                _result = "";
            }
            else
            {
                try
                {
                    _result = stat.Evaluate(RExp);
                }
                catch (Exception ex)
                {
                    _result = "ERROR";
                }
            }
         }
    }
}
