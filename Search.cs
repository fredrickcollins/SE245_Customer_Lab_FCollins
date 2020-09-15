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

        bool editor = false;
        bool deleter = false;
        int x = 1;

        //initialize search form
        //user interface prompt for adding edited copies
        public Search()
        {
            InitializeComponent();
            label4.Text = "Edited entries are made as copies";
        }

        //user interface prompt for editing records
        public Search(bool editor)
        {
            InitializeComponent();
            this.editor = editor;
            label4.Text = "Edited entries overwrite";
        }

        //user interface for deleting records
        public Search(int deleter)
        {
            InitializeComponent();
            this.deleter = true;
            label4.Text = "Clicked entries DELETED";
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

        //do appropriate action with selected record depending on mode
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //edit mode
            if (editor)
            {
                Form1 editing = new Form1(int.Parse(dataGridView1.Rows[e.RowIndex].Cells[12].Value.ToString()), true);
                editing.ShowDialog();
            }
            //adding mode
            else if (editor == false && deleter == false)
            {
                Form1 editing = new Form1(int.Parse(dataGridView1.Rows[e.RowIndex].Cells[12].Value.ToString()), false);
                editing.ShowDialog();
            }
            //deleting mode
            else if (deleter)
            {
                PersonV2 p = new PersonV2();
                label5.Text = p.DeletePerson(int.Parse(dataGridView1.Rows[e.RowIndex].Cells[12].Value.ToString())) + " (" + x + ")";
                x += 1;
                //update records on form to reflect deleted record
                DataSet ds = p.FindAll();
                dataGridView1.DataSource = ds;
                dataGridView1.DataMember = ds.Tables["Results"].ToString();
            }
            
        }
    }
}
