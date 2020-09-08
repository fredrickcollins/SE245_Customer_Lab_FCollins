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
    public partial class Form1 : Form
    {

        //initialize windows form using the design we layed out
        public Form1()
        {
            InitializeComponent();
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
            if (person.Feedback.Length == 0)
            {
                validlabel.Text = person.AddARecord();
            }
        }

        

    }
}
