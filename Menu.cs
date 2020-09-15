//import needed libaries
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
    public partial class Menu : Form
    {
        //initialize form
        public Menu()
        {
            InitializeComponent();
        }

        //create new instance of the add user form on button click
        private void button1_Click(object sender, EventArgs e)
        {
            Form1 adding = new Form1();
            adding.Show();
        }

        //create new instance of the search user form on button click
        private void button2_Click(object sender, EventArgs e)
        {
            Search searching = new Search();
            searching.Show();
        }

        //create a new instance of the search user form using the editing mode overloaded constructor
        private void button4_Click(object sender, EventArgs e)
        {
            Search editing = new Search(true);
            editing.Show();
        }

        //create a new instance of the search user form using the delete mode overloaded constructor
        private void button3_Click(object sender, EventArgs e)
        {
            Search deleting = new Search(1);
            deleting.Show();
        }
    }
}
