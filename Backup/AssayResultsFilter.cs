using System;
using System.Collections.Generic;
using System.Text;

namespace SEA
{
    class AssayResultsFilter
    {
        private long _highSDCutoff;
        private long _lowSDCutoff;
        private long _highCutoff;
        private long _lowCutoff;
        private string _excludeString;

        public long DEFAULT_CUTOFF = 999999999999;

        public AssayResultsFilter()
        {
            _highCutoff = DEFAULT_CUTOFF;
            _lowCutoff = -DEFAULT_CUTOFF;
            _highSDCutoff = DEFAULT_CUTOFF;
            _lowSDCutoff = DEFAULT_CUTOFF;
            _excludeString = "";
        }

        public long HighSDCutoff
        {
            get
            {
                return _highSDCutoff;
            }
            set
            {
                _highSDCutoff = value;
            }
        }

        public long LowSDCutoff
        {
            get
            {
                return _lowSDCutoff;
            }
            set
            {
                _lowSDCutoff = value;
            }
        }

        public long HighCutoff
        {
            get
            {
                return _highCutoff;
            }
            set
            {
                _highCutoff = value;
            }
        }

        public long LowCutoff
        {
            get
            {
                return _lowCutoff;
            }
            set
            {
                _lowCutoff = value;
            }
        }

        public string ExcludeString
        {
            get
            {
                return _excludeString;
            }
            set 
            {
                _excludeString = value;
            }
        }
    }
}
