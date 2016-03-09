using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reflow_Oven_File_Browser
{
    class SimpleOperation : Operation
    {
        string OperationString;
        bool Ready = false;

        public override bool IsComplete()
        {
            return Ready;
        }

        public SimpleOperation(string OperationCode)
        {
            OperationString = OperationCode;
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
            Ready = true;
        }

        public override void PacketReceived(string Param, string Packet)
        {
            Ready = true;
        }
    }
}
