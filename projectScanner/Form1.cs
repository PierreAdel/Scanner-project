using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace projectScanner
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        public void ViewOutput(int length,String[,] Output) //called by scanner to print output
        {

            Form1 form1 = this;

            
            form1.label1.Text = "Compiled succsefully";
            form1.label1.Visible = true;
            button2.Enabled = true;
            button3.Enabled = true;

            DataTable dt = new DataTable();
            dt.Columns.Add("Lexeme", typeof(string));
            dt.Columns.Add("Token", typeof(string));
            dataGridView1.DataSource = dt;
             

            DataRow row1;
            
          

            for (int i = 0; i < length; i++)
            {
                row1 = dt.NewRow();
                row1["Lexeme"] = Output[i,0];
                row1["Token"] = Output[i, 1];
                dt.Rows.Add(row1);
            }
            


            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            label1.Text = "Compiling ...";
            label1.Visible = true;
            button2.Enabled = false;
            button3.Enabled = false;
            dataGridView1.Visible = false;
            richTextBox1.Visible = true;
            
            Scanner scan = new Scanner(richTextBox1.Text,this);
            scan.Start_Scan();

        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            dataGridView1.Visible = false;
            richTextBox1.Visible = true;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            richTextBox1.Visible = false;
            dataGridView1.Visible = true;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
