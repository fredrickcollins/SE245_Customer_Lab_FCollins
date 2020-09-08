using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Midterm {
    
    //PersonV2 class inherits properties from Person class
    class PersonV2 : Person {

        //define object properties
       private String cellPhone, instagramURL;

        //constructor sets default property values
        public PersonV2() {
            cellPhone = "";
            instagramURL = "";
            new Person();
        }

        //get and set functions to allow access and modification of private properties
        //each set function has built in validation, returns error feedback if there is any
        public String CellPhone {
            get {
                return cellPhone;
            }
            set {
                if (!value.All(char.IsDigit))
                {
                    Feedback += "Letters in Cell\n";
                }
                if (value.Length != 10)
                {
                    Feedback += "Cell not 10 Characters\n";
                }
                if (Feedback.Length == 0)
                {
                    cellPhone = value;
                }
            }
        }

        public String InstagramURL {
            get {
                return instagramURL;
            }
            set {
                if (!value.StartsWith("instagram.com/"))
                {
                    Feedback += "Instagram URL not valid\n";
                }
                if (value.IndexOf("/") + 1 == value.Length)
                {
                    Feedback += "Instagram user not valid\n";
                }
                if(value.ToLower().Contains("homework"))
                {
                    Feedback += "Bad word in Instagram URL\n";
                }
                if (value.Length == 0)
                {
                    Feedback += "Instagram URL empty\n";
                }
                if (Feedback.Length == 0)
                {
                    instagramURL = value;
                }
            }
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
            string strSQL = "INSERT INTO PersonV2 (FirstName, MiddleName, LastName, Street1, Street2, City, State, Zip, Phone, Cell, Email, Instagram) " +
                            "VALUES (@FirstName, @MiddleName, @LastName, @Street1, @Street2, @City, @State, @Zip, @Phone, @Cell, @Email, @Instagram)";
            // Bark out our command
            SqlCommand comm = new SqlCommand();
            comm.CommandText = strSQL;  //Commander knows what to say
            comm.Connection = Conn;     //Where's the phone?  Here it is

            //Fill in the paramters (Has to be created in same sequence as they are used in SQL Statement)
            comm.Parameters.AddWithValue("@FirstName", FirstName);
            comm.Parameters.AddWithValue("@MiddleName", MiddleName);
            comm.Parameters.AddWithValue("@LastName", LastName);
            comm.Parameters.AddWithValue("@Street1", Street1);
            comm.Parameters.AddWithValue("@Street2", Street2);
            comm.Parameters.AddWithValue("@City", City);
            comm.Parameters.AddWithValue("@State", State);
            comm.Parameters.AddWithValue("@Zip", Zip);
            comm.Parameters.AddWithValue("@Phone", Phone);
            comm.Parameters.AddWithValue("@Cell", CellPhone);
            comm.Parameters.AddWithValue("@Email", Email);
            comm.Parameters.AddWithValue("@Instagram", InstagramURL);

            //*******************************************************************************************************

            //attempt to connect to the server
            try
            {
                Conn.Open();                                        //Open connection to DB - Think of dialing a friend on phone
                int intRecs = comm.ExecuteNonQuery();
                strResult = $"SUCCESS: Inserted {intRecs} records.";       //Report that we made the connection and added a record
                Conn.Close();                                       //Hanging up after phone call
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
