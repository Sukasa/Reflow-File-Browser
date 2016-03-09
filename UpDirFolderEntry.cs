using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reflow_Oven_File_Browser
{
    class UpDirFolderEntry : RemoteFolderEntry
    {
        public override string Name
        {
            get
            {
                return "..";
            }
        }
    }
}
