using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TeknosaSatisUygulamasi
{
    public partial class Form1 : Form
    {
        int customerId = 0;
        int productId = 0;
        int orderId = 0;
        string ImagePath = "";

        CustomerProccess customerProccess = new CustomerProccess();
        ProductProccess productProccess= new ProductProccess();
        OrderProccess orderProccess = new OrderProccess();
        public Form1()
        {
            InitializeComponent();
        }
        public void customerList()
        {
            customerListLb.Items.Clear();
            sellCustomerListLb.Items.Clear();
            foreach (var customer in customerProccess.List().ToList())
            {
                customerListLb.Items.Add(customer.Id+" \t"+customer.Name + " " + customer.Surname);
                
                sellCustomerListLb.Items.Add(customer.Id+" \t"+customer.Name + " " + customer.Surname);
            }
        }
        public void productList()
        {
            productListLb.Items.Clear();
            sellProductListLb.Items.Clear();
            foreach (var product in productProccess.List().ToList())
            {
                productListLb.Items.Add(product.Id + " \t" + product.Name);
                sellProductListLb.Items.Add(product.Id + " \t" + product.Name);
            }
        }
        public void orderList()
        {
            orderListLb.Items.Clear();
            foreach (var order in orderProccess.List().ToList())
            {
                string productName = "";
                foreach(var product in productProccess.List().ToList())
                {
                    if (product.Id == order.ProductId)
                    {
                        productName = product.Name;
                    }
                }
                string customerName = "";
                foreach (var customer in customerProccess.List().ToList())
                {
                    if (customer.Id == order.CustomerId)
                    {
                        customerName = customer.Name+" "+customer.Surname;
                    }
                }

                orderListLb.Items.Add(order.Id+" \tC: "+customerName+"\t P: "+productName+"\t Quantity: "+order.Quantity+"\tTotal Price: "+order.TotalPrice+" TL");

            }
        }
        private void addCustomerBtn_Click(object sender, EventArgs e)
        {
            if(!String.IsNullOrWhiteSpace(customerNameTxt.Text) && !String.IsNullOrWhiteSpace(customerSurnameTxt.Text) && customerBalanceNud.Value > 0)
            {
                Customer customer = new Customer();
                customerId++;
                customer.Id = customerId;
                customer.Name = customerNameTxt.Text;
                customer.Surname = customerSurnameTxt.Text;
                customer.Balance = Convert.ToDouble(customerBalanceNud.Value);

                customerProccess.Add(customer);

                customerAddInformationLbl.Text = "Customer Added Successful";
                customerAddInformationLbl.ForeColor = Color.Green;

                customerNameTxt.Clear();
                customerSurnameTxt.Clear();
                customerBalanceNud.Value = 0;
                customerNameTxt.Focus();
                customerList();
            }
            else
            {
                customerAddInformationLbl.Text = "Customer Added Failed";
                customerAddInformationLbl.ForeColor = Color.Red;
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (customerListLb.SelectedIndex != -1)
            {
                string customer = customerListLb.SelectedItem.ToString();
                string[] customerInformation = customer.Split(' ');
                int id = Convert.ToInt32(customerInformation[0]);
                customerProccess.Delete(id);
                MessageBox.Show("Customer Deleted Successfull","Delete Customer Proccess", MessageBoxButtons.OK, MessageBoxIcon.Information);
                customerListLb.SelectedIndex = -1;
                customerList();
            }
            else
            {
                MessageBox.Show("Customer Deleted Failed","Delete Customer Proccess",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            if (customerListLb.SelectedIndex != -1)
            {
                string customer = customerListLb.SelectedItem.ToString();
                string[] customerInformation = customer.Split(' ');
                int id = Convert.ToInt32(customerInformation[0]);
                Customer customerDetail=customerProccess.Detail(id);
                MessageBox.Show("Customer Found Successfull", "Detail Customer Proccess", MessageBoxButtons.OK, MessageBoxIcon.Information);
                customerListLb.SelectedIndex = -1;

                customerIdLbl.Text = customerDetail.Id.ToString();
                customerNameLbl.Text = customerDetail.Name;
                customerSurnameLbl.Text = customerDetail.Surname;
                customerBalanceLbl.Text = customerDetail.Balance.ToString()+" TL";
                
            }
            else
            {
                MessageBox.Show("Customer Not Found", "Detail Customer Proccess", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void addProductBtn_Click(object sender, EventArgs e)
        {
            if(!String.IsNullOrWhiteSpace(productNameTxt.Text) && productPriceNud.Value>0 && productStockNud.Value > 0)
            {
                Product product = new Product();
                productId++;
                product.Id = productId;
                product.Name = productNameTxt.Text;
                product.Stock = Convert.ToInt32(productStockNud.Value);
                product.Price = Convert.ToDouble(productPriceNud.Value);
                string ImageName = Guid.NewGuid().ToString()+".png";
                pictureBox1.Image.Save(@"C:\Users\ARIBILGI\Desktop\Masaüstü\TeknosaSatisUygulamasi\TeknosaSatisUygulamasi\Images\"+ImageName);
                product.Image = ImageName;

                productProccess.Add(product);
                productPriceNud.Value = 0;
                productStockNud.Value = 0;
                productNameTxt.Clear();
                productNameTxt.Focus();
                productList();
            }
            else
            {

            }
        }

        private void productDeleteBtn_Click(object sender, EventArgs e)
        {
            if (productListLb.SelectedIndex != -1)
            {
                string product = productListLb.SelectedItem.ToString();
                string[] productInformation = product.Split(' ');
                int id = Convert.ToInt32(productInformation[0]);
                productProccess.Delete(id);
                MessageBox.Show("Product Deleted Successfull", "Delete Product Proccess", MessageBoxButtons.OK, MessageBoxIcon.Information);
                productListLb.SelectedIndex = -1;
                productList();
            }
            else
            {
                MessageBox.Show("Product Deleted Failed", "Delete Product Proccess", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void productDetailBtn_Click(object sender, EventArgs e)
        {
            if (productListLb.SelectedIndex != -1)
            {
                string product = productListLb.SelectedItem.ToString();
                string[] productInformation = product.Split(' ');
                int id = Convert.ToInt32(productInformation[0]);
                Product productDetail = productProccess.Detail(id);
                MessageBox.Show("Product Found Successfull", "Detail Product Proccess", MessageBoxButtons.OK, MessageBoxIcon.Information);
                customerListLb.SelectedIndex = -1;

                productIdLbl.Text = productDetail.Id.ToString();
                productNameLbl.Text = productDetail.Name;
                productPriceLbl.Text = productDetail.Price.ToString()+" TL";
                productStockLbl.Text = productDetail.Stock.ToString() + " Piece";
                pictureBox2.ImageLocation = @"C:\Users\ARIBILGI\Desktop\Masaüstü\TeknosaSatisUygulamasi\TeknosaSatisUygulamasi\Images\" + productDetail.Image;
            }
            else
            {
                MessageBox.Show("Product Not Found", "Detail Product Proccess", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if(openFileDialog.ShowDialog() == DialogResult.OK)
            {
                ImagePath = openFileDialog.FileName.ToString();
                pictureBox1.ImageLocation = ImagePath;
            }
        }

        private void button3_Click(object sender, EventArgs e)//clear selected
        {
            sellProductListLb.SelectedIndex = -1;
            sellCustomerListLb.SelectedIndex = -1;
            sellQuantityNud.Value = 0;
        }

        private void button4_Click(object sender, EventArgs e)//sell product
        {
            orderId++;
            string sellCustomerId = sellCustomerListLb.SelectedItem.ToString();
            string[] sellCustomer = sellCustomerId.Split(' ');

            string sellProductId = sellProductListLb.SelectedItem.ToString();
            string[] sellProduct = sellProductId.Split(' ');

            Order order = new Order()
            {
                Id = orderId,
                ProductId = Convert.ToInt32(sellProduct[0]),
                CustomerId = Convert.ToInt32(sellCustomer[0]),
                Quantity = Convert.ToInt32(sellQuantityNud.Value)
            };

            if (orderProccess.Add(order))
            {
                MessageBox.Show("Product Sales to Customer Successful");
            }
            else
            {
                MessageBox.Show("Product Sales Failed");
            }
            orderList();
        }

        private void productListLb_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (productListLb.SelectedIndex != -1)
            {
                string product = productListLb.SelectedItem.ToString();
                string[] productInformation = product.Split(' ');
                int id = Convert.ToInt32(productInformation[0]);
                Product productDetail = productProccess.Detail(id);
               
                customerListLb.SelectedIndex = -1;

                productIdLbl.Text = productDetail.Id.ToString();
                productNameLbl.Text = productDetail.Name;
                productPriceLbl.Text = productDetail.Price.ToString() + " TL";
                productStockLbl.Text = productDetail.Stock.ToString() + " Piece";
                pictureBox2.ImageLocation = @"C:\Users\ARIBILGI\Desktop\Masaüstü\TeknosaSatisUygulamasi\TeknosaSatisUygulamasi\Images\" + productDetail.Image;
            }
            else
            {
                MessageBox.Show("Product Not Found", "Detail Product Proccess", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
