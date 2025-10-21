using Protocol;
using System.ComponentModel;

namespace Client
{
    public partial class ServerDiscoveryForm : Form
    {

        private readonly int timeoutMs = 10000;
        private BindingList<Server> serverList = new BindingList<Server>();

        public ServerDiscoveryForm()
        {
            InitializeComponent();
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
            if (lsbxServers.SelectedItem != null)
            {
                Console.WriteLine($"Selected server: {lsbxServers.SelectedItem}");
                Server selectedServer = (Server)lsbxServers.SelectedItem;
                Application.OpenForms["ChatForm"]?.Close();
                ChatForm chatForm = new ChatForm(txtbxUsername.Text, selectedServer.Name, selectedServer.IPAddress, selectedServer.Port);
                if (chatForm.DialogResult == DialogResult.Abort)
                {
                    lsbxServers.Items.Clear();
                }
                else
                {
                    chatForm.Show();
                }
            }
            else
            {
                Console.WriteLine("Selected item is null.");
            }
        }

        private void ServerDiscoveryForm_Load(object sender, EventArgs e)
        {

        }
    }
}
