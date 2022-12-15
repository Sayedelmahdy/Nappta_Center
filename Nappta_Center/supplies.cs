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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Nappta_Center
{
    public partial class supplies : Form
    {
        public string su_id_Add;
        public string su_name_Add;
        public string su_quantiy_Add;
        public string su_empid;
        public bool checkrandom(int num)
        {
          
            SqlConnection con = new SqlConnection("Data Source=DESKTOP-0JE92F7;Initial Catalog=nappta;Integrated Security=True");
            // change table name 
            SqlCommand cmds = new SqlCommand(@"select * from supplies where supplies_ID='" + textBox1.Text+ "'", con);
            con.Open();
            SqlDataReader dr = cmds.ExecuteReader();
            if (dr.Read())
            {
                return false;
            }
            else
                return true;

        }
        public Random a = new Random();
        int MyNumber = 0;
        public void NewNumber()
        {
            MyNumber = a.Next(10000, 9999999);

            if (checkrandom(MyNumber))
                textBox1.Text = MyNumber.ToString();
        }
        private Form CallingForm = null;
        public supplies(Form callingForm,string empid) : this()
        {
            this.CallingForm = callingForm;
            su_empid = empid;
        }
        public supplies()
        {
            InitializeComponent();
        }

        private void supplies_Load(object sender, EventArgs e)
        {
            
        }

        private void textBox1_Click(object sender, EventArgs e)
        {
            NewNumber();
        }

        private void button1_Click(object sender, EventArgs e)
        {
              su_id_Add=textBox1.Text;
         su_name_Add=textBox2.Text;
         su_quantiy_Add=textBox4.Text;
            SqlConnection con1 = new SqlConnection("Data Source=DESKTOP-0JE92F7;Initial Catalog=nappta;Integrated Security=True");
            SqlCommand cmde = new SqlCommand(@"INSERT INTO supplies (supplies_ID,supplise_name,quantiy,employee_ID) VALUES(@id,@Name,@qua,@emp)", con1);
            cmde.Parameters.AddWithValue("@id", int.Parse(su_id_Add));
            cmde.Parameters.AddWithValue("@name", su_name_Add);
            cmde.Parameters.AddWithValue("@qua", su_quantiy_Add);
            cmde.Parameters.AddWithValue("@emp", int.Parse(su_empid));
            con1.Open();
            int row = cmde.ExecuteNonQuery();
            if (row > 0)
            {
                MessageBox.Show("DONE");

                textBox1.Text = null;
                textBox2.Text = null;
                textBox4.Text = null;
              
              
                con1.Close();

            }
            else
            {
                MessageBox.Show("Not added successfully");
                con1.Close();
            }

        }


    }
}
