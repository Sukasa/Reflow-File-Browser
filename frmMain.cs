using Etier.IconHelper;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Windows.Forms;

namespace Reflow_Oven_File_Browser
{
    public partial class frmMain : Form
    {
        IconListManager IconManager;
        static Socket Client;

        IPEndPoint LocalEndpoint = new IPEndPoint(IPAddress.Any, 0);
        IPEndPoint BroadcastEndpoint = new IPEndPoint(IPAddress.Broadcast, 15000);
        List<RemoteServer> Remotes = new List<RemoteServer>();
        RemoteServer CurrentServer;

        private static readonly string[] FileSizeSuffixes = new string[] { "B", "KB", "MB", "GB" };

        public frmMain()
        {
            InitializeComponent();
            IconManager = new IconListManager(ilIcons, IconReader.IconSize.Small);

            Client = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
            Client.EnableBroadcast = true;
            Client.SetSocketOption(SocketOptionLevel.Udp, SocketOptionName.NoDelay, 1);
            Client.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.ReuseAddress, 1);

            RemoteFileTree.ImageGetter = FileImageGetter;
            RemoteFileSize.AspectGetter = FileSizeAspectGetter;
            RemoteFileSize.AspectToStringConverter = FileSizeAspectConverter;
            
            ilIcons.Images.Add(".FOLDER", IconReader.GetFolderIcon(IconReader.IconSize.Small, IconReader.FolderType.Closed));

            // Test code
            string[] Files = new string[] { @"SD\Files\text.txt#123", @"SD\Files\cd.png#167892354", @"SD\Files\fake.notanext#22321", @"SD\Files\Folder#DIR" };
            olvFiles.SetObjects(ParseFileList(Files, false, @"SD\Files"));


            btnRescan_Click(null, null);
        }

        private void btnRescan_Click(object sender, EventArgs e)
        {
            // Send out "Knock, Knock" again on UDP Broadcast
            Client.Bind(LocalEndpoint);
            Client.SendTo(MakePacket("KNOCKKNOCK"), BroadcastEndpoint);
        }

        internal static void SendPacket(byte[] Data, int Length, IPEndPoint Endpoint)
        {
            Client.SendTo(Data, Length, SocketFlags.None, Endpoint);
        }

        private void ReceivePacket(byte[] PacketData, IPEndPoint Sender)
        {
            RemoteServer RegisteredRemote = Remotes.FirstOrDefault(x => x.Endpoint.Equals(Sender));

            if (RegisteredRemote != null)
            {
                HandleIncoming(RegisteredRemote, PacketData);
            }
            else
            {
                RemoteServer Server = new RemoteServer() { Endpoint = Sender };
                HandleIncoming(Server, PacketData);
            }
        }

        private void HandleIncoming(RemoteServer Server, byte[] PacketData)
        {
            if (Server.ExpectingBinary)
            {
                // Downloading a file
                if (Server.CurrentOperation != null)
                    Server.CurrentOperation.BinaryPacketReceived(PacketData);
            }
            else
            {
                string Packet = Encoding.UTF8.GetString(PacketData);
                string Param = String.Empty;

                int Split = Packet.IndexOf(' ');
                if (Split > -1)
                {
                    Param = Packet.Substring(Split);
                    Packet = Packet.Substring(0, Split);
                }

                switch (Packet)
                {
                    case "HIHI":
                        if (!Remotes.Contains(Server))
                            Remotes.Add(Server);
                        break;

                    case "IAM":
                        Server.FriendlyName = Param;
                        break;

                    case "ROOT":
                        if (String.IsNullOrWhiteSpace(Server.RootDirectory))
                        {
                            Server.EnqueueCommand(new SimpleOperation("DIR " + Param));
                        }
                        Server.RootDirectory = Param;
                        break;

                    case "CURRENT":
                        Server.Status = Param;
                        break;

                    case "LIST":
                        if (Server.CurrentOperation != null)
                            Server.CurrentOperation.PacketReceived(Packet, Param);

                        string[] Params = Param.Split('\r', '\n').Where(x => !string.IsNullOrWhiteSpace(x)).ToArray();
                        List<RemoteFileEntry> Files = ParseFileList(Params, Server.CurrentDirectory == Server.RootDirectory, Server.CurrentDirectory);
                        Server.CurrentDirectoryFiles = Files;
                        if (Server == CurrentServer)
                        {
                            olvFiles.SetObjects(Files);
                            lblCurrentFolder.Text = CurrentServer.CurrentDirectory;
                        }
                        break;

                    default:
                        if (Server.CurrentOperation != null)
                            Server.CurrentOperation.PacketReceived(Packet, Param);
                        break;
                }
            }
        }

        private List<RemoteFileEntry> ParseFileList(string[] Files, bool IsRootDir = false, string CurrentDirectory = "")
        {
            List<RemoteFileEntry> Output = new List<RemoteFileEntry>();

            if (!IsRootDir)
            {
                UpDirFolderEntry UFE = new UpDirFolderEntry();
                string[] PathParts = CurrentDirectory.Split(Path.DirectorySeparatorChar);
                UFE.Filename = Path.Combine(PathParts.Take(PathParts.Length - 1).ToArray());
                Output.Add(UFE);
            }

            foreach (string File in Files)
            {
                string[] Data = File.Split('#');
                RemoteFileEntry RFE;

                if (Data[1] == "DIR")
                {
                    RFE = new RemoteFolderEntry();
                    RFE.FileSize = 0;
                }
                else
                {
                    RFE = new RemoteFileEntry();
                    RFE.FileSize = int.Parse(Data[1]);
                }

                RFE.Filename = Data[0];
                
                Output.Add(RFE);
                string Extension = RFE.FileExtension.ToUpper();

                if (!ilIcons.Images.ContainsKey(Extension))
                {
                    Icon ExtensionIcon = IconReader.GetFileIcon(RFE.Filename, IconReader.IconSize.Small, false);
                    ilIcons.Images.Add(Extension, ExtensionIcon);
                }
                
            }

            return Output;
        }

        private byte[] MakePacket(string Command, string Param = null)
        {
            return Encoding.UTF8.GetBytes(Param != null ? Command + " " + Param : Command);
        }

        private string CurrentlySelectedFile()
        {
            return "";   
        }

        private void btnDownload_Click(object sender, EventArgs e)
        {
            if (olvFiles.SelectedObject == null)
                return;

             // TODO

            CurrentServer.EnqueueCommand(new SimpleOperation(String.Format("GET {0}", ((RemoteFileEntry)olvFiles.SelectedObject).Filename)));
        }

        private void btnUpload_Click(object sender, EventArgs e)
        {
            DialogResult Result = openFileDialog1.ShowDialog();
            
            if (Result == System.Windows.Forms.DialogResult.OK)
            {

            }

            // TODO
            CurrentServer.EnqueueCommand(new SimpleOperation(String.Format("PUT {0}", "")));
        }

        public object FileImageGetter(object RowObject)
        {
            RemoteFileEntry File = (RemoteFileEntry)RowObject;

            return File.FileExtension.ToUpper();
        }

        public object FileSizeAspectGetter(object RowObject)
        {
            RemoteFileEntry RFE = (RemoteFileEntry)RowObject;
            if (RFE.FileExtension == ".FOLDER")
                return -1;

            return RFE.FileSize;
        }

        public string FileSizeAspectConverter(object Value)
        {
            int Size = (int)Value;
            if (Size == -1)
                return "Folder";

            int SuffixIndex = 0;

            while (Size > 1024)
            {
                Size /= 1024;
                SuffixIndex++;
            }

            return Size.ToString() + " " + FileSizeSuffixes[SuffixIndex];
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (CurrentServer != null && ((RemoteFileEntry)olvFiles.SelectedObject).Name != "..")
                CurrentServer.EnqueueCommand(new SimpleOperation(String.Format("DELETE {0}", ((RemoteFileEntry)olvFiles.SelectedObject).Filename)));
        }

        private void olvFiles_DoubleClick(object sender, EventArgs e)
        {
            RemoteFileEntry RFE = (RemoteFileEntry)olvFiles.SelectedObject;
            if (RFE != null)
                Text = RFE.Filename;

            if (RFE.FileSize == -1)
            {
                CurrentServer.EnqueueCommand(new DirOperation(RFE.Filename));
            }
            else
            {
                btnDownload_Click(null, null);
            }
        }

        private void SelectServer(object sender, EventArgs e)
        {
            CurrentServer = (RemoteServer)olvServers.SelectedObject;
            olvFiles.ClearObjects();
            lblCurrentFolder.Text = "";

            if (CurrentServer != null)
            {
                if (!string.IsNullOrWhiteSpace(CurrentServer.CurrentDirectory))
                {
                    olvFiles.SetObjects(CurrentServer.CurrentDirectoryFiles);
                    lblCurrentFolder.Text = CurrentServer.CurrentDirectory;
                }
            }
        }
    }
}
