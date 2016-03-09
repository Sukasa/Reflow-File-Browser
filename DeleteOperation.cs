using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reflow_Oven_File_Browser
{
    class DeleteOperation : Operation
    {
        string OperationString;
        bool Ready = false;

        public override bool IsComplete()
        {
            return Ready;
        }

        public DeleteOperation(string Filename)
        {
            OperationString = "DELETE " + Filename;
        }

        public override void Process()
        {
            if (OperationString != string.Empty)
            {
                SendPacket(OperationString);
            }

            OperationString = string.Empty;
            Server.EnqueueCommand(new DirOperation(Server.CurrentDirectory));
        }

        public override void BinaryPacketReceived(byte[] PacketData)
        {
            Ready = true;
        }

        public override void PacketReceived(string Param, string Packet)
        {
            Ready = true;
        }
    }
}
