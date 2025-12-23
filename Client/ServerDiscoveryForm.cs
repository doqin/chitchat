using Client.Extensions;
using Client.Properties;
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
                    flwLytPnlServers.Controls.RemoveAt(e.NewIndex + flwLytPnlServers.Controls.Count - serverList.Count - 1);
                    break;
                case ListChangedType.Reset:
                    Console.WriteLine("Server list reset.");
                    flwLytPnlServers.Controls.Clear();
                    foreach (Server server in ConfigManager.Current!.SavedServers)
                    {
                        AddServerControl(server, true);
                    }
                    break;
                default:
                    Console.WriteLine("Server list changed.");
                    break;
            }
        }

        private void AddServerControl(Server server, bool isUserCreated = false)
        {
            Console.WriteLine("Server added to the list.");
            var serverControl = new ServerControl();
            serverControl.ServerName = server.Name;
            serverControl.ServerAddress = $"{server.IPAddress}:{server.Port}";
            serverControl.Width = flwLytPnlServers.ClientSize.Width - 6; // Adjust width to fit within the panel
            
            if (isUserCreated)
            {
                serverControl.BorderColor = Color.FromArgb(113, 96, 232);
                serverControl.BackgroundColor = Color.FromArgb(240, 240, 255);
                serverControl.MouseOverBackColor = Color.FromArgb(230, 230, 255);
                serverControl.ActiveBorderColor = Color.FromArgb(90, 70, 200);
            } else
            {
                serverControl.BorderColor = Color.White;
                serverControl.BackgroundColor = Color.White;
                serverControl.MouseOverBackColor = Color.FromArgb(246, 245, 244);
            }
            //serverControl.BackgroundColor = Color.FromArgb(30, 30, 30);
            //serverControl.UseMouseOverBackColor = true;
            //serverControl.MouseOverBackColor = Color.FromArgb(50, 50, 50);
            //serverControl.ServerNameColor = Color.White;
            serverControl.Click += (s, args) =>
            {
                //serverControl.backgroundColor = Color.FromArgb(246, 245, 244);

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
                    chatForm.Dispose();
                    selectedServer = null;
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

                //splitContainerMain.Panel2.Controls.Clear();
                splitContainerMain.Panel2.Controls.Add(chatForm);
                chatForm.BringToFront();
                chatForm.Show();

                hostedChatForm = chatForm;
            };
            if (isUserCreated)
            {
                serverControl.CloseClick += (s, args) =>
                {
                    ConfigManager.Current!.SavedServers = ConfigManager.Current!.SavedServers
                        .Where(s => !(s.IPAddress == server.IPAddress && s.Port == server.Port))
                        .ToArray();
                    ConfigManager.Save();
                    flwLytPnlServers.Controls.Remove(serverControl);
                };
            }
            else
            {
                serverControl.CloseClick += (s, args) =>
                { 
                    serverList.Remove(server);
                };
            }
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
            SetListening(true);
            serverList.Clear();

            int udpPort = int.Parse(ConfigManager.Current!.UdpPort);
            Discoverer discoverer = new Discoverer(udpPort);
            discoverer.ListeningCompleted += (s, args) =>
            {
                SetListening(false);
            };
            discoverer.ListenForServer(serverList, timeoutMs);

            if (string.IsNullOrEmpty(ConfigManager.Current!.Username))
            {
                var loginForm = new LoginForm();
                var result = loginForm.ShowDialog();
            }
            picAvatar.Image = Helpers.GetProfilePicture();
        }

        private void SetListening(bool v)
        {
            loadingAnimationControl1.Invoke(() =>
            {
                loadingAnimationControl1.Visible = v;
                if (v)
                {
                    lblListening.Text = "Đang lắng nghe máy chủ";
                } else
                {
                    lblListening.Text = "Hoàn tất lắng nghe";
                }
            });
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
            SetListening(true);
            int udpPort = int.Parse(ConfigManager.Current!.UdpPort);
            Discoverer discoverer = new Discoverer(udpPort);
            discoverer.ListeningCompleted += (s, args) =>
            {
                SetListening(false);
            };
            discoverer.ListenForServer(serverList, timeoutMs);
        }

        private void pnlLeft_Paint(object sender, PaintEventArgs e)
        {
            using (Pen pen = new Pen(Color.FromArgb(222, 220, 218), 1))
            {
                // Draw a line at the right edge of pnlLeft
                e.Graphics.DrawLine(pen, pnlLeft.Width - 1, 0, pnlLeft.Width - 1, splitContainerMain.Height);
            }
        }

        private void updateSettings(object? sender, DialogResult res)
        {
            picAvatar.Image = Helpers.GetProfilePicture();
        }

        private void btnSettings_Click(object sender, EventArgs e)
        {
            Form settingsForm = new SettingsForm(updateSettings);
            settingsForm.StartPosition = FormStartPosition.CenterParent;
            settingsForm.ShowDialog();

        }

        private void searchControl1_TextChanged(object? sender, EventArgs e)
        {
            string searchText = searchControl1.Text.ToLower();
            flwLytPnlServers.Controls.Clear();
            foreach (Server server in ConfigManager.Current!.SavedServers)
            {
                if (server.Name.ToLower().Contains(searchText) || server.IPAddress.ToLower().Contains(searchText))
                {
                    AddServerControl(server, true);
                }
            }
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

        private void rndBtnCtrlAddServer_Click(object sender, EventArgs e)
        {
            AddServerForm addServerForm = new AddServerForm();
            addServerForm.StartPosition = FormStartPosition.CenterParent;
            DialogResult result = addServerForm.ShowDialog();
            if (result == DialogResult.OK)
            {
                flwLytPnlServers.Controls.Clear();
                foreach (Server server in ConfigManager.Current!.SavedServers)
                {
                    AddServerControl(server, true);
                }
                foreach (Server server in serverList)
                {
                    AddServerControl(server);
                }
            }
        }
    }
}