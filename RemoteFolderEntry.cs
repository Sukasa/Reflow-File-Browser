using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reflow_Oven_File_Browser
{
    class RemoteFolderEntry : RemoteFileEntry
    {
        public override string FileExtension
        {
            get
            {
                return ".FOLDER";
            }
        }
    }
}
