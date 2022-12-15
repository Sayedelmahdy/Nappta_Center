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
using static System.Windows.Forms.DataFormats;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Nappta_Center
{

    public partial class Employee : Form
    {
        public string p_id_Add;
        public string p_depid_Add;
        public string p_name_Add;
        public string p_gender_Add;
        public string p_address_Add;
        public string p_birthdate_Add;
        public string p_email_Add;
        public string p_phone_Add;
        public string p_empID_Add;
        
        public Form1 fr = new Form1();
        public bool checkrandom(int num)
        {

            SqlConnection con = new SqlConnection("Data Source=DESKTOP-0JE92F7;Initial Catalog=nappta;Integrated Security=True");
            SqlCommand cmde = new SqlCommand(@"select * from Patient where patient_ID= @emp", con);
            cmde.Parameters.AddWithValue("@emp", textBox1.Text);
            con.Open();
            SqlDataReader dr = cmde.ExecuteReader();
            if (dr.Read())
            {
                return false;
            }
            else
                return true;

            con.Close();
        }
        public Random a = new Random();
        public List<int> randomList = new List<int>();
        int MyNumber = 0;
        public void NewNumber()
        {
            MyNumber = a.Next(10000, 9999999);
            if (checkrandom(MyNumber))
            {
                textBox1.Text = MyNumber.ToString();
            }
        }
        private Form CallingForm = null;
        public Employee(Form callingForm,string depid) : this()
        {
            this.CallingForm = callingForm;
           p_empID_Add = depid;
        }
        public Employee()
        {
            InitializeComponent();



        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            p_id_Add = textBox1.Text;
            p_name_Add = textBox2.Text;
            p_gender_Add = comboBox1.Text;
            p_address_Add = textBox4.Text;
            p_birthdate_Add = textBox5.Text;
            p_email_Add = textBox6.Text;
            p_phone_Add = textBox7.Text;
            p_depid_Add=textBox15.Text;
            SqlConnection con1 = new SqlConnection("Data Source=DESKTOP-0JE92F7;Initial Catalog=nappta;Integrated Security=True");
            SqlCommand cmde = new SqlCommand(@"INSERT INTO Patient (patient_ID,full_name,phone_number,Address,patient_bithdate,Dept_ID,E_mail,employee_ID,napta_id) VALUES(@id,@Name,@phone,@address,@birh,@dep,@email,@emp,@napttaid)", con1);
            cmde.Parameters.AddWithValue("@id", int.Parse(p_id_Add));
            cmde.Parameters.AddWithValue("@name", p_name_Add);
            cmde.Parameters.AddWithValue("@phone", p_phone_Add);
            cmde.Parameters.AddWithValue("@address", p_address_Add);
            cmde.Parameters.AddWithValue("@birh", p_birthdate_Add);
            cmde.Parameters.AddWithValue("@dep", int.Parse(p_depid_Add));
            cmde.Parameters.AddWithValue("@email", p_email_Add);
            cmde.Parameters.AddWithValue("@emp",int.Parse(p_empID_Add));
            cmde.Parameters.AddWithValue("@napttaid",123344);
            
            con1.Open();
            int row = cmde.ExecuteNonQuery();
            if (row > 0)
            {
                MessageBox.Show("DONE");
              
                textBox1.Text = null;
                textBox2.Text = null;
                textBox4.Text = null;
                textBox5.Text = null;
                textBox6.Text = null;
                textBox7.Text = null;
                textBox15.Text = null;
                comboBox2.Items.Clear();
                SqlConnection con2 = new SqlConnection("Data Source=DESKTOP-0JE92F7;Initial Catalog=nappta;Integrated Security=True");
                SqlCommand cmdf = new SqlCommand(@"select patient_ID from Patient ", con2);
                con1.Close();
                con2.Open();

                cmdf.ExecuteNonQuery();
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(cmdf);
                da.Fill(dt);
                foreach (DataRow dr in dt.Rows)
                {
                    comboBox2.Items.Add(dr["patient_ID"].ToString());
                }
                con1.Close();

            }
            else
            {
                MessageBox.Show("Not added successfully");
                con1.Close();
            }
           
            }

            private void button5_Click(object sender, EventArgs e)
            {

                this.Hide();
                //c.ShowDialog();
                //this.Close();
                Form1 f2 = new Form1(this);
                f2.Show();
            }

         

            private void button2_Click(object sender, EventArgs e)
            {
                SqlConnection con1 = new SqlConnection("Data Source=DESKTOP-0JE92F7;Initial Catalog=nappta;Integrated Security=True");
                SqlCommand cmde = new SqlCommand(@"select * from Patient where patient_ID=@id", con1);
                cmde.Parameters.AddWithValue("@id", comboBox2.Text);
                con1.Open();
                SqlDataReader sr1 = cmde.ExecuteReader();
                if (sr1.Read())
                {
              
                    textBox13.Text = sr1[1].ToString();
                    textBox11.Text = sr1[3].ToString();
                    textBox10.Text = sr1[4].ToString();
                    textBox9.Text = sr1[6].ToString();
                    textBox8.Text = sr1[2].ToString();
                    textBox16.Text = sr1[5].ToString();
                textBox13.Enabled = true;
                textBox11.Enabled = true;
                textBox10.Enabled = true;
                textBox9.Enabled = true;
                textBox8.Enabled = true;
                textBox16.Enabled = true;


            }
                else {
                    MessageBox.Show("ID Not founded");
                }



                con1.Close();

            comboBox2.Text = null;
            }

           
            private void Employee_FormClosed(object sender, FormClosedEventArgs e)
            {
                System.Windows.Forms.Application.ExitThread();
            }

            private void button6_Click(object sender, EventArgs e)
            {
                supplies fr3 = new supplies(this,p_empID_Add);
                fr3.Show();
            }

        private void textBox1_Click(object sender, EventArgs e)
        {
            NewNumber();
        }

        private void label16_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            SqlConnection con1 = new SqlConnection("Data Source=DESKTOP-0JE92F7;Initial Catalog=nappta;Integrated Security=True");
            SqlCommand cmde = new SqlCommand(@"delete from Patient where patient_ID=@id", con1);
            cmde.Parameters.AddWithValue("@id", comboBox2.Text);
            con1.Open();
            int sr1 = cmde.ExecuteNonQuery();
            if (sr1>0)
            {
                comboBox2.Items.Clear();
                con1.Close();
                SqlCommand cmdf = new SqlCommand(@"select patient_ID from Patient ", con1);
                con1.Open();
                cmdf.ExecuteNonQuery();
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(cmdf);
                da.Fill(dt);
                foreach (DataRow dr in dt.Rows)
                {
                    comboBox2.Items.Add(dr["patient_ID"].ToString());
                }
                con1.Close();
                MessageBox.Show("Row has been deleted");

            }
            else
            {
                MessageBox.Show("ID Not founded");
                con1.Close();
            }

            comboBox2.Text = null;


        }

        private void button4_Click(object sender, EventArgs e)
        {
            SqlConnection con1 = new SqlConnection("Data Source=DESKTOP-0JE92F7;Initial Catalog=nappta;Integrated Security=True");
            SqlCommand cmde = new SqlCommand(@"UPDATE Patient set full_name=@name,phone_number=@phone,Address=@adress,patient_bithdate=@birthday,Dept_ID=@dipt,E_mail=@email,employee_ID=@employeeid,napta_id=@napta WHERE patient_ID=@patin_id", con1);
            cmde.Parameters.AddWithValue("@name", textBox13.Text);
            cmde.Parameters.AddWithValue("@phone", textBox8.Text);
            cmde.Parameters.AddWithValue("@adress", textBox11.Text);
            cmde.Parameters.AddWithValue("@birthday", textBox10.Text);
            cmde.Parameters.AddWithValue("@employeeid", int.Parse(p_empID_Add));
            cmde.Parameters.AddWithValue("@email", textBox9.Text);
            cmde.Parameters.AddWithValue("@dipt", textBox16.Text);
            cmde.Parameters.AddWithValue("@napta", 123344);
            cmde.Parameters.AddWithValue("@patin_id", comboBox2.Text);


            con1.Open();
            int sr1 = cmde.ExecuteNonQuery();
            if (sr1>0)
            {


                MessageBox.Show("row updated successfully");
                textBox13.Enabled = false;
                textBox11.Enabled = false;
                textBox10.Enabled = false;
                textBox9.Enabled = false;
                textBox8.Enabled = false;
                textBox16.Enabled = false;
                textBox4.Text = null;
                textBox8.Text = null;
                textBox11.Text = null;
                textBox10.Text = null;
                textBox9.Text = null;
                textBox16.Text = null;

            }
            else
            {
                MessageBox.Show("ID Not founded");
            }



            con1.Close();
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Employee_Load(object sender, EventArgs e)
        {
            comboBox2.Items.Clear();
            SqlConnection con1 = new SqlConnection("Data Source=DESKTOP-0JE92F7;Initial Catalog=nappta;Integrated Security=True");
            SqlCommand cmde = new SqlCommand(@"select patient_ID from Patient ", con1);
            con1.Open();
            cmde.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmde);
            da.Fill(dt);
            foreach(DataRow dr in dt.Rows)
            {
                comboBox2.Items.Add(dr["patient_ID"].ToString());
            }
            con1.Close();
            SqlCommand cmdr = new SqlCommand(@"select Name from employee where employee_ID=@id ", con1);
            cmdr.Parameters.AddWithValue("@id", p_empID_Add);
            con1.Open();
            SqlDataReader dw = cmdr.ExecuteReader();
            while (dw.Read())
            {
                label8.Text = dw[0].ToString();
            }
        }

        private void Employee_FormClosed_1(object sender, FormClosedEventArgs e)
        {
            System.Windows.Forms.Application.ExitThread();
        }
    }

    
    }

/*
 
 SqlConnection con1 = new SqlConnection("Data Source=DESKTOP-0JE92F7;Initial Catalog=nappta;Integrated Security=True");
                SqlCommand cmde = new SqlCommand(@"update Patient set full_name=@name , phone_number=@phone ,Address=@adress,patient_birthday=@birthday,Dept_ID=@dipt,E_mail=@email,employee_ID= @employeeid,napta_id=@napta where patient_ID=@patin_id  ", con1);
                cmde.Parameters.AddWithValue("@id", textBox12.Text);
                con1.Open();
                SqlDataReader sr1 = cmde.ExecuteReader();
                if (sr1.Read())
                {
                    textBox13.Text = sr1[0].ToString();
                    comboBox2.Text = sr1[1].ToString();
                    textBox11.Text = sr1[2].ToString();
                    textBox10.Text = sr1[3].ToString();
                    textBox9.Text = sr1[4].ToString();
                    textBox8.Text = sr1[5].ToString();



                }
                else {
                    MessageBox.Show("ID Not founded");
                }



                con1.Close();

 
 
 
 
 
 
 */