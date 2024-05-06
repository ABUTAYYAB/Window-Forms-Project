using DairyDelightsLibrary.BL;
using DairyDelightsLibrary.Interface;
using DairyDelightsLibrary.Validation;
using System;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace WindowsFormProject.UI
{
    public partial class AddProduct : UserControl
    {
        IProduct product = ObjectHandler.GetProductInstance();
        public AddProduct()
        {
            InitializeComponent();
        }
        private void ClearData()
        {
            guna2TextBox1.Text = "";
            guna2TextBox2.Text = "";
            guna2TextBox3.Text = "";
            guna2TextBox4.Text = "";
            guna2TextBox5.Text = "";
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            try
            {
                string Name = guna2TextBox1.Text;
                string Price = guna2TextBox2.Text;
                string quantity = guna2TextBox3.Text;
                string description = guna2TextBox4.Text;
                string discount = guna2TextBox5.Text;
                if (Name != "" && Price != "" && quantity != "" && description != "" && discount != "")
                {
                    if(UserValidation.IsStringValid(Name)&& UserValidation.IsStringValid(description))
                    {
                        if (UserValidation.IsConvertibleToDouble(Price))
                        {
                            if (UserValidation.IsConvertibleToDouble(quantity))
                            {
                                if (UserValidation.IsDiscountValid(discount))
                                {
                                    if (!(product.CheckIfProductAlreadyExist(Name)))
                                    {
                                        double PriceDouble, Quantitydouble, Discount;

                                        PriceDouble = UserValidation.ConvertStringIntoDouble(Price);
                                        Quantitydouble = UserValidation.ConvertStringIntoDouble(quantity);
                                        Discount = UserValidation.ConvertStringIntoDouble(discount);

                                        Product product1 = new Product(Name, description, PriceDouble, Quantitydouble, Discount);
                                        bool IsProductAdded = product.Addproduct(product1);
                                        if (IsProductAdded)
                                        {
                                            MessageBox.Show("Done");
                                            ClearData();
                                        }
                                        else
                                        {
                                            MessageBox.Show("Not Added.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                        }
                                    }
                                    else
                                    {
                                        MessageBox.Show("Product Already Exist ", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                                    }
                                }
                                else
                                {
                                    MessageBox.Show("Enter valid Discount ", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                }
                            }
                            else
                            {
                                MessageBox.Show("Enter valid Quantity ", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            }
                        }
                        else
                        {
                            MessageBox.Show("Enter valid Price ", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Data Cannot Contain Letter % OR , And | .", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                else
                {
                    MessageBox.Show("Enter Data in All The Fields", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch
            {
                MessageBox.Show("Error", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
