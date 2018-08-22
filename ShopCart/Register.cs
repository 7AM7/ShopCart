using ShopCart.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ShopCart
{
    public partial class Register : Form
    {
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;
        [DllImportAttribute("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd,
                         int Msg, int wParam, int lParam);
        [DllImportAttribute("user32.dll")]
        public static extern bool ReleaseCapture();
        byte[] photo_aray;
        SqlCommand cmd;
        string gender;
        SqlConnection conn;
        DataHelpers DataHelp;
        public Register()
        {
            InitializeComponent();
            DataHelp = new DataHelpers();
           conn  = new SqlConnection("Data Source=DESKTOP-AJ8DB4G;" +"Initial Catalog=ShopCart;" +"Integrated Security=SSPI;");
        }


        private void Registerr_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        private void bunifuImageButton1_Click(object sender, EventArgs e)
        {
            Login login = new Login();
            login.Show();
            this.Hide();

        }
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "jpeg|*.jpg|bmp|*.bmp|png|*.png|all files|*.*";
            DialogResult res = openFileDialog1.ShowDialog();
            if (res == DialogResult.OK)
            {
                pictureBox1.Image = Image.FromFile(openFileDialog1.FileName);
            }

        }

        private void sigin_btn_Click(object sender, EventArgs e)
        {
            if (genderlist.selectedIndex == 0)
                gender = genderlist.selectedValue;
            else if (genderlist.selectedIndex == 1)
                gender = genderlist.selectedValue;

            if (!(Fname_txt.Text == "" || password_txt.Text == "" || email_txt.Text == "" || Phone_txt.Text == "" ))
            {
                try
                {
                    string query = "SELECT * FROM Users WHERE Users_Email = '" + Fname_txt.Text + "' ";
                    SqlDataAdapter sda = new SqlDataAdapter(query, conn);
                    DataTable dtbl = new DataTable();
                    sda.Fill(dtbl);

                    if (dtbl.Rows.Count < 1)
                    {
                        conn.Open();
                        cmd = new SqlCommand("INSERT INTO Users(Users_FullName,Users_Password,Users_Email,Users_BirthDay,Users_Country,Users_City,Users_Gender,Users_RigsterDate,Users_Image,Users_Phone)" +
                            " VALUES (@Users_FullName,@Users_Password,@Users_Email,@Users_BirthDay,@Users_Country,@Users_City,@Users_Gender,@Users_RigsterDate,@Users_Image,@Users_Phone)", conn);
                        cmd.Parameters.AddWithValue("@Users_FullName", Fname_txt.Text);
                        cmd.Parameters.AddWithValue("@Users_Password", password_txt.Text);
                        cmd.Parameters.AddWithValue("@Users_Email", email_txt.Text);
                        cmd.Parameters.AddWithValue("@Users_BirthDay", birthday_date.Value);
                        cmd.Parameters.AddWithValue("@Users_Country", country_txt.Text);
                        cmd.Parameters.AddWithValue("@Users_City", city_txt.Text);
                        cmd.Parameters.AddWithValue("@Users_Phone", Phone_txt.Text);
                        cmd.Parameters.AddWithValue("@Users_Gender", gender);
                        cmd.Parameters.AddWithValue("@Users_RigsterDate", DateTime.Now);
                        photo_aray = DataHelp.ImageToByte2(pictureBox1.Image);
                        if (photo_aray != null)
                        {
                            cmd.Parameters.AddWithValue("@Users_Image", photo_aray);
                        }
                        cmd.ExecuteNonQuery();
                        Alert.Show("SignUp Successfully", Alert.AlertType.Success);
                       
                    }

                    else
                        Alert.Show("User Exits", Alert.AlertType.Error);
                   
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error:" + ex.Message);
                    Console.WriteLine(ex.Message);
                }
                finally
                {
                    conn.Close();
                   
                }
            }
            else
                Alert.Show("Enter Data", Alert.AlertType.Error);
        }

        private void password_txt_OnValueChanged(object sender, EventArgs e)
        {
            password_txt.isPassword = true;
            string pass = CheckingPasswordStrength(password_txt.Text).ToString();
            if (pass == "Blank" || pass == "VeryWeak" || pass == "Weak")
                chkLabel.ForeColor = Color.Yellow;
            else if (pass == "Medium")
                chkLabel.ForeColor = Color.Orange;
            else if (pass == "Strong" || pass == "VeryStrong")
                chkLabel.ForeColor = Color.Red;
            chkLabel.Text = pass;
            chkLabel.Visible = true;
        }

        private void email_txt_OnValueChanged(object sender, EventArgs e)
        {
            System.Text.RegularExpressions.Regex rEmail = new System.Text.RegularExpressions.Regex(@"^[a-zA-Z][\w\.-]*[a-zA-Z0-9]@[a-zA-Z0-9][\w\.-]*[a-zA-Z0-9]\.[a-zA-Z][a-zA-Z\.]*[a-zA-Z]$");
            if (email_txt.Text.Length > 0)
            {
                if (!rEmail.IsMatch(email_txt.Text))
                {
                    label2.Text = "Email Not Validating";
                    sigup_btn.Enabled = false;
                }
                else
                {
                    label2.ForeColor = Color.Green;
                    sigup_btn.Enabled = true;
                    label2.Text = "Email is Validating";
                }
                label2.Visible = true;
            }
        }
        enum PasswordScore
        {
            Blank = 0,
            VeryWeak = 1,
            Weak = 2,
            Medium = 3,
            Strong = 4,
            VeryStrong = 5
        }
        private static PasswordScore CheckingPasswordStrength(string password)
        {
            int score = 1;
            if (password.Length < 1)
                return PasswordScore.Blank;
            if (password.Length < 4)
                return PasswordScore.VeryWeak;
            if (password.Length >= 8)
                score++;
            if (password.Length >= 12)
                score++;
            if (Regex.IsMatch(password, @"[0-9]+(\.[0-9][0-9]?)?", RegexOptions.ECMAScript))      //number only //"^\d+$" if you need to match more than one digit.
                score++;
            if (Regex.IsMatch(password, @"^(?=.*[a-z])(?=.*[A-Z]).+$", RegexOptions.ECMAScript)) //both, lower and upper case
                score++;
            if (Regex.IsMatch(password, @"[!,@,#,$,%,^,&,*,?,_,~,-,L,(,)]", RegexOptions.ECMAScript)) //^[A-Z]+$
                score++;
            return (PasswordScore)score;
        }
    }

}
