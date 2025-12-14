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
        private Server selectedServer;
        private AlertForm alertForm;

        // keep these as fields so other methods can access them

        public ServerDiscoveryForm()
        {
            InitializeComponent();
            this.KeyPreview = true;
            serverList.ListChanged += ServerList_ListChanged;
            searchControl1.TextChanged += searchControl1_TextChanged;

            // create shared controls once and reuse
        }

        private void ServerList_ListChanged(object? sender, ListChangedEventArgs e)
        {
            switch (e.ListChangedType)
            {
                case ListChangedType.ItemAdded:
                    AddServerControl(serverList[e.NewIndex]);
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

        private void AddServerControl(Server server)
        {
            Console.WriteLine("Server added to the list.");
            var serverControl = new ServerControl();
            serverControl.ServerName = server.Name;
            serverControl.ServerAddress = $"{server.IPAddress}:{server.Port}";
            serverControl.Width = flwLytPnlServers.ClientSize.Width - 6; // Adjust width to fit within the panel
            serverControl.BackgroundColor = Color.White;
            serverControl.BorderColor = Color.White;
            serverControl.MouseOverBackColor = Color.FromArgb(246, 245, 244);
            //serverControl.BackgroundColor = Color.FromArgb(30, 30, 30);
            //serverControl.UseMouseOverBackColor = true;
            //serverControl.MouseOverBackColor = Color.FromArgb(50, 50, 50);
            //serverControl.ServerNameColor = Color.White;
            serverControl.Click += (s, args) =>
            {
                serverControl.backgroundColor = Color.FromArgb(246, 245, 244);

                // Dispose any previously hosted chat
                if (selectedServer != null)
                {
                    if (selectedServer?.IPAddress == server?.IPAddress && selectedServer?.Port == server?.Port)
                    {
                        // Already hosting this chat, do nothing
                        return;
                    }
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

                selectedServer = server;

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

                chatForm.FormClosed += ChatForm_FormClosed;
                chatForm.TopLevel = false;
                chatForm.FormBorderStyle = FormBorderStyle.None;
                chatForm.Dock = DockStyle.Fill;
                AddMouseDownToLoseFocusExternal(this, chatForm);
                AddMouseDownToLoseFocus(this);


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
        }

        private void ChatForm_FormClosed(object? sender, FormClosedEventArgs e)
        {
            hostedChatForm = null;
            selectedServer = null;
        }

        private void ServerDiscoveryForm_Load(object sender, EventArgs e)
        {
            //Extensions.DarkMode.EnableDarkTitleBar(this);
            serverList.Clear();
            Cursor.Current = Cursors.WaitCursor;

            int udpPort = int.Parse(ConfigManager.Current!.UdpPort);
            Discoverer discoverer = new Discoverer(udpPort);
            discoverer.ListenForServer(serverList, timeoutMs);
            Cursor.Current = Cursors.Default;

            if (string.IsNullOrEmpty(ConfigManager.Current!.Username))
            {
                var loginForm = new LoginForm();
                var result = loginForm.ShowDialog();
            }
            if (!string.IsNullOrEmpty(ConfigManager.Current!.ProfileImagePath) && Path.Exists(Path.Combine("Cached", ConfigManager.Current!.ProfileImagePath)))
            {
                picAvatar.Image = Image.FromFile(Path.Combine("Cached", ConfigManager.Current!.ProfileImagePath));
            }
            else
            {
                picAvatar.OutlineWidth = 2;
                picAvatar.OutlineColor = Color.FromArgb(222, 220, 218);
            }
        }

        private void splitContainerMain_Paint(object sender, PaintEventArgs e)
        {
            using (Pen pen = new Pen(Color.FromArgb(222, 220, 218), 1))
            {
                // Draw a line at the splitter
                e.Graphics.DrawLine(pen, splitContainerMain.SplitterDistance, 0, splitContainerMain.SplitterDistance, splitContainerMain.Height);
            }
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

        private void pnlLeft_Paint(object sender, PaintEventArgs e)
        {
            using (Pen pen = new Pen(Color.FromArgb(222, 220, 218), 1))
            {
                // Draw a line at the right edge of pnlLeft
                e.Graphics.DrawLine(pen, pnlLeft.Width - 1, 0, pnlLeft.Width - 1, splitContainerMain.Height);
            }
        }

        private void updateSettings(object? sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(ConfigManager.Current!.ProfileImagePath) && Path.Exists(Path.Combine("Cached", ConfigManager.Current!.ProfileImagePath)))
            {
                picAvatar.Image = Image.FromFile(Path.Combine("Cached", ConfigManager.Current!.ProfileImagePath));
            }
        }

        private void btnSettings_Click(object sender, EventArgs e)
        {
            Form settingsForm = new SettingsForm(updateSettings);
            settingsForm.StartPosition = FormStartPosition.CenterParent;
            DialogResult result = settingsForm.ShowDialog();
        }

        private void searchControl1_TextChanged(object? sender, EventArgs e)
        {
            string searchText = searchControl1.Text.ToLower();
            flwLytPnlServers.Controls.Clear();
            foreach (var server in serverList)
            {
                if (server.Name.ToLower().Contains(searchText) || server.IPAddress.ToLower().Contains(searchText))
                {
                    AddServerControl(server);
                }
            }
        }

        private void AddMouseDownToLoseFocus(Control parent)
        {
            // Loại trừ các control nhập liệu
            if (!(parent is TextBox) && !(parent is Button))
            {
                parent.MouseDown += (s, e) =>
                {
                    this.ActiveControl = null; // bỏ focus
                };
            }

            foreach (Control c in parent.Controls)
            {
                AddMouseDownToLoseFocus(c);
            }
        }


        private void AddMouseDownToLoseFocusExternal(Control parent, ChatForm chatForm)
        {
            // Đăng ký MouseDown cho control hiện tại
            parent.MouseDown += (s, e) =>
            {
                chatForm.ActiveControl = null;
            };

            // Đệ quy cho tất cả control con
            foreach (Control c in parent.Controls)
            {
                AddMouseDownToLoseFocusExternal(c, chatForm);
            }
        }
    }
}