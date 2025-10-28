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

        public ServerDiscoveryForm()
        {
            InitializeComponent();
            this.KeyPreview = true;
            lsbxServers.DataSource = serverList;
        }

        public void btnDiscoverServer_Click(object sender, EventArgs e)
        {
            serverList.Clear();
            Cursor.Current = Cursors.WaitCursor;
            int udpPort = int.Parse(tbxPort.Text);
            Discoverer discoverer = new Discoverer(udpPort);
            discoverer.ListenForServer(serverList, timeoutMs);
            Cursor.Current = Cursors.Default;
        }

        public void lsbxServers_DoubleClick(object sender, EventArgs e)
        {
            if (lsbxServers.SelectedItem == null)
            {
                Console.WriteLine("Selected item is null.");
                return;
            }

            Server selectedServer = (Server)lsbxServers.SelectedItem;
            Console.WriteLine($"Selected server: {selectedServer}");

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

            // Create ChatForm and embed into the right panel of the SplitContainer.
            // NOTE: your designer's SplitContainer name may be `splitContainer1` (used below)
            // change to `splitContainerMain` if you named it that in the designer.
            ChatForm chatForm = new ChatForm(txtbxUsername.Text, selectedServer.Name, selectedServer.IPAddress, selectedServer.Port);

            // If ChatForm constructor signaled Abort (couldn't connect), do not host it
            if (chatForm.DialogResult == DialogResult.Abort)
            {
                // Optionally refresh the server list UI
                lsbxServers.Items.Clear();
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
        }

        private void ServerDiscoveryForm_Load(object sender, EventArgs e)
        {

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

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
