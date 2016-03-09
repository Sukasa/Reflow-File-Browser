using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reflow_Oven_File_Browser
{
    class DirOperation : Operation
    {
        string OperationString;
        string Directory;
        bool Ready = false;

        public override bool IsComplete()
        {
            return Ready;
        }

        public DirOperation(string Folder)
        {
            OperationString = "DIR " + Folder;
            Directory = Folder;
        }

        public override void Process()
        {
            if (OperationString != string.Empty)
            {
                SendPacket(OperationString);
            }

            OperationString = string.Empty;
        }

        public override void BinaryPacketReceived(byte[] PacketData)
        {
            // Nothing
        }

        public override void PacketReceived(string Param, string Packet)
        {
            Ready = true;
            Server.CurrentDirectory = Directory;
        }
    }
}
