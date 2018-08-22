using ShopCart.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ShopCart
{
    public partial class Login : Form
    {
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;

        [DllImportAttribute("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd,
                         int Msg, int wParam, int lParam);
        [DllImportAttribute("user32.dll")]
        public static extern bool ReleaseCapture();
        SqlConnection conn;
        Users user;
        public Login()
        {
            InitializeComponent();
            conn = new SqlConnection("Data Source=DESKTOP-AJ8DB4G;" +"Initial Catalog=ShopCart;" +"Integrated Security=SSPI;");
            user = new Users();
        }
        private void bunifuImageButton1_Click(object sender, EventArgs e)
        {

            this.Close();
        }

        private void bunifuMaterialTextbox2_OnValueChanged(object sender, EventArgs e)
        {
            password_txt.isPassword = true;
        }

        private void Form2_Load(object sender, EventArgs e)
        {


        }
        public int _id
        {
            get { return 1; }
        }
        private void Form2_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }
        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Register reg = new Register();
            reg.Show();
            this.Hide();

        }
        private void sigin_btn_Click(object sender, EventArgs e)
        {
            if (!(email_txt.Text == "" || password_txt.Text == ""))
            {
                try
                {
                    string query = "SELECT * FROM [Users] WHERE Users_Email = '" + email_txt.Text + "'and Users_Password = '" + password_txt.Text + "'";
                    SqlDataAdapter sda = new SqlDataAdapter(query, conn);

                    DataTable dtbl = new DataTable();
                    sda.Fill(dtbl);

                    if (dtbl.Rows.Count == 1)
                    {
                        conn.Open();
                        using (SqlCommand cmd = new SqlCommand("Select Users_id from [Users] where  Users_Email = '" + email_txt.Text + "'and Users_Password = '" + password_txt.Text + "'", conn))
                        {
                            string id = cmd.ExecuteScalar().ToString();
                            user.Id = Convert.ToInt32(id);
                            Console.WriteLine(user.Id);
                            MainShop mshop = new MainShop();
                            mshop.user = user;
                            mshop.Show();
                            this.Hide();
                        }
                        if (remember_chk.Checked == true)
                        {
                            using (SqlCommand cmd2 = new SqlCommand("UPDATE [Users] SET Users_Status=@Users_Status WHERE Users_id=@Users_id", conn))
                            {
                                cmd2.Parameters.AddWithValue("@Users_id", user.Id);
                                cmd2.Parameters.AddWithValue("@Users_Status", 1);
                                cmd2.ExecuteNonQuery();
                                Application.Run(new MainShop());
                            }

                        }
                    }
                    else
                        Alert.Show("This User is Exists", Alert.AlertType.Error);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error:" + ex.Message);
                }
                finally
                {
                    conn.Close();
                }
            }
            else
                Alert.Show("Enter Data", Alert.AlertType.Error);
        }
        private void bunifuCheckbox1_OnChange(object sender, EventArgs e)
        {

        }

        private void bunifuImageButton2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

