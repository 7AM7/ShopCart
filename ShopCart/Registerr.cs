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

namespace WindowsFormsApp1
{
    public partial class Registerr : Form
    {
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;

        [DllImportAttribute("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd,
                         int Msg, int wParam, int lParam);
        [DllImportAttribute("user32.dll")]
        public static extern bool ReleaseCapture();
        byte[] photo_aray;
        byte[] photo_arrayCover;
        SqlCommand cmd;
        string gender;
        SqlConnection conn = new SqlConnection(
                "Data Source=DESKTOP-AJ8DB4G;" +
                "Initial Catalog=Users;" +
                "Integrated Security=SSPI;");
        public Registerr()
        {
            InitializeComponent();
        }

        private void bunifuCustomLabel1_Click(object sender, EventArgs e)
        {

        }

        private void usrname_txt_OnValueChanged(object sender, EventArgs e)
        {

        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void bunifuCustomLabel4_Click(object sender, EventArgs e)
        {

        }

        private void bunifuDropdown1_onItemSelected(object sender, EventArgs e)
        {

        }

        private void Registerr_Load(object sender, EventArgs e)
        {

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
            this.Visible = false;
            new Form2().ShowDialog();
            this.Close();
        }

        private void bunifuImageButton2_Click(object sender, EventArgs e)
        {

        }
        public byte[] ImageToByte2(Image img)
        {
            byte[] byteArray = new byte[0];
            using (MemoryStream stream = new MemoryStream())
            {
                img.Save(stream, System.Drawing.Imaging.ImageFormat.Png);
                stream.Close();

                byteArray = stream.ToArray();
            }
            return byteArray;
        }
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            pictureBox1.Image = null;
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
            else if(genderlist.selectedIndex == 1)
                gender = genderlist.selectedValue;
            if (!(usrname_txt.Text == "" || password_txt.Text == "" || email_txt.Text == "" || Fname_txt.Text == "" || Sname_txt.Text == ""))
            {
                try
                {
                        string query = "SELECT * FROM UserData WHERE Username = '" + usrname_txt.Text + "' ";
                        SqlDataAdapter sda = new SqlDataAdapter(query, conn);
                        DataTable dtbl = new DataTable();
                        sda.Fill(dtbl);

                        if (dtbl.Rows.Count < 1)
                        {
                            conn.Open();
                            cmd = new SqlCommand("INSERT INTO UserData(Username,Password,Email,FirstName,SecondName,Birthday,Country,City,Gender,RegisterDate,ProfileImage,WorkAt,PhoneNumber,Status,CoverImage) VALUES (@Username,@Password,@Email,@FirstName,@SecondName,@Birthday,@Country,@City,@Gender,@RegisterDate,@ProfileImage,@WorkAt,@PhoneNumber,@Status,@CoverImage)", conn);
                            cmd.Parameters.AddWithValue("@Username", usrname_txt.Text);
                            cmd.Parameters.AddWithValue("@Password", password_txt.Text);
                            cmd.Parameters.AddWithValue("@Email", email_txt.Text);
                            cmd.Parameters.AddWithValue("@FirstName", Fname_txt.Text);
                            cmd.Parameters.AddWithValue("@SecondName", Sname_txt.Text);
                            cmd.Parameters.AddWithValue("@Birthday", birthday_date.Value);
                            cmd.Parameters.AddWithValue("@Country", country_txt.Text);
                            cmd.Parameters.AddWithValue("@City", city_txt.Text);
                        cmd.Parameters.AddWithValue("@WorkAt", "");
                        cmd.Parameters.AddWithValue("@Status", "");
                        cmd.Parameters.AddWithValue("@PhoneNumber", "");
                        
                        cmd.Parameters.AddWithValue("@Gender", gender);
                            cmd.Parameters.AddWithValue("@RegisterDate", DateTime.Now);
                            photo_aray = ImageToByte2(pictureBox1.Image);
                            cmd.Parameters.AddWithValue("@ProfileImage", photo_aray);
                        photo_arrayCover = ImageToByte2(Properties.Resources.Untitleds);
                        cmd.Parameters.AddWithValue("@CoverImage", photo_arrayCover);
                        cmd.ExecuteNonQuery();
                            MessageBox.Show("SignUp Successfully", "Done", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }

                        else
                            MessageBox.Show("This User is Exists....!", "Erorr!", MessageBoxButtons.OK, MessageBoxIcon.Error);

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
                MessageBox.Show("Enter The Data First !", "Erorr!", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void password_txt_OnValueChanged(object sender, EventArgs e)
        {
            password_txt.isPassword = true;
            string x = CheckingPasswordStrength(password_txt.Text).ToString();
            if (x == "Blank" || x == "VeryWeak" || x == "Weak")
                label1.ForeColor = Color.Yellow;
            else if (x == "Medium")
                label1.ForeColor = Color.Orange;
            else if (x == "Strong" || x == "VeryStrong")
                label1.ForeColor = Color.Red;
            label1.Text = x;
            label1.Visible = true;
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }
        public static bool IsValidPassword(string input)
        {

            System.Text.RegularExpressions.Regex match = new System.Text.RegularExpressions.Regex(@"(?!^[0-9]*$)(?!^[a-zA-Z]*$)^([a-zA-Z0-9]{8,10})$");
            if (match.IsMatch(input))
                return true;
            else
                return false;

        }
        private void email_txt_Validating(object sender, CancelEventArgs e)
        {

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

        private void email_txt_OnValueChanged(object sender, EventArgs e)
        {
            System.Text.RegularExpressions.Regex rEmail = new System.Text.RegularExpressions.Regex(@"^[a-zA-Z][\w\.-]*[a-zA-Z0-9]@[a-zA-Z0-9][\w\.-]*[a-zA-Z0-9]\.[a-zA-Z][a-zA-Z\.]*[a-zA-Z]$");
            if (email_txt.Text.Length > 0)
            {
                if (!rEmail.IsMatch(email_txt.Text))
                {
                    label2.Text = "Email Not Validating";
                    
                   // MessageBox.Show("Please provide valid email address", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    //email_txt.Focus();
                }
                else
                {
                    label2.ForeColor = Color.Green;

                    label2.Text = "Email is Validating";
                }
                label2.Visible = true;
            }
        }
    }

}
