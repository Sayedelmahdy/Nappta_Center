using System.Data.SqlClient;

namespace Nappta_Center
{
    public partial class Form1 : Form
    {
      
       
        private Form CallingForm = null;
        public Form1(Form callingForm) : this()
        {
            this.CallingForm = callingForm;
        }
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection con1 = new SqlConnection("Data Source=DESKTOP-0JE92F7;Initial Catalog=nappta;Integrated Security=True");
            SqlConnection con2 = new SqlConnection("Data Source=DESKTOP-0JE92F7;Initial Catalog=nappta;Integrated Security=True");
            //database
            SqlCommand cmde = new SqlCommand(@"select * from employee where employee_ID='" + int.Parse(textBox1.Text) + "'and password='" + textBox2.Text + "'", con1);
            SqlCommand cmds = new SqlCommand(@"select * from Specialist where Specialist_id='" + int.Parse(textBox1.Text) + "'and password='" + textBox2.Text + "'", con2);
            con1.Open();
            con2.Open();
           SqlDataReader sr1= cmde.ExecuteReader();
           SqlDataReader sr2= cmds.ExecuteReader();
            if (sr1.Read())
            {
                this.Hide();
                //c.ShowDialog();
                //this.Close();
                Employee f2 = new Employee(this, textBox1.Text);
                f2.Show();

            }
            else if (sr2.Read())
            {
                this.Hide();
                //c.ShowDialog();
                //this.Close();
                Specialist f2 = new Specialist(this, textBox1.Text);
                f2.Show();

            }
            else if (textBox1.Text == "123344" && textBox2.Text == "admin")
            {
                this.Hide();
                //c.ShowDialog();
                //this.Close();
                ADMIN f2 = new ADMIN(this, textBox1.Text);
                f2.Show();
            }
            else
            {
                MessageBox.Show("invalid username or password ");
            }
            con1.Close();
            con2.Close();
            
        }


        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
           
        }
        private void textBox2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SqlConnection con1 = new SqlConnection("Data Source=DESKTOP-0JE92F7;Initial Catalog=nappta;Integrated Security=True");
                SqlConnection con2 = new SqlConnection("Data Source=DESKTOP-0JE92F7;Initial Catalog=nappta;Integrated Security=True");
                //database
                SqlCommand cmde = new SqlCommand(@"select * from employee where employee_ID='" + int.Parse(textBox1.Text) + "'and password='" + textBox2.Text + "'", con1);
                SqlCommand cmds = new SqlCommand(@"select * from Specialist where Specialist_id='" + int.Parse(textBox1.Text) + "'and password='" + textBox2.Text + "'", con2);
                con1.Open();
                con2.Open();
                SqlDataReader sr1 = cmde.ExecuteReader();
                SqlDataReader sr2 = cmds.ExecuteReader();
                if (sr1.Read())
                {
                    this.Hide();
                    //c.ShowDialog();
                    //this.Close();
                    Employee f2 = new Employee(this, textBox1.Text);
                    f2.Show();

                }
                else if (sr2.Read())
                {
                    this.Hide();
                    //c.ShowDialog();
                    //this.Close();
                    Specialist f2 = new Specialist(this, textBox1.Text);
                    f2.Show();

                }
                else if (textBox1.Text == "123344" && textBox2.Text == "admin")
                {
                    this.Hide();
                    //c.ShowDialog();
                    //this.Close();
                    ADMIN f2 = new ADMIN(this, textBox1.Text);
                    f2.Show();
                }
                else
                {
                    MessageBox.Show("invalid username or password ");
                }
                con1.Close();
                con2.Close();

            }
        }

        private void textBox1_KeyDown_1(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SqlConnection con1 = new SqlConnection("Data Source=DESKTOP-0JE92F7;Initial Catalog=nappta;Integrated Security=True");
                SqlConnection con2 = new SqlConnection("Data Source=DESKTOP-0JE92F7;Initial Catalog=nappta;Integrated Security=True");
                //database
                SqlCommand cmde = new SqlCommand(@"select * from employee where employee_ID='" + int.Parse(textBox1.Text) + "'and password='" + textBox2.Text + "'", con1);
                SqlCommand cmds = new SqlCommand(@"select * from Specialist where Specialist_id='" + int.Parse(textBox1.Text) + "'and password='" + textBox2.Text + "'", con2);
                con1.Open();
                con2.Open();
                SqlDataReader sr1 = cmde.ExecuteReader();
                SqlDataReader sr2 = cmds.ExecuteReader();
                if (sr1.Read())
                {
                    this.Hide();
                    //c.ShowDialog();
                    //this.Close();
                    Employee f2 = new Employee(this,textBox1.Text);
                    f2.Show();

                }
                else if (sr2.Read())
                {
                    this.Hide();
                    //c.ShowDialog();
                    //this.Close();
                    Specialist f2 = new Specialist(this, textBox1.Text);
                    f2.Show();

                }
                else if (textBox1.Text == "123344" && textBox2.Text == "admin")
                {
                    this.Hide();
                    //c.ShowDialog();
                    //this.Close();
                    ADMIN f2 = new ADMIN(this, textBox1.Text);
                    f2.Show();
                }
                else
                {
                    MessageBox.Show("invalid username or password ");
                }
                con1.Close();
                con2.Close();


            }
        }

        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
          
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            System.Windows.Forms.Application.ExitThread();
        }
    }
}