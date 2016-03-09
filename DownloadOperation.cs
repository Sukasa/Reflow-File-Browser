using System;
using System.IO;

namespace Reflow_Oven_File_Browser
{
    class DownloadOperation : Operation, IDisposable
    {

        FileStream OutputFile;
        int SizeTotal = 0;
        int BytesReceived = 0;

        public override void Process()
        {
            // Do nothing
        }

        public DownloadOperation(string SourceFilename, string DestFilename)
        {
            if (File.Exists(DestFilename))
                File.Delete(DestFilename);

            OutputFile = File.OpenWrite(DestFilename);
            SendPacket(string.Format("GET {0}", SourceFilename));
        }

        public override bool IsComplete()
        {
            return BytesReceived >= SizeTotal && SizeTotal > 0;
        }

        public override void PacketReceived(string Packet, string Param)
        {
            if (Packet == "Ready")
            {
                SizeTotal = int.Parse(Param);
            }
        }

        public override void BinaryPacketReceived(byte[] PacketData)
        {
            OutputFile.Write(PacketData, 0, PacketData.Length);
            BytesReceived += PacketData.Length;
        }

        public void Dispose()
        {
            if (OutputFile != null)
            {
                OutputFile.Close();
                OutputFile.Dispose();
            }
        }
    }
}
