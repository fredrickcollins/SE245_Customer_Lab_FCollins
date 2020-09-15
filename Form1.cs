//import needed libraries
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

namespace Midterm
{
    public partial class Form1 : Form
    {

        bool editor = false;
        int personID = 0;

        //initialize windows form using the design we layed out
        public Form1()
        {
            InitializeComponent();
        }

        //overloaded constructor auto fills text boxes when passed a personID to edit
        public Form1(int p, bool editor)
        {
            InitializeComponent();
            this.editor = editor;
            this.personID = p;
            PersonV2 v = new PersonV2();
            SqlDataReader d = v.EditByID(p);
            
            while (d.Read())
            {
                firstnamebox.Text = d["FirstName"].ToString();
                middlenamebox.Text = d["MiddleName"].ToString();
                lastnamebox.Text = d["LastName"].ToString();
                street1box.Text = d["Street1"].ToString();
                street2box.Text = d["Street2"].ToString();
                citybox.Text = d["City"].ToString();
                statebox.Text = d["State"].ToString();
                zipcodebox.Text = d["Zip"].ToString();
                phonebox.Text = d["Phone"].ToString();
                cellphonebox.Text = d["Cell"].ToString();
                emailbox.Text = d["Email"].ToString();
                instagramurlbox.Text = d["Instagram"].ToString();
            }
            
            //altered user interface
            button1.Text = "Edit Person";

        }

        //create new instance of person class
        PersonV2 person = new PersonV2();

        //function fires on submit click
        private void button1_Click(object sender, EventArgs e)
        {

            //clear any previous feedback
            person.Feedback = "";

            //assign inputs to respective properties through set function
            person.FirstName = firstnamebox.Text;           
            person.MiddleName = middlenamebox.Text;            
            person.LastName = lastnamebox.Text;         
            person.Street1 = street1box.Text;          
            person.Street2 = street2box.Text;          
            person.City = citybox.Text;            
            person.State = statebox.Text;          
            person.Zip = zipcodebox.Text;
            person.Phone = phonebox.Text;           
            person.Email = emailbox.Text;            
            person.CellPhone = cellphonebox.Text;        
            person.InstagramURL = instagramurlbox.Text;

            //retrieve and label respective properties on form through get function
            firstnamelabel.Text = person.FirstName;
            middlenamelabel.Text = person.MiddleName;
            lastnamelabel.Text = person.LastName;
            street1label.Text = person.Street1;
            street2label.Text = person.Street2;
            citylabel.Text = person.City;
            statelabel.Text = person.State;
            zipcodelabel.Text = person.Zip;
            phonelabel.Text = person.Phone;
            emaillabel.Text = person.Email;
            cellphonelabel.Text = person.CellPhone;
            instagramurllabel.Text = person.InstagramURL;

            //display feedback
            validlabel.Text = person.Feedback;

            //add a record or update one depending on the mode we're in
            if (person.Feedback.Length == 0 && editor == false)
            {
                validlabel.Text = person.AddARecord();
            }
            else if (person.Feedback.Length == 0 && editor == true)
            {
                validlabel.Text = person.UpdatePerson(personID);
            }
        }

        

    }
}
