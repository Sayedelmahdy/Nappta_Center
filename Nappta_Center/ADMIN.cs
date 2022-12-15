using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
namespace Nappta_Center
{
    public partial class ADMIN : Form
    {
        
        public string e_id_Add;
        public string e_password_Add;
        public string e_dep_id_Add;
        public string e_name_Add;
        public string e_gender_Add;
        public string e_address_Add;
        public string e_birthdate_Add;
        public string e_email_Add;
        public string e_phone_Add;
        public string e_spcial_Add;
        public string e_workingHour_Add;
        public string e_salary_Add;
        public string s_id_Add;
        public string s_password_Add;
        public string s_dep_id_Add;
        public string s_name_Add;
        public string s_birthdate_Add;
        public string s_email_Add;
        public string s_phone_Add;
        public string s_specialization_Add;
        public string s_spcial_Add;
        public string s_workingHour_Add1;
        public string s_salary_Add;
        public string d_id_Add;
        public string d_dep_Name_Add;
        public string d_dep_descrption;

        string nappta_id;
        public bool checkrandom1(int num)
        {
            
            SqlConnection con = new SqlConnection("Data Source=DESKTOP-0JE92F7;Initial Catalog=nappta;Integrated Security=True");
            SqlCommand cmde = new SqlCommand(@"select * from employee where employee_ID= @emp", con);
            cmde.Parameters.AddWithValue("@emp", textBox1.Text);
            con.Open();
            SqlDataReader dr =cmde.ExecuteReader();
            if (dr.Read())
            {
                return false;
            }
            else
                return true;

            con.Close();
        }
        public bool checkrandom2(int num)
        {
            
            SqlConnection con = new SqlConnection("Data Source=DESKTOP-0JE92F7;Initial Catalog=nappta;Integrated Security=True");
            SqlCommand cmds = new SqlCommand(@"select * from Specialist where Specialist_id=@emp", con);
            cmds.Parameters.AddWithValue("@emp", textBox20.Text);
            con.Open();
            SqlDataReader dr = cmds.ExecuteReader();
            if (dr.Read())
            {
                return false;
            }
            else
                return true;
            con.Close();
        }
        public bool checkrandom3(int num)
        {
            SqlConnection con = new SqlConnection("Data Source=DESKTOP-0JE92F7;Initial Catalog=nappta;Integrated Security=True");
            SqlCommand cmds = new SqlCommand(@"select * from Department where DeptID=@emp", con);
            cmds.Parameters.AddWithValue("@emp",textBox22.Text);
            con.Open();
            SqlDataReader dr = cmds.ExecuteReader();
            if (dr.Read())
            {
                return false;
            }
            else
                return true;
            dr.Close();
        }
        public Random a = new Random();
        public Random b = new Random();
        public Random c = new Random();
        int MyNumber = 0;
        public void NewNumber1()
        {
            MyNumber = a.Next(10000, 9999999);

            if (checkrandom1(MyNumber))
                textBox1.Text = MyNumber.ToString();
        }
        public void NewNumber2()
        {
            MyNumber = b.Next(10000, 9999999);

            if (checkrandom2(MyNumber))
                textBox20.Text = MyNumber.ToString();
        }
        public void NewNumber3()
        {
            MyNumber = c.Next(10000, 9999999);

            if (checkrandom3(MyNumber))
                textBox22.Text = MyNumber.ToString();
        }

        private Form CallingForm = null;
        public ADMIN(Form callingForm, string id) : this()
        {
            this.CallingForm = callingForm;
            this.nappta_id = id;
        }
        public ADMIN()
        {
            InitializeComponent();
        }

        private void ADMIN_Load(object sender, EventArgs e)
        {
            NewNumber1();
            NewNumber2();
            NewNumber3();
        }

        private void button1_Click(object sender, EventArgs e)
        {
             e_id_Add=textBox1.Text;
             e_password_Add=textBox23.Text;
         e_dep_id_Add = textBox14.Text;
         e_name_Add = textBox2.Text;
       e_gender_Add = comboBox1.Text;
        e_address_Add = textBox4.Text;
       e_birthdate_Add = textBox5.Text;
         e_email_Add = textBox6.Text;
         e_phone_Add = textBox7.Text;
         e_spcial_Add = textBox15.Text;
        e_workingHour_Add = textBox16.Text;
         e_salary_Add = textBox17.Text;
            SqlConnection con1 = new SqlConnection("Data Source=DESKTOP-0JE92F7;Initial Catalog=nappta;Integrated Security=True");
            SqlCommand cmde = new SqlCommand(@"insert into employee values(@id,@Name,@password,@gender,@phone,@addr,@birth,@dep,@spc,@email,@work,@salary,@napttaid)", con1);
            cmde.Parameters.AddWithValue("@id", int.Parse( e_id_Add));
            cmde.Parameters.AddWithValue("@password", e_password_Add);
            cmde.Parameters.AddWithValue("@dep", e_dep_id_Add);
            cmde.Parameters.AddWithValue("@name", e_name_Add);
            cmde.Parameters.AddWithValue("@gender", e_gender_Add);
            cmde.Parameters.AddWithValue("@addr", e_address_Add);
            cmde.Parameters.AddWithValue("@birth", e_birthdate_Add);
            cmde.Parameters.AddWithValue("@email", e_email_Add);
            cmde.Parameters.AddWithValue("@phone", e_phone_Add);
            cmde.Parameters.AddWithValue("@spc", e_spcial_Add);
            cmde.Parameters.AddWithValue("@work", e_workingHour_Add);
            cmde.Parameters.AddWithValue("@salary", e_salary_Add);
            cmde.Parameters.AddWithValue("@napttaid", nappta_id);
            con1.Open();
            int row = cmde.ExecuteNonQuery();
            if (row> 0)
            {
                MessageBox.Show("DONE");

                textBox1.Text = null;
                textBox14.Text = null;
                textBox2.Text = null;
                comboBox1.Text = null;
                textBox4.Text = null;
                textBox5.Text = null;
                textBox6.Text = null;
                textBox7.Text = null;
                textBox15.Text = null;
                textBox16.Text = null;
                textBox17.Text = null;
            }
            else
            {
                MessageBox.Show("not added successfully");
            }
            con1.Close();
           

        }

        private void textBox1_Click(object sender, EventArgs e)
        {
            NewNumber1();
        }

        private void textBox20_Click(object sender, EventArgs e)
        {
            NewNumber2();
        }

        private void textBox22_Click(object sender, EventArgs e)
        {
            NewNumber3();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            s_id_Add = textBox20.Text;
            s_password_Add = textBox24.Text;
            s_dep_id_Add = textBox10.Text;
            s_name_Add = textBox19.Text;
            s_birthdate_Add = textBox13.Text;
            s_email_Add = textBox12.Text;
            s_phone_Add = textBox11.Text;
            s_specialization_Add = textBox9.Text;
            s_spcial_Add = textBox8.Text;
            s_workingHour_Add1 = textBox8.Text;
            s_salary_Add = textBox3.Text;
            SqlConnection con1 = new SqlConnection("Data Source=DESKTOP-0JE92F7;Initial Catalog=nappta;Integrated Security=True");
            SqlCommand cmde = new SqlCommand(@"insert into employee values(@id,@Name,@dep,@password,@email,@phone,@work,@spc,@salary,@napttaid)", con1);
            cmde.Parameters.AddWithValue("@id", int.Parse(s_id_Add));
            cmde.Parameters.AddWithValue("@password", s_password_Add);
            cmde.Parameters.AddWithValue("@dep", s_dep_id_Add);
            cmde.Parameters.AddWithValue("@name", s_name_Add);
            cmde.Parameters.AddWithValue("@email", s_email_Add);
            cmde.Parameters.AddWithValue("@phone", e_phone_Add);
            cmde.Parameters.AddWithValue("@spc", s_spcial_Add);
            cmde.Parameters.AddWithValue("@work", s_workingHour_Add1);
            cmde.Parameters.AddWithValue("@salary", s_salary_Add);
            cmde.Parameters.AddWithValue("@napttaid", nappta_id);
            con1.Open();
            int row = cmde.ExecuteNonQuery();
            if (row > 0)
            {
                MessageBox.Show("DONE");
                textBox20.Text = null;
                textBox10.Text = null;
                textBox19.Text = null;
                textBox13.Text = null;
                textBox12.Text = null;
                textBox11.Text = null;
                textBox9.Text = null;
                textBox8.Text = null;
                textBox3.Text = null;
            }
            else
            {
                MessageBox.Show("Not added successfully");
            }
            con1.Close();

        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Hide();
            //c.ShowDialog();
            //this.Close();
            Form1 f2 = new Form1(this);
            f2.Show();
        }

        private void ADMIN_FormClosed(object sender, FormClosedEventArgs e)
        {
            System.Windows.Forms.Application.ExitThread();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            d_id_Add= textBox22.Text;
        d_dep_Name_Add= textBox18.Text;
        d_dep_descrption= textBox21.Text;
            SqlConnection con1 = new SqlConnection("Data Source=DESKTOP-0JE92F7;Initial Catalog=nappta;Integrated Security=True");
            SqlCommand cmde = new SqlCommand(@"insert into Department values(@id,@Name,@dec,@napttaid)", con1);
            cmde.Parameters.AddWithValue("@id", int.Parse(d_id_Add));
            cmde.Parameters.AddWithValue("@Name", d_dep_Name_Add);
            cmde.Parameters.AddWithValue("@dec", d_dep_descrption);
            cmde.Parameters.AddWithValue("@napttaid", nappta_id);
            con1.Open();
            int row = cmde.ExecuteNonQuery();
            if (row > 0)
            {
                MessageBox.Show("DONE");
                textBox22.Text = null;
                textBox18.Text = null;
                textBox21.Text=null;

            }
            else
            {
                MessageBox.Show("Not added successfully");
            }
            con1.Close();
        }
    }
}

