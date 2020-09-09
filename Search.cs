//import needed libraries
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Midterm
{
    public partial class Search : Form
    {

        //initialize search form
        public Search()
        {
            InitializeComponent();
        }

        //handle search button click
        private void button1_Click(object sender, EventArgs e)
        {
            PersonV2 p = new PersonV2();

            //searching by ID
            if (textBox1.Text.Length > 0)
            {
                DataSet ds = p.FindByID(int.Parse(textBox1.Text));
                dataGridView1.DataSource = ds;
                dataGridView1.DataMember = ds.Tables["Results"].ToString();
            }
            //searching by last name
            else if (textBox2.Text.Length > 0)
            {
                DataSet ds = p.FindByName(textBox2.Text);
                dataGridView1.DataSource = ds;
                dataGridView1.DataMember = ds.Tables["Results"].ToString();
            }
            //displaying all
            else
            {
                DataSet ds = p.FindAll();
                dataGridView1.DataSource = ds;
                dataGridView1.DataMember = ds.Tables["Results"].ToString();
            }
            
            
        }

        //open editor form on cell content click with values prefilled
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            Form1 editing = new Form1(int.Parse(dataGridView1.Rows[e.RowIndex].Cells[12].Value.ToString()));
            editing.ShowDialog();
        }
    }
}
