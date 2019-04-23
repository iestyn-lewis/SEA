using System;
using System.Collections.Generic;
using System.Text;

namespace SEA
{
    /// <summary>
    /// A class to hold information about the filters placed on a substructure library
    /// </summary>
    class SubstructureLibraryFilter
    {
        private long _minCompounds;
        private long _maxCompounds;
        private string _entryName;

        public SubstructureLibraryFilter()
        {
            _minCompounds = -1;
            _maxCompounds = 9999999999;
            _entryName = "";
        }

        // accessors
        public long MaxCompounds
        {
            get
            {
                return _maxCompounds;
            }
            set
            {
                _maxCompounds = value;
            }
        }

        public long MinCompounds
        {
            get
            {
                return _minCompounds;
            }
            set
            {
                _minCompounds = value;
            }
        }

        public string EntryName
        {
            get
            {
                return _entryName;
            }
            set
            {
                _entryName = value;
            }
        }
    }
}
