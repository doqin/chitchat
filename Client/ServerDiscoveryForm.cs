using Protocol;
using System.ComponentModel;
using System.Windows.Forms;

namespace Client
{
    public partial class ServerDiscoveryForm : Form
    {

        private readonly int timeoutMs = 10000;
        private BindingList<Server> serverList = new BindingList<Server>();

        private ChatForm? hostedChatForm;

        // keep these as fields so other methods can access them

        public ServerDiscoveryForm()
        {
            InitializeComponent();
            this.KeyPreview = true;
            serverList.ListChanged += ServerList_ListChanged;
            // create shared controls once and reuse
        }

        private void ServerList_ListChanged(object? sender, ListChangedEventArgs e)
        {
            switch (e.ListChangedType)
            {
                case ListChangedType.ItemAdded:
                    Console.WriteLine("Server added to the list.");
                    var serverControl = new ServerControl();
                    serverControl.ServerName = serverList[e.NewIndex].Name;
                    serverControl.ServerAddress = serverList[e.NewIndex].IPAddress;
                    serverControl.Width = flwLytPnlServers.ClientSize.Width - 6; // Adjust width to fit within the panel
                    serverControl.BackgroundColor = Color.FromArgb(30, 30, 30);
                    serverControl.UseMouseOverBackColor = true;
                    serverControl.MouseOverBackColor = Color.FromArgb(50, 50, 50);
                    serverControl.ServerNameColor = Color.White;
                    serverControl.Click += (s, args) =>
                    {
                        
                        // Dispose any previously hosted chat
                        if (hostedChatForm != null)
                        {
                            try
                            {
                                hostedChatForm.Close();
                            }
                            catch { }
                            try
                            {
                                hostedChatForm.Dispose();
                            }
                            catch { }
                            hostedChatForm = null;
                        }

                        Server selectedServer = serverList[e.NewIndex];

                        // Create ChatForm and embed into the right panel of the SplitContainer.
                        // NOTE: your designer's SplitContainer name may be `splitContainer1` (used below)
                        // change to `splitContainerMain` if you named it that in the designer.
                        ChatForm chatForm = new ChatForm(ConfigManager.Current!.Username, selectedServer.Name, selectedServer.IPAddress, selectedServer.Port, ConfigManager.Current!.ProfileImagePath);

                        // If ChatForm constructor signaled Abort (couldn't connect), do not host it
                        if (chatForm.DialogResult == DialogResult.Abort)
                        {
                            // Optionally refresh the server list UI
                            flwLytPnlServers.Controls.Clear();
                            chatForm.Dispose();
                            return;
                        }

                        chatForm.TopLevel = false;
                        chatForm.FormBorderStyle = FormBorderStyle.None;
                        chatForm.Dock = DockStyle.Fill;

                        // Ensure the split container exists in the designer; adjust name if necessary
                        if (splitContainerMain == null)
                        {
                            // fallback behaviour: show as a normal window if the split container isn't found
                            chatForm.Show();
                            hostedChatForm = chatForm;
                            return;
                        }

                        splitContainerMain.Panel2.Controls.Clear();
                        splitContainerMain.Panel2.Controls.Add(chatForm);
                        chatForm.Show();

                        hostedChatForm = chatForm;
                    };
                    flwLytPnlServers.Controls.Add(serverControl);
                    break;
                case ListChangedType.ItemDeleted:
                    Console.WriteLine("Server removed from the list.");
                    flwLytPnlServers.Controls.RemoveAt(e.NewIndex);
                    break;
                case ListChangedType.Reset:
                    Console.WriteLine("Server list reset.");
                    flwLytPnlServers.Controls.Clear();
                    break;
                default:
                    Console.WriteLine("Server list changed.");
                    break;
            }
        }

        private void ServerDiscoveryForm_Load(object sender, EventArgs e)
        {
            Extensions.DarkMode.EnableDarkTitleBar(this);
            serverList.Clear();
            Cursor.Current = Cursors.WaitCursor;

            int udpPort = int.Parse(ConfigManager.Current!.UdpPort);
            Discoverer discoverer = new Discoverer(udpPort);
            discoverer.ListenForServer(serverList, timeoutMs);
            Cursor.Current = Cursors.Default;
        }

        private void splitContainerMain_Panel2_Paint(object sender, PaintEventArgs e)
        {

        }
        private void ServerDiscoveryForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                var result = MessageBox.Show("Bạn có chắc muốn thoát không?",
                                             "Xác nhận thoát",
                                             MessageBoxButtons.YesNo,
                                             MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    Application.Exit();
                }
            }
        }

        private void ServerDiscoveryForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            // Clean up hosted chat form if it exists
            if (hostedChatForm != null)
            {
                try
                {
                    hostedChatForm.Close();
                }
                catch { }
                try
                {
                    hostedChatForm.Dispose();
                }
                catch { }
                hostedChatForm = null;
            }

            // Exit the application when this form closes
            Application.Exit();
        }

        private void roundButtonControl1_Click(object sender, EventArgs e)
        {
            serverList.Clear();
            Cursor.Current = Cursors.WaitCursor;

            int udpPort = int.Parse(ConfigManager.Current!.UdpPort);
            Discoverer discoverer = new Discoverer(udpPort);
            discoverer.ListenForServer(serverList, timeoutMs);
            Cursor.Current = Cursors.Default;
        }
    }
}
