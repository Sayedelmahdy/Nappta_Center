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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;


namespace Nappta_Center
{
    public partial class Specialist : Form
    {
        public string s_id_Add;
        public string s_patient_Add;
        public string s_history_id_Add;
        public string s_oldrate_Add;
        public string s_newrate_Add;
        
        public string s_activity_Add;
        // public Form1 fr = new Form1();
        //SqlCommand command;
        //SqlDataAdapter
        public bool checkrandom(int num)
        {
            bool check = false;
            // data base
            if (check)
            {
                return false;
            }
            else
                return true;

        }
        public Random a = new Random();
   

        int MyNumber = 0;
        public void NewNumber1()
        {
            MyNumber = a.Next(10000, 9999999);

            if (checkrandom(MyNumber))
                textBox7.Text = MyNumber.ToString();
        }
      
        private Form CallingForm = null;
        public Specialist(Form callingForm,string id) : this()
        {
            this.CallingForm = callingForm;
            this.s_id_Add = id;
        }
        public Specialist()
        {
            InitializeComponent();
        }

        private void textBox7_Click(object sender, EventArgs e)
        {
            NewNumber1();
        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_Click(object sender, EventArgs e)
        {
           
        }

        private void Specialist_Load(object sender, EventArgs e)
        {
            comboBox1.Items.Clear();
            SqlConnection con2 = new SqlConnection("Data Source=DESKTOP-0JE92F7;Initial Catalog=nappta;Integrated Security=True");
            SqlCommand cmdf = new SqlCommand(@"select patient_id from History ", con2);
         
            con2.Open();

            cmdf.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmdf);
            da.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {
                comboBox1.Items.Add(dr["patient_id"].ToString());
            }
            con2.Close();
            SqlCommand cmdr = new SqlCommand(@"select specialist_name from Specialist where Specialist_id=@id ", con2);
            cmdr.Parameters.AddWithValue("@id", s_id_Add);
            con2.Open();
            SqlDataReader dw = cmdr.ExecuteReader();
            while(dw.Read())
            {
                label2.Text = dw[0].ToString();
            }



        }

        private void button1_Click(object sender, EventArgs e)
        {
        
              
         s_patient_Add = textBox1.Text;
         s_history_id_Add = textBox7.Text;
        s_oldrate_Add = textBox14.Text;
         s_newrate_Add = textBox4.Text;
         s_activity_Add = textBox6.Text;
            //database
            SqlConnection con1 = new SqlConnection("Data Source=DESKTOP-0JE92F7;Initial Catalog=nappta;Integrated Security=True");
            SqlCommand cmde = new SqlCommand(@"INSERT INTO History (old_rate,new_rate,date_tratment,activity_institution,patient_id,Specialist_id,history_id) VALUES(@old,@new,@date,@activ,@paid,@spid,@hist)", con1);
            cmde.Parameters.AddWithValue("@old", s_oldrate_Add);
            cmde.Parameters.AddWithValue("@new", s_newrate_Add);
            cmde.Parameters.AddWithValue("@date", dateTimePicker1.Value.ToString("MM/dd/yyyy"));
            cmde.Parameters.AddWithValue("@activ", s_activity_Add);
            cmde.Parameters.AddWithValue("@paid", int.Parse(s_patient_Add));
            cmde.Parameters.AddWithValue("@spid",int.Parse(s_id_Add) );
            cmde.Parameters.AddWithValue("@hist", int.Parse(s_history_id_Add));
            con1.Open();
            int row = cmde.ExecuteNonQuery();
            if (row > 0)
            {
                MessageBox.Show("DONE");
                textBox1.Text = null;
                textBox7.Text = null;
                textBox14.Text = null;
                textBox4.Text = null;
                dateTimePicker1.Text = default;
                textBox6.Text = null;
                comboBox1.Items.Clear();
                SqlConnection con2 = new SqlConnection("Data Source=DESKTOP-0JE92F7;Initial Catalog=nappta;Integrated Security=True");
                SqlCommand cmdf = new SqlCommand(@"select patient_id from History ", con2);
                con1.Close();
                con2.Open();

                cmdf.ExecuteNonQuery();
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(cmdf);
                da.Fill(dt);
                foreach (DataRow dr in dt.Rows)
                {
                    comboBox1.Items.Add(dr["patient_id"].ToString());
                }
                con1.Close();
                con2.Close();

            }
            else
            {
                MessageBox.Show("Not added successfully");
                con1.Close();
            }
           
        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.Hide();
            //c.ShowDialog();
            //this.Close();
            Form1 f2 = new Form1(this);
            f2.Show();
        }

        private void Specialist_FormClosing(object sender, FormClosingEventArgs e)
        {
            System.Windows.Forms.Application.ExitThread();
        }

        private void Specialist_FormClosed(object sender, FormClosedEventArgs e)
        {
            System.Windows.Forms.Application.ExitThread();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SqlConnection con1 = new SqlConnection("Data Source=DESKTOP-0JE92F7;Initial Catalog=nappta;Integrated Security=True");
            SqlCommand cmde = new SqlCommand(@"select * from History where patient_id=@id", con1);
            cmde.Parameters.AddWithValue("@id", comboBox1.Text);
            con1.Open();
            SqlDataReader sr1 = cmde.ExecuteReader();
            if (sr1.Read())
            {
                textBox15.Text = sr1[6].ToString() ;
                textBox9.Text = sr1[0].ToString(); ;
                textBox13.Text = sr1[1].ToString() ;
                textBox10.Text = sr1[3].ToString();
                dateTimePicker2.Value = Convert.ToDateTime(sr1[2]) ;
                textBox15.Enabled = true;
                textBox9.Enabled = true;
                textBox13.Enabled = true;
                textBox10.Enabled = true;
                dateTimePicker2.Enabled = true;
              

            }
            else
            {
                MessageBox.Show("ID Not founded");
            }



            con1.Close();

        }

        private void button5_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            SqlConnection con1 = new SqlConnection("Data Source=DESKTOP-0JE92F7;Initial Catalog=nappta;Integrated Security=True");
            SqlCommand cmde = new SqlCommand(@"UPDATE History set old_rate=@old,new_rate=@new,date_tratment=@date,activity_institution=@act,Specialist_id=@spid,history_id=@hisid WHERE patient_id=@patid", con1);
            cmde.Parameters.AddWithValue("@old", textBox9.Text);
            cmde.Parameters.AddWithValue("@new", textBox13.Text);
            cmde.Parameters.AddWithValue("@date", dateTimePicker2.Value.ToString("MM/dd/yyyy"));
            cmde.Parameters.AddWithValue("@act", textBox10.Text);
            cmde.Parameters.AddWithValue("@spid", int.Parse(s_id_Add));
            cmde.Parameters.AddWithValue("@hisid", textBox15.Text);
            cmde.Parameters.AddWithValue("@patid", comboBox1.Text);

            con1.Open();
            int sr1 = cmde.ExecuteNonQuery();
            if (sr1 > 0)
            {


                MessageBox.Show("row updated successfully");
                textBox13.Enabled = false;
                textBox9.Enabled = false;
                textBox10.Enabled = false;
                textBox15.Enabled = false;
               dateTimePicker2.Enabled = false;
                
                textBox13.Text = null;
                textBox15.Text = null;
                textBox10.Text = null;
                textBox9.Text = null;
                dateTimePicker2.Text = null;

            }
            else
            {
                MessageBox.Show("ID Not founded");
            }



            con1.Close();
            comboBox1.Text = null;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            SqlConnection con1 = new SqlConnection("Data Source=DESKTOP-0JE92F7;Initial Catalog=nappta;Integrated Security=True");
            SqlCommand cmde = new SqlCommand(@"delete from History where patient_id=@id", con1);
            cmde.Parameters.AddWithValue("@id", comboBox1.Text);
            con1.Open();
            int sr1 = cmde.ExecuteNonQuery();
            if (sr1 > 0)
            {
                comboBox1.Items.Clear();
                con1.Close();
                SqlCommand cmdf = new SqlCommand(@"select patient_id from History ", con1);
                con1.Open();
                cmdf.ExecuteNonQuery();
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(cmdf);
                da.Fill(dt);
                foreach (DataRow dr in dt.Rows)
                {
                    comboBox1.Items.Add(dr["patient_id"].ToString());
                }
                con1.Close();
                MessageBox.Show("Row has been deleted");

            }
            else
            {
                MessageBox.Show("ID Not founded");
                con1.Close();
            }

            comboBox1.Text = null;

        }
    }
}
