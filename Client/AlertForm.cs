using Client.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Client
{
    public partial class AlertForm : Form
    {
        private AlertForm.enmAlertAction action;
        private int x, y;
        private int padding;

        public AlertForm()
        {
            InitializeComponent();
        }

        public enum enmAlertType
        {
            Info,
            Warning,
            Error,
            Success
        }

        public enum enmAlertAction
        {
            Wait,
            Start,
            Close
        }

        public void showAlert(string msg, enmAlertType type)
        {
            this.StartPosition = FormStartPosition.Manual;
            this.padding = (int)(0.01 * Screen.PrimaryScreen!.WorkingArea.Height);

            this.x = Screen.PrimaryScreen.WorkingArea.Width - this.Width - padding;
            this.y = Screen.PrimaryScreen.WorkingArea.Height - this.Height - padding;

            System.Diagnostics.Debug.WriteLine($"x = {x}, y = {y}");
            this.Location = new Point(this.x, this.y);
            switch (type)
            {
                case (enmAlertType.Info):
                    this.BackColor = Color.DodgerBlue;
                    this.ptrbxAlertType.Image = Resources.info_button;
                    break;
                case (enmAlertType.Warning):
                    this.BackColor = Color.LightYellow;
                    this.ptrbxAlertType.Image = Resources.warning_button;
                    break;
                case (enmAlertType.Error):
                    this.BackColor = Color.Red;
                    this.ptrbxAlertType.Image = Resources.error_button;
                    break;
                case (enmAlertType.Success):
                    this.BackColor = Color.Green;
                    this.ptrbxAlertType.Image = Resources.success_button;
                    break;
                default:
                    break;
            }

            this.label1.Text = msg != "" ? msg : "nothing here";

            this.Show();
            this.action = enmAlertAction.Start;
            this.timer1.Interval = 1;
            this.timer1.Start();
        }

        public void timer1_Tick(object sender, EventArgs e)
        {
            switch (this.action)
            {
                case (enmAlertAction.Wait):
                    timer1.Interval = 5000;
                    this.action = enmAlertAction.Close;
                    break;
                case (enmAlertAction.Start):
                    timer1.Interval = 1;
                    this.action = enmAlertAction.Wait;
                    break;
                case (enmAlertAction.Close):
                    timer1.Interval = 1;
                    base.Close();
                    break;
                default:
                    break;
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            base.Close();
        }

        private void pictureBox1_MouseHover(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.Hand;
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel2_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.Default;
            base.Close();
        }

        private void panel2_MouseHover(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.Hand;
        }

        private void pictureBox1_MouseEnter(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.Hand;
        }

        private void panel2_MouseEnter(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.Hand;
        }

        private void panel2_MouseMove(object sender, MouseEventArgs e)
        {
            Cursor.Current = Cursors.Hand;
        }

        private void panel2_MouseLeave(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.Default;
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            Cursor.Current = Cursors.Hand;
        }
    }
}
