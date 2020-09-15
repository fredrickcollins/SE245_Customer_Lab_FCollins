//import needed libraries
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace Midterm {
    
    //PersonV2 class inherits properties from Person class
    class PersonV2 : Person {

        //define object properties
        private String cellPhone, instagramURL;
        private String connectionString = @"Server=sql.neit.edu\sqlstudentserver,4500;Database=SE245_FCollins;User Id=SE245_FCollins;Password=008006819;";

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
            Conn.ConnectionString = connectionString;

            string strSQL = "INSERT INTO PersonV2 (FirstName, MiddleName, LastName, Street1, Street2, City, State, Zip, Phone, Cell, Email, Instagram) " +
                            "VALUES (@FirstName, @MiddleName, @LastName, @Street1, @Street2, @City, @State, @Zip, @Phone, @Cell, @Email, @Instagram)";
            
            //Create command
            SqlCommand comm = new SqlCommand();
            comm.CommandText = strSQL;
            comm.Connection = Conn;   

            //Fill in the paramters
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

            //try to establish a connection with the server
            try
            {
                Conn.Open();                                        //Open connection
                int intRecs = comm.ExecuteNonQuery();
                strResult = $"SUCCESS: Inserted {intRecs} records.";       //Display status
                Conn.Close();                                       //Close connection
            }
            catch (Exception err)                                   //Error handling
            {
                strResult = "ERROR: " + err.Message;                //Set feedback to state there was an error
                Console.WriteLine(err.Message);
            }
            finally
            {

            }
            //Return resulting feedback string
            return strResult;
        }


        //search the db by person ID
        public DataSet FindByID(int PersonID)
        {
            //database tools
            SqlConnection conn = new SqlConnection();
            SqlCommand comm = new SqlCommand();
            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter();

            //set connection properties
            string strConn = connectionString;
            //SQL command string to search by ID
            string sqlString =
           "SELECT * FROM PersonV2 WHERE PersonID = @PersonID;";
            conn.ConnectionString = strConn;

            //Give the command object info it needs
            comm.Connection = conn;
            comm.CommandText = sqlString;
            comm.Parameters.AddWithValue("@PersonID", PersonID);
            da.SelectCommand = comm;

            //Open the connection and send SQL Command
            conn.Open();
            da.Fill(ds, "Results");
            conn.Close();

            return ds;   //Return the dataset to be used
        }


        public DataSet FindByName(string LastName)
        {
            //database tools
            SqlConnection conn = new SqlConnection();
            SqlCommand comm = new SqlCommand();
            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter();

            //set connection properties
            string strConn = connectionString;

            //sql command to search by name
            string sqlString =
           "SELECT * FROM PersonV2 WHERE LastName = @LastName;";

            conn.ConnectionString = strConn;

            //Give the command object info it needs
            comm.Connection = conn;
            comm.CommandText = sqlString;
            comm.Parameters.AddWithValue("@LastName", LastName);
            da.SelectCommand = comm;

            //Open the connection and send command
            conn.Open();
            da.Fill(ds, "Results");
            conn.Close();

            return ds;   
        }

        public SqlDataReader EditByID(int PersonID)
        {
            //database tools
            SqlConnection conn = new SqlConnection();
            SqlCommand comm = new SqlCommand();

            //set connection properties
            string strConn = connectionString;

            //SQL command to search by ID
            string sqlString =
           "SELECT * FROM PersonV2 WHERE PersonID = @PersonID;";

            conn.ConnectionString = strConn;

            //Give the command object info it needs
            comm.Connection = conn;
            comm.CommandText = sqlString;
            comm.Parameters.AddWithValue("@PersonID", PersonID);

            //Open the connection and execute command, return data given
            conn.Open();
            return comm.ExecuteReader();
        }

        public DataSet FindAll()
        {
            //database tools
            SqlConnection conn = new SqlConnection();
            SqlCommand comm = new SqlCommand();
            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter();

            //set connection properties
            string strConn = connectionString;
            //SQL command to select all
            string sqlString =
           "SELECT * FROM PersonV2;";

            conn.ConnectionString = strConn;

            //Give the command object info it needs
            comm.Connection = conn;
            comm.CommandText = sqlString;
            da.SelectCommand = comm;

            //open the connection and fill our table with the results
            conn.Open();
            da.Fill(ds, "Results");
            conn.Close();
            return ds;
        }

        public string UpdatePerson(int personID)
        {

            //database tools
            SqlConnection conn = new SqlConnection();
            SqlCommand comm = new SqlCommand();
            String strResult = "";

            //set connection properties
            string strConn = connectionString;
            //SQL command to update
            string sqlString =
            "UPDATE PersonV2 SET FirstName = @FirstName, MiddleName = @MiddleName, LastName = @LastName, Street1 = @Street1, Street2 = @Street2," +
            "City = @City, State = @State, Zip = @Zip, Phone = @Phone, Cell = @Cell, Email = @Email, Instagram = @Instagram WHERE PersonID = @PersonID;";

            conn.ConnectionString = strConn;
            comm.Connection = conn;
            comm.CommandText = sqlString;
            

            //Fill in the paramters
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
            comm.Parameters.AddWithValue("@PersonID", personID);

            //try to establish a connection with the server
            try
            {
                conn.Open();                                        //Open connection
                int intRecs = comm.ExecuteNonQuery();
                strResult = $"SUCCESS: Updated {intRecs} records.";       //Display status
                conn.Close();                                       //Close connection
            }
            catch (Exception err)                                   //Error handling
            {
                strResult = "ERROR: " + err.Message;                //Set feedback to state there was an error
                Console.WriteLine(err.Message);
            }
            finally
            {

            }

            return strResult;
        }

        public string DeletePerson(int personID)
        {

            //database tools
            SqlConnection conn = new SqlConnection();
            SqlCommand comm = new SqlCommand();
            String strResult = "";

            //set connection properties
            string strConn = connectionString;
            //SQL command to delete
            string sqlString =
            "DELETE FROM PersonV2 WHERE PersonID = @PersonID";

            conn.ConnectionString = strConn;
            comm.Connection = conn;
            comm.CommandText = sqlString;


            //Fill in the paramters
            comm.Parameters.AddWithValue("@PersonID", personID);

            //try to establish a connection with the server
            try
            {
                conn.Open();                                        //Open connection
                int intRecs = comm.ExecuteNonQuery();
                strResult = $"SUCCESS: Deleted {intRecs} records.";       //Display status
                conn.Close();                                       //Close connection
            }
            catch (Exception err)                                   //Error handling
            {
                strResult = "ERROR: " + err.Message;                //Set feedback to state there was an error
                Console.WriteLine(err.Message);
            }
            finally
            {

            }

            return strResult;
        }


    }
}
