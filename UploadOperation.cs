using System;
using System.IO;

namespace Reflow_Oven_File_Browser
{
    class UploadOperation : Operation, IDisposable
    {
        FileStream UploadFileStream;
        byte[] UploadBuffer = null;
        int MaxChunkSize = -1;
        bool Complete = false;
        bool Started = false;
        string Destination = "";

        public override void Process()
        {
            if (!Started)
            {
                if (UploadFileStream == null)
                {
                    Complete = true;
                    Started = true;
                    return;
                }
                SendPacket(String.Format("PUT {0} {1}", Destination, UploadFileStream.Length));
                Started = true;
            }
        }

        public UploadOperation(string SourceFilename, string DestFilename)
        {
            UploadFileStream = File.OpenRead(SourceFilename);
            Destination = DestFilename;
        }

        public override bool IsComplete()
        {
            return Complete;
        }

        public override void PacketReceived(string Packet, string Param)
        {
            if (Packet == "Ready")
            {
                if (MaxChunkSize == -1)
                {
                    MaxChunkSize = int.Parse(Param);
                    UploadBuffer = new byte[MaxChunkSize];
                }
                int AmtRead = UploadFileStream.Read(UploadBuffer, 0, MaxChunkSize);
                SendPacket(UploadBuffer, AmtRead);
            }
            else if (Packet == "Done")
            {
                Complete = true;
                UploadFileStream.Close();
                UploadFileStream.Dispose();
                UploadFileStream = null;
            }
        }

        public override void BinaryPacketReceived(byte[] PacketData)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            if (UploadFileStream != null)
            {
                UploadFileStream.Close();
                UploadFileStream.Dispose();
                UploadFileStream = null;
            }
        }
    }
}
