using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reflow_Oven_File_Browser
{
    class RemoteFileEntry
    {
        public string Filename;
        public virtual string Name
        {
            get
            {
                return Path.GetFileName(Filename);   
            }
        }
        public virtual string FileExtension
        {
            get
            {
                return Path.GetExtension(Filename);
            }
        }
        public int FileSize;
    }
}
