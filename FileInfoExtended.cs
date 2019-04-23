using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace SEA
{
    /// <summary>
    /// Convenience class to hold a human-visible filename, with no extension,
    /// and the full pathname of a file.  This should probably be a subclass of FileInfo...
    /// </summary>
    class FileInfoExtended
    {
        private string _nameNoExt;
        private string _name;
        private string _fullName;
        private FileInfo _fi;

        public string NameNoExt
        {
            get
            {
                return _nameNoExt;
            }
        }

        public string Name
        {
            get
            {
                return _name;
            }
        }

        public string FullName
        {
            get
            {
                return _fullName;
            }
        }

        public FileInfo InternalFileInfo
        {
            get
            {
                return _fi;
            }
        }

        /// <summary>
        /// Construct a new FileInfoExtended from a FileInfo object
        /// </summary>
        /// <param name="fi"></param>
        public FileInfoExtended(FileInfo fi)
        {
            _fi = fi;
            _fullName = fi.FullName;
            _name = fi.Name;
            _nameNoExt = fi.Name.Replace(fi.Extension, "");
        }

        /// <summary>
        /// Construct a new FileInfoExtended from a filename string
        /// </summary>
        /// <param name="filename"></param>
        public FileInfoExtended(string filename)
        {
            _fullName = filename;
            _fi = new FileInfo(filename);
            _name = _fi.Name;
            _nameNoExt = _fi.Name.Replace(_fi.Extension, "");
        }
    }
}
