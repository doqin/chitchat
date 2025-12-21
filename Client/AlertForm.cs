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

        public void showAlert(string msg, enmAlertType type, string avtPath = "")
        {
            this.Opacity = 0.0;
            this.StartPosition = FormStartPosition.Manual;
            string fname;

            for (int i = 1; i < 10; i++)
            {
                fname = "alert" + i.ToString();
                AlertForm frm = (AlertForm)Application.OpenForms[fname];

                if (frm == null)
                {
                    this.Name = fname;
                    this.x = Screen.PrimaryScreen.WorkingArea.Width - this.Width + 15;
                    this.y = Screen.PrimaryScreen.WorkingArea.Height - this.Height * i - 5 * i;
                    this.Location = new Point(this.x, this.y);
                    break;

                }

            }
            this.x = Screen.PrimaryScreen.WorkingArea.Width - base.Width - 5;

            switch (type)
            {
                case enmAlertType.Success:
                    this.ptrbxAlertType.Image = Resources.success_button;
                    this.BackColor = Color.SeaGreen;
                    break;
                case enmAlertType.Error:
                    this.ptrbxAlertType.Image = Resources.error_button;
                    this.BackColor = Color.DarkRed;
                    break;
                case enmAlertType.Info:
                    this.ptrbxAlertType.Image = string.IsNullOrEmpty(avtPath) ? Resources.info_button : Image.FromFile(avtPath);
                    break;
                case enmAlertType.Warning:
                    this.ptrbxAlertType.Image = Resources.warning_button;
                    this.BackColor = Color.DarkOrange;
                    break;
            }


            this.label1.Text = msg;

            this.Show();
            this.action = enmAlertAction.Start;
            this.timer1.Interval = 1;
            this.timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            switch (this.action)
            {
                case enmAlertAction.Wait:
                    timer1.Interval = 5000;
                    action = enmAlertAction.Close;
                    break;
                case AlertForm.enmAlertAction.Start:
                    this.timer1.Interval = 1;
                    this.Opacity += 0.1;
                    if (this.x < this.Location.X)
                    {
                        this.Left--;
                    }
                    else
                    {
                        if (this.Opacity == 1.0)
                        {
                            action = AlertForm.enmAlertAction.Wait;
                        }
                    }
                    break;
                case enmAlertAction.Close:
                    timer1.Interval = 1;
                    this.Opacity -= 0.1;

                    this.Left -= 3;
                    if (base.Opacity == 0.0)
                    {
                        base.Close();
                    }
                    break;
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void ptrbxAlertType_Click(object sender, EventArgs e)
        {
            base.Close();
        }

        private void ptrbxAlertType_MouseHover(object sender, EventArgs e)
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
        private void ptrbxCloseButton_MouseMove(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.Hand;
        }

        private void ptrbxCloseButton_MouseClick(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.Default;
            base.Close();
        }
        private void panel2_MouseMove(object sender, MouseEventArgs e)
        {
            Cursor.Current = Cursors.Hand;
        }

        private void panel2_MouseLeave(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.Default;
        }
    }
}
