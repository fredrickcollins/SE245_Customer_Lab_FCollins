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
using System.Data.SqlClient;

namespace Midterm
{
    public partial class Form1 : Form
    {

        //initialize windows form using the design we layed out
        public Form1()
        {
            InitializeComponent();
        }

        PersonV2 person = new PersonV2();
        int personID = 0;

        //function fires on submit click
        private void button1_Click(object sender, EventArgs e)
        {

            //check length-sensitive inputs for validity, return error message and abort submission if invalid
            Boolean invalid = false;

            if (Basic_Tools.errorZip(zipcodebox.Text))
            {
                zipcodebox.Text = "Invalid length";
                invalid = true;
            }
            if (Basic_Tools.errorEmail(emailbox.Text))
            {
                emailbox.Text = "Invalid email";
                invalid = true;
            }
            if (Basic_Tools.errorState(statebox.Text))
            {
                statebox.Text = "Invalid length";
                invalid = true;
            }
            if (Basic_Tools.errorIG(instagramurlbox.Text))
            {
                instagramurlbox.Text = "Invalid URL";
                invalid = true;
            }

            //exit function if input lengths are not proper
            if (invalid)
            {
                return;
            }

            //all input lengths check out
            //create new instance of person class, assign inputs to respective properties through set function
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

            //validate datatypes of inputs and send feedback
            //exit function or proceed depending on validity
            if (!Basic_Tools.validate(person)) {
                validlabel.Text = "One or more of your inputs was an invalid datatype. \nPlease try again.";
                return;
            }

            //retrieve and label respective properties on form through get function
            validlabel.Text = "";
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

            validlabel.Text = AddARecord();
        }

        public string AddARecord()
        {
            //Init string var
            string strResult = "";

            //Make a connection object
            SqlConnection Conn = new SqlConnection();

            //Initialize it's properties
            Conn.ConnectionString = @"Server=sql.neit.edu\sqlstudentserver,4500;Database=SE245_FCollins;User Id=SE245_FCollins;Password=008006819;";     //Set the Who/What/Where of DB


            //*******************************************************************************************************
            // NEW
            //*******************************************************************************************************
            string strSQL = "INSERT INTO PersonV2 (FirstName, MiddleName, LastName, Street1, Street2, City, State, Zip, Phone, Cell, Email, Instagram, PersonID) " +
                            "VALUES (@FirstName, @MiddleName, @LastName, @Street1, @Street2, @City, @State, @Zip, @Phone, @Cell, @Email, @Instagram, @PersonID)";
            // Bark out our command
            SqlCommand comm = new SqlCommand();
            comm.CommandText = strSQL;  //Commander knows what to say
            comm.Connection = Conn;     //Where's the phone?  Here it is

            //Fill in the paramters (Has to be created in same sequence as they are used in SQL Statement)
            comm.Parameters.AddWithValue("@FirstName", person.FirstName);
            comm.Parameters.AddWithValue("@MiddleName", person.MiddleName);
            comm.Parameters.AddWithValue("@LastName", person.LastName);
            comm.Parameters.AddWithValue("@Street1", person.Street1);
            comm.Parameters.AddWithValue("@Street2", person.Street2);
            comm.Parameters.AddWithValue("@City", person.City);
            comm.Parameters.AddWithValue("@State", person.State);
            comm.Parameters.AddWithValue("@Zip", person.Zip);
            comm.Parameters.AddWithValue("@Phone", person.Phone);
            comm.Parameters.AddWithValue("@Cell", person.CellPhone);
            comm.Parameters.AddWithValue("@Email", person.Email);
            comm.Parameters.AddWithValue("@Instagram", person.InstagramURL);
            comm.Parameters.AddWithValue("@PersonID", personID);

            //*******************************************************************************************************

            //attempt to connect to the server
            try
            {
                Conn.Open();                                        //Open connection to DB - Think of dialing a friend on phone
                int intRecs = comm.ExecuteNonQuery();
                strResult = $"SUCCESS: Inserted {intRecs} records.";       //Report that we made the connection and added a record
                Conn.Close();                                       //Hanging up after phone call
                personID += 1;
                firstnamebox.Text = "";
                middlenamebox.Text = "";
                lastnamebox.Text = "";
                street1box.Text = "";
                street2box.Text = "";
                citybox.Text = "";
                statebox.Text = "";
                zipcodebox.Text = "";
                phonebox.Text = "";
                emailbox.Text = "";
                cellphonebox.Text = "";
                instagramurlbox.Text = "";
            }
            catch (Exception err)                                   //If we got here, there was a problem connecting to DB
            {
                strResult = "ERROR: " + err.Message;                //Set feedback to state there was an error & error info
                Console.WriteLine(err.Message);
            }
            finally
            {

            }



            //Return resulting feedback string
            return strResult;
        }

    }
}
