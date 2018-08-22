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
using testexListBox;

namespace ShopCart
{
    public partial class MainShop : Form
    {
        int idd = 1;
        SqlConnection conn;
        public Users user { get; set; }
        Proudects prd;
        byte[] photo_aray;
        DataHelpers dth;
        Orders ord;
        string Srch_Name;
        List<Proudects> prdList = new List<Proudects>();
        List<Proudects> ordList = new List<Proudects>();
        public MainShop()
        {
            InitializeComponent();
            prd = new Proudects();
            dth = new DataHelpers();
            ord = new Orders();
            conn = new SqlConnection("Data Source=DESKTOP-AJ8DB4G;" + "Initial Catalog=ShopCart;" + "Integrated Security=SSPI;");
            Lists();
        }
        private void Lists()
        {
            Elect_list.Location = new Point(0, 0);
            Elect_list.Height = 410-panel6.Height-2;
            Elect_list.Width = 623;

            cloth_list.Location = new Point(0, 0);
            cloth_list.Height = 410 - panel6.Height-2;
            cloth_list.Width = 623;

            hose_list.Location = new Point(0, 0);
            hose_list.Height = 410 - panel6.Height;
            hose_list.Width = 623;

            other_list.Location = new Point(0, 0);
            other_list.Height = 410 - panel6.Height-2;
            other_list.Width = 623;

            Order_list.Location = new Point(0, 0);
            Order_list.Height = 410 - panel6.Height-2;
            Order_list.Width = 623;
        }
        private void Elecronics_btn_Click(object sender, EventArgs e)
        {
            //  Elect_list.Items.Add(new exListBoxItem(idd, "Iphone", " Iphone 6 mobile","10$",Properties.Resources.default_user_image));
            Elect_list.Visible = true;
            cloth_list.Visible = false;
            hose_list.Visible = false;
            other_list.Visible = false;
            Order_list.Visible = false;
            listname.Visible = true;
            listname.Text = Electronics_btn.Text;
            profile_panel.Hide();
            buy_btn.Visible = true;
            tab_Click(sender, e);
        }

        private void Log_Click(object sender, EventArgs e)
        {
            try
            {
                conn.Open();
                using (SqlCommand cmd2 = new SqlCommand("UPDATE [Users] SET Users_Status=@Users_Status WHERE Users_id=@Users_id", conn))
                {
                    cmd2.Parameters.AddWithValue("@Users_id", user.Id);
                    cmd2.Parameters.AddWithValue("@Users_Status", 0);
                    cmd2.ExecuteNonQuery();
                    Login log = new Login();
                    log.Show();
                    this.Hide();
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                conn.Close();
                timer1.Start();
            }
        }

        private void Clothes_btn_Click(object sender, EventArgs e)
        {
            buy_btn.Visible = true;
            Elect_list.Visible = false;
            cloth_list.Visible = true;
            hose_list.Visible = false;
            other_list.Visible = false;
            Order_list.Visible = false;
            listname.Visible = true;
            listname.Text = Clothes_btn.Text;
            profile_panel.Hide();
            tab_Click(sender, e);
        }

        private void Houseware_btn_Click(object sender, EventArgs e)
        {
            buy_btn.Visible = true;
            Elect_list.Visible = false;
            cloth_list.Visible = false;
            hose_list.Visible = true;
            other_list.Visible = false;
            Order_list.Visible = false;
            listname.Visible = true;
            profile_panel.Hide();
            listname.Text = Houseware_btn.Text;
            tab_Click(sender, e);
        }

        private void Others_btn_Click(object sender, EventArgs e)
        {
            buy_btn.Visible = true;
            Elect_list.Visible = false;
            cloth_list.Visible = false;
            hose_list.Visible = false;
            other_list.Visible = true;
            Order_list.Visible = false;
            listname.Visible = true;
            listname.Text = Others_btn.Text;
            profile_panel.Hide();
            tab_Click(sender, e);
        }
        private void Home_btn_Click(object sender, EventArgs e)
        {
            Elect_list.Visible = false;
            cloth_list.Visible = false;
            hose_list.Visible = false;
            other_list.Visible = false;
            Order_list.Visible = false;
            listname.Text = "";
            buy_btn.Visible = false;
            profile_panel.Hide();
            tab_Click(sender, e);
        }

        #region show_data
        private void DisplayElectronicsData()
        {
            prdList.Clear();
            try
            {
               conn.Open();
                using (SqlCommand cmd = new SqlCommand("Select * from [Proudects] where  classes_id = '" + 1 + "'", conn))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            long len = reader.GetBytes(3, 0, null, 0, 0);
                            Byte[] buffer = new Byte[len];
                            reader.GetBytes(3, 0, buffer, 0, (int)len);
                            Proudects prd = new Proudects()
                            { 
                                Name = reader.GetString(1).ToString(),
                                Price = reader.GetDouble(2),
                                Image = dth.byteArrayToImage(buffer),
                                Description = reader.GetString(4).ToString()
                            };
                            prdList.Add(prd);
                        }
                       

                    }
                }
                foreach (var item in prdList)
                {
                    Elect_list.Items.Add(new exListBoxItem(idd,item.Name,item.Description,item.Price.ToString()+"$",item.Image));
                    idd++;
                }
                Console.WriteLine( prdList.Count);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }
            finally
            {
                conn.Close();
            }
        }
        private void DisplayClothesData()
        {
            prdList.Clear();
            try
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand("Select * from [Proudects] where  classes_id = '" +2 + "'", conn))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            long len = reader.GetBytes(3, 0, null, 0, 0);
                            Byte[] buffer = new Byte[len];
                            reader.GetBytes(3, 0, buffer, 0, (int)len);
                            Proudects prd = new Proudects()
                            {
                                Name = reader.GetString(1).ToString(),
                                Price = reader.GetDouble(2),
                                Image = dth.byteArrayToImage(buffer),
                                Description = reader.GetString(4).ToString()
                            };
                            prdList.Add(prd);
                        }


                    }
                }
                foreach (var item in prdList)
                {
                    cloth_list.Items.Add(new exListBoxItem(idd, item.Name, item.Description, item.Price.ToString() + "$", item.Image));
                    idd++;
                }
                Console.WriteLine(prdList.Count);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }
            finally
            {
                conn.Close();
            }
        }
        private void DisplayHousewareData()
        {
            prdList.Clear();
            try
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand("Select * from [Proudects] where  classes_id = '" + 3 + "'", conn))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            long len = reader.GetBytes(3, 0, null, 0, 0);
                            Byte[] buffer = new Byte[len];
                            reader.GetBytes(3, 0, buffer, 0, (int)len);
                            Proudects prd = new Proudects()
                            {
                                Name = reader.GetString(1).ToString(),
                                Price = reader.GetDouble(2),
                                Image = dth.byteArrayToImage(buffer),
                                Description = reader.GetString(4).ToString()
                            };
                            prdList.Add(prd);
                        }


                    }
                }
                foreach (var item in prdList)
                {
                    hose_list.Items.Add(new exListBoxItem(idd, item.Name, item.Description, item.Price.ToString() + "$", item.Image));
                    idd++;
                }
                Console.WriteLine(prdList.Count);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }
            finally
            {
                conn.Close();
            }
        }
        private void DisplayOthersData()
        {
            prdList.Clear();
            try
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand("Select * from [Proudects] where  classes_id = '" + 4 + "'", conn))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            long len = reader.GetBytes(3, 0, null, 0, 0);
                            Byte[] buffer = new Byte[len];
                            reader.GetBytes(3, 0, buffer, 0, (int)len);
                            Proudects prd = new Proudects()
                            {
                                Name = reader.GetString(1).ToString(),
                                Price = reader.GetDouble(2),
                                Image = dth.byteArrayToImage(buffer),
                                Description = reader.GetString(4).ToString()
                            };
                            prdList.Add(prd);
                        }


                    }
                }
                foreach (var item in prdList)
                {
                    other_list.Items.Add(new exListBoxItem(idd, item.Name, item.Description, item.Price.ToString() + "$", item.Image));
                    idd++;
                }
                Console.WriteLine(prdList.Count);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }
            finally
            {
                conn.Close();
            }
        }
        private void DisplayOrderData()
        {
            ordList.Clear();
            Order_list.Items.Clear();
            Order_list.ClearSelected();
            //Order_list.Refresh();
            try
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand("Select * from [Orders] where  Users_id = '" + user.Id + "'", conn))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            long len = reader.GetBytes(3, 0, null, 0, 0);
                            Byte[] buffer = new Byte[len];
                            reader.GetBytes(3, 0, buffer, 0, (int)len);
                            Proudects prd = new Proudects()
                            {
                                Name = reader.GetString(1).ToString(),
                                Price = reader.GetDouble(2),
                                Image = dth.byteArrayToImage(buffer),
                                Description = reader.GetString(9).ToString()
                            };
                            ordList.Add(prd);
                        }

                    }
                }
                
                foreach (var item in ordList)
                {
                    Order_list.Items.Add(new exListBoxItem(idd, item.Name, item.Description, item.Price.ToString() + "$", item.Image));
                    idd++;
                }
                timer1.Start();
                Console.WriteLine(ordList.Count);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }
            finally
            {
                conn.Close();
                timer1.Stop();
            }
        }
        private void DisplayUserData()
        {
            try
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand("Select * from [Users] where  Users_id = '" + user.Id + "'", conn))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            long len = reader.GetBytes(9, 0, null, 0, 0);
                            Byte[] buffer = new Byte[len];
                            reader.GetBytes(9, 0, buffer, 0, (int)len);
                                user.Fullname = reader.GetString(1);
                            user.Password = reader.GetString(2);
                            user.Email = reader.GetString(3);
                            user.Phone = reader.GetString(4);
                            user.Country = reader.GetString(5);
                            user.City = reader.GetString(6);
                            user.Bithday = reader.GetDateTime(7);
                            user.Image = dth.byteArrayToImage(buffer);
                        }
                        name_label.Text = dth.FirstCharToUpper(user.Fullname);
                        profile_img.Image = user.Image;
                        edit_name.Text = user.Fullname;
                        edit_email.Text = user.Email;
                        edit_city.Text = user.City;
                        edit_country.Text = user.Country;
                        edit_phone.Text = user.Phone;
                        if (user.Gender == "Male")
                            edit_genderlist.selectedIndex = -1;
                        else
                            edit_genderlist.selectedIndex = 0;
                        edit_birthday.Value = user.Bithday;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }
            finally
            {
                conn.Close();
            }
        }
        #endregion

        private void MainShop_Load(object sender, EventArgs e)
        {
            DisplayUserData();
            DisplayElectronicsData();
            DisplayClothesData();
            DisplayOthersData();
            DisplayHousewareData();
            DisplayOrderData();
            buy_btn.Visible = false;
            profile_panel.Hide();
        }
        private void bunifuImageButton1_Click(object sender, EventArgs e)
        {
            Elect_list.Visible = false;
            cloth_list.Visible = false;
            hose_list.Visible = false;
            other_list.Visible = false;
            Order_list.Visible = true;
            listname.Visible = true;
            listname.Text = "My Orders";
            buy_btn.Visible = false;
            profile_panel.Hide(); 
        }

        private void bunifuFlatButton1_Click(object sender, EventArgs e)
        {
            try
            {

                if (listname.Text == "Electronics")
                {
                    if (Elect_list.SelectedIndex != -1)
                    {
                        ord.Name = ((exListBoxItem)Elect_list.SelectedItem).Title.ToString();
                        int length = ((exListBoxItem)Elect_list.SelectedItem).Price.Length - 1;
                        ord.Price = Convert.ToDouble(((exListBoxItem)Elect_list.SelectedItem).Price.Substring(0, length));
                        ord.Description = ((exListBoxItem)Elect_list.SelectedItem).Details;
                        ord.Image = ((exListBoxItem)Elect_list.SelectedItem).ItemImage;
                    }
                }
                else if (listname.Text == "Clothes")
                {
                    if (cloth_list.SelectedIndex != -1)
                    {
                        ord.Name = ((exListBoxItem)cloth_list.SelectedItem).Title.ToString();
                        int length = ((exListBoxItem)cloth_list.SelectedItem).Price.Length - 1;
                        ord.Price = Convert.ToDouble(((exListBoxItem)cloth_list.SelectedItem).Price.Substring(0, length));
                        ord.Description = ((exListBoxItem)cloth_list.SelectedItem).Details;
                        ord.Image = ((exListBoxItem)cloth_list.SelectedItem).ItemImage;
                    }
                }
                else if (listname.Text == "Houseware")
                {
                    if (hose_list.SelectedIndex != -1)
                    {
                        ord.Name = ((exListBoxItem)hose_list.SelectedItem).Title.ToString();
                        int length = ((exListBoxItem)hose_list.SelectedItem).Price.Length - 1;
                        ord.Price = Convert.ToDouble(((exListBoxItem)hose_list.SelectedItem).Price.Substring(0, length));
                        ord.Description = ((exListBoxItem)hose_list.SelectedItem).Details;
                        ord.Image = ((exListBoxItem)hose_list.SelectedItem).ItemImage;
                    }
                }
                else if (listname.Text == "Others")
                {
                    if (other_list.SelectedIndex != -1)
                    {
                        ord.Name = ((exListBoxItem)other_list.SelectedItem).Title.ToString();
                        int length = ((exListBoxItem)other_list.SelectedItem).Price.Length - 1;
                        ord.Price = Convert.ToDouble(((exListBoxItem)other_list.SelectedItem).Price.Substring(0, length));
                        ord.Description = ((exListBoxItem)other_list.SelectedItem).Details;
                        ord.Image = ((exListBoxItem)other_list.SelectedItem).ItemImage;
                    }
                }
                conn.Open();
                using (SqlCommand cmd = new SqlCommand("INSERT INTO Orders(Orders_Name, Orders_Price, Orders_Photo, Orders_Date,Orders_notes,Users_id) VALUES(@Orders_Name, @Orders_Price, @Orders_Photo, @Orders_Date,@Orders_notes,@Users_id)", conn))
                {
                    cmd.Parameters.AddWithValue("@Orders_Name", ord.Name);
                    cmd.Parameters.AddWithValue("@Orders_Price", ord.Price);
                    cmd.Parameters.AddWithValue("@Orders_Date", DateTime.Now);
                    cmd.Parameters.AddWithValue("@Orders_notes", ord.Description);
                    photo_aray = dth.ImageToByte2(ord.Image);
                    cmd.Parameters.AddWithValue("@Orders_Photo", photo_aray);
                    cmd.Parameters.AddWithValue("@Users_id", user.Id);
                    cmd.ExecuteNonQuery();
                    Alert.Show("Add Sucssesed", Alert.AlertType.Success);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error:" + ex.Message);
            }
            finally
            {
                conn.Close();
               DisplayOrderData();
            }
        }

        private void Order_list_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            ord.Name = ((exListBoxItem)Order_list.SelectedItem).Title.ToString();
            try
            {
                conn.Open();

                using (SqlCommand cmd2 = new SqlCommand("Select Orders_id from [Orders]  WHERE Orders_Name = '" + ord.Name + "'", conn))
                {
                    string id = cmd2.ExecuteScalar().ToString();
                    ord.Id = Convert.ToInt32(id);
                }
                using (SqlCommand cmd = new SqlCommand("DELETE FROM Orders WHERE Orders_id = '" + ord.Id + "'", conn))
                {
                    cmd.ExecuteNonQuery();
                    Alert.Show("Remove Succeses", Alert.AlertType.Success);
                }

                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                conn.Close();
                DisplayOrderData();
            }
        }
        private void profile_btn_Click(object sender, EventArgs e)
        {
            profile_panel.Show();
           // DisplayOrderData();
            //buy_btn.Visible = false;
            //buy_btn.Enabled = false;
        }

        private void passlink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            edit_pass.Enabled = true;
            label4.Visible = true;
            edit_newpass.Visible = true; 
        }

        private void update_btn_Click(object sender, EventArgs e)
        {
            try
            {

                conn.Open();
                using (SqlCommand cmd = new SqlCommand("UPDATE [Users] SET Users_FullName=@Users_FullName,Users_Password=@Users_Password,Users_Email=@Users_Email,Users_Phone=@Users_Phone,Users_Country=@Users_Country,Users_City=@Users_City,Users_BirthDay=@Users_BirthDay,Users_Gender=@Users_Gender,Users_Image=@Users_Image WHERE Users_id=@Users_id", conn))
                {
                    cmd.Parameters.AddWithValue("@Users_id", user.Id);
                    cmd.Parameters.AddWithValue("@Users_FullName", edit_name.Text);
                    if (edit_pass.Enabled == false)
                        cmd.Parameters.AddWithValue("@Users_Password", user.Password);
                    else if (edit_pass.Enabled == true && edit_pass.Text == user.Password)
                        cmd.Parameters.AddWithValue("@Users_Password", edit_newpass.Text);
                    else
                    {
                        Alert.Show("Enter Right Password", Alert.AlertType.Waring);
                        return;
                    }
                    cmd.Parameters.AddWithValue("@Users_Email", edit_email.Text);
                    cmd.Parameters.AddWithValue("@Users_BirthDay", edit_birthday.Value);
                    cmd.Parameters.AddWithValue("@Users_Country", edit_country.Text);
                    cmd.Parameters.AddWithValue("@Users_City", edit_city.Text);
                    cmd.Parameters.AddWithValue("@Users_Phone", edit_phone.Text);
                    cmd.Parameters.AddWithValue("@Users_Gender", edit_genderlist.selectedValue);
                    photo_aray = dth.ImageToByte2(profile_img.Image);
                    if (photo_aray != null)
                    {
                        cmd.Parameters.AddWithValue("@Users_Image", photo_aray);
                    }
                    cmd.ExecuteNonQuery();
                    timer1.Start();
                    Alert.Show("Update Sucssesed", Alert.AlertType.Success);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error:" + ex.Message);
            }
            finally
            {
                conn.Close();
                DisplayUserData();
                timer1.Stop();
            }
        }

        private void profile_img_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "jpeg|*.jpg|bmp|*.bmp|png|*.png|all files|*.*";
            DialogResult res = openFileDialog1.ShowDialog();
            if (res == DialogResult.OK)
            {
                profile_img.Image = Image.FromFile(openFileDialog1.FileName);
            }
        }

        private void bunifuImageButton1_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }
        private void tab_Click(object sender, EventArgs e)
        {
            bar.Top = ((Bunifu.Framework.UI.BunifuFlatButton)sender).Top;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            DisplayUserData();
            DisplayOrderData();
        }

        private void bar_Click(object sender, EventArgs e)
        {

        }
    }
}
