using ShopCart.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ShopCart
{
    public partial class AdminPage : Form
    {
        Dictionary<int, string> classes = new Dictionary<int, string>();
        SqlConnection conn;
        byte[] photo_aray;
        SqlCommand cmd;
        DataHelpers dth;
        public AdminPage()
        {
            InitializeComponent();
            classes.Add(1, "Electronics");
            classes.Add(2, "Clothes");
            classes.Add(3, "Houseware");
            classes.Add(4, "Others");
            conn = new SqlConnection("Data Source=DESKTOP-AJ8DB4G;" + "Initial Catalog=ShopCart;" + "Integrated Security=SSPI;");
            dth = new DataHelpers();
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

        private void AdminPage_Load(object sender, EventArgs e)
        {
            foreach (var item in classes)
            {
                classeslist.AddItem(item.Value);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string query = "SELECT * FROM [Proudects] WHERE Proudects_Name = '" + textBox1.Text + "' ";
                SqlDataAdapter sda = new SqlDataAdapter(query, conn);
                DataTable dtbl = new DataTable();
                sda.Fill(dtbl);

                if (dtbl.Rows.Count < 1)
                {
                    conn.Open();
                    cmd = new SqlCommand("INSERT INTO Proudects(Proudects_Name,Proudects_Price,Proudects_Photo,Proudects_Description,classes_id) VALUES(@Proudects_Name,@Proudects_Price,@Proudects_Photo,@Proudects_Description,@classes_id)", conn);
                    cmd.Parameters.AddWithValue("@Proudects_Name", textBox1.Text);
                    cmd.Parameters.AddWithValue("@Proudects_Price", Convert.ToDouble(textBox2.Text));
                    cmd.Parameters.AddWithValue("@Proudects_Description", textBox3.Text);
                    cmd.Parameters.AddWithValue("@classes_id", classeslist.selectedIndex + 1);
                    photo_aray = dth.ImageToByte2(pictureBox1.Image);
                    cmd.Parameters.AddWithValue("@Proudects_Photo", photo_aray);
                    cmd.ExecuteNonQuery();
                    Alert.Show("Successfully", Alert.AlertType.Success);
                    //MessageBox.Show("SignUp Successfully", "Done", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
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
    }
}
