using System.ComponentModel;

namespace Client
{
    public partial class ServerDiscoveryForm : Form
    {

        private readonly int timeoutMs = 10000;
        private BindingList<string> serverList = new BindingList<string>();

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
                string[] parts = lsbxServers.SelectedItem.ToString().Split(':');
                Application.OpenForms["ChatForm"]?.Close();
                ChatForm chatForm = new ChatForm(txtbxUsername.Text, parts[0], int.Parse(parts[1]));
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
    }
}
