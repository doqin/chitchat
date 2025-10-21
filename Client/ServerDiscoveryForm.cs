namespace Client
{
    public partial class ServerDiscoveryForm : Form
    {

        private readonly int timeoutMs = 10000;

        public ServerDiscoveryForm()
        {
            InitializeComponent();
        }

        public void btnDiscoverServer_Click(object sender, EventArgs e)
        {
            lsbxServers.Items.Clear();
            Cursor.Current = Cursors.WaitCursor;
            int udpPort = int.Parse(tbxPort.Text);
            Discoverer discoverer = new Discoverer(udpPort);
            var server = discoverer.ListenForServer(timeoutMs);
            if (server != null)
            {
                lsbxServers.Items.Add($"{server?.ip}:{server?.port}");
            }
            else
            {
                MessageBox.Show("No server found.");
            }
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

        private void ServerDiscoveryForm_Load(object sender, EventArgs e)
        {

        }
    }
}
