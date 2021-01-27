using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AnimalShelter
{
    public partial class Form1 : Form
    {
        public List<Customer> Customers = new List<Customer>();

        public Form1()
        {
            InitializeComponent();
        }

        private void CreateCustomer_Click(object sender, EventArgs e)
        {

            Customer cus = new Customer(CusNewFirstName.Text,
                CusNewLastName.Text, DateTime.Parse(CusNewBirthday.Text));
            cus.Address = CusNewAddress.Text;
            cus.Description = CusNewDescription.Text;

            CusList.Rows.Add(cus.FirstName, cus.Age, cus.IsQualified);

            Customers.Add(cus);

            CusNewFirstName.Text = "";
            CusNewLastName.Text = "";
            CusNewBirthday.Text = "";
            CusNewAddress.Text = "";
            CusNewDescription.Text = "";
        }

        public void ShowDetails(Customer cus)
        {
            CusFullName.Text = cus.FullName;
            CusAge.Text = cus.Age.ToString();
            CusAddress.Text = cus.Address;
            CusDescription.Text = cus.Description;
            CusIsQualified.Text = cus.IsQualified.ToString();

            if(cus.MyCat != null)
                CusPetInfo.Text = cus.MyCat.Name + " : " + cus.MyCat.MakeSound() + Environment.NewLine;

            if (cus.MyDog != null)
                CusPetInfo.Text += cus.MyDog.Name + " : " + cus.MyDog.MakeSound();
        }

        private void CusList_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            string firstName = CusList.Rows[e.RowIndex].Cells[0].Value.ToString();

            foreach(Customer cus in Customers)
            {
                if(cus.FirstName == firstName)
                {
                    ShowDetails(cus);
                    break;
                }
            }

            CusDetailPanel.Show();
            CusNewPanel.Hide();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            CusListPanel.Dock = DockStyle.Fill;
            CusDetailPanel.Dock = DockStyle.Right;
            CusNewPanel.Dock = DockStyle.Right;

            Customer cus = new Customer("Ian", "Na", new DateTime(2000, 1, 2));
            Cat cat = new Cat(1, "Lucas", "White", "Male");
            cus.Adopt(cat);

            Dog dog = new Dog(2, "Happy", "Black", "Male", DogBreed.Jindo);
            cus.Adopt(dog);

            Customers.Add(cus);
            CusList.Rows.Add(cus.FirstName, cus.Age, cus.IsQualified);
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            CusNewPanel.Show();
            CusDetailPanel.Hide();
        }
    }
}
