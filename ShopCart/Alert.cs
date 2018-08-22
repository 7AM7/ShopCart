using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ShopCart
{
    public partial class Alert : Form
    {
        public Alert(string message,AlertType type)
        {
            InitializeComponent();
            label1.Text = message;
            switch(type)
            {
                case AlertType.Success:
                    this.BackColor = Color.SeaGreen;
                    icon.Image = imageList1.Images[0];
                    break;
                case AlertType.Info:
                    this.BackColor = Color.Gray;
                    icon.Image = imageList1.Images[1];
                    break;
                case AlertType.Waring:
                    this.BackColor = Color.FromArgb(255, 138, 0);
                    icon.Image = imageList1.Images[1];
                    break;
                case AlertType.Error:
                    this.BackColor = Color.Red;
                    icon.Image = imageList1.Images[2];
                    break;
            }
        }
        public static void Show(string message, AlertType type)
        {
            new Alert(message,type).Show();
        }
        public enum AlertType
        {
            Success,Info,Waring,Error
        }

        private void Alert_Load(object sender, EventArgs e)
        {
            this.Top = -1 * (this.Height);
            this.Left = Screen.PrimaryScreen.Bounds.Width - this.Width - 60;
            show.Start();
        }

        private void Close_btn_Click(object sender, EventArgs e)
        {
            close.Start();
        }

        private void hidee_Tick(object sender, EventArgs e)
        {
            this.Close();
        }
        int interval = 0;
        private void show_Tick(object sender, EventArgs e)
        {
            if(this.Top<60)
            {
                this.Top += interval;
                interval += 2;
            }
            else
            {
                show.Stop();
            }
        }

        private void close_Tick(object sender, EventArgs e)
        {
            if (this.Opacity > 0)
            {
                this.Opacity-=0.1;
            }
            else { this.Close(); }
        }
    }
}
