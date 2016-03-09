using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using System.Windows.Forms;

namespace Reflow_Oven_File_Browser
{
    class RemoteServer
    {
        public IPEndPoint Endpoint { get; set; }
        public string FriendlyName { get; set; }
        public string Version { get; set; }
        public string Status { get; set; }

        public void Tick()
        {
            if (CurrentOperation != null)
            {
                if (CurrentOperation.IsComplete())
                {
                    if (QueuedCommands.Count > 0)
                    {
                        CurrentOperation = QueuedCommands.Dequeue();
                    }
                    else
                    {
                        CurrentOperation = null;
                    }
                }
                else
                {
                    CurrentOperation.Process();
                }
            }
        }

        public void EnqueueCommand(Operation Command)
        {
            if (CurrentOperation == null)
            {
                CurrentOperation = Command;
                Command.Process();
            }
            else
            {
                QueuedCommands.Enqueue(Command);
            }
        }

        public Operation CurrentOperation;
        public Queue<Operation> QueuedCommands = new Queue<Operation>();

        public bool ExpectingBinary { get; set; }

        public int BinaryProgress { get; set; }
        public int BinarySizeTotal { get; set; }

        public string RootDirectory { get; set; }
        public string CurrentDirectory { get; set; }
        public List<RemoteFileEntry> CurrentDirectoryFiles = new List<RemoteFileEntry>();
    }
}
