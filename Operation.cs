using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reflow_Oven_File_Browser
{
    abstract class Operation
    {
        public RemoteServer Server { get; set; }

        protected void SendPacket(byte[] PacketData, int Amount = -1)
        {
            if (Amount == -1)
                Amount = PacketData.Length;
            frmMain.SendPacket(PacketData, Amount, Server.Endpoint);
        }

        protected void SendPacket(string PacketData)
        {
            SendPacket(Encoding.UTF8.GetBytes(PacketData));
        }

        public abstract void Process();

        public abstract bool IsComplete();

        public abstract void PacketReceived(string Packet, string Param);

        public abstract void BinaryPacketReceived(byte[] PacketData);
    }
}
