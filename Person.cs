//import needed libraries
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Midterm
{
        public class Person
        {
        //define properties
        private String firstName, middleName, lastName, street1, street2,
                        city, state, zip, phone, email, feedback;

        //constructor sets default property values
        public Person() {
            firstName = "";
            middleName = "";
            lastName = "";
            street1 = "";
            street2 = "";
            city = "";
            state = "";
            zip = "";
            phone = "";
            email = "";
            feedback = "";
        }

            //get and set helper functions to allow access to private properties from outside classes
            //each set function has built in validation, returns error feedback if there is any
            public String FirstName
            {
                get
                {
                    return firstName;
                }
                set
                {
                if (value.ToLower().Contains("homework"))
                {
                    Feedback += "Bad word in First Name\n";
                }
                if (value.Any(char.IsDigit))
                {
                    Feedback += "Number in First Name\n";
                }
                if (value.Length == 0)
                {
                    Feedback += "First Name empty\n";
                }
                if (Feedback.Length == 0) 
                {
                    firstName = value;
                }
                }
            }

            public String MiddleName
            {
                get
                {
                    return middleName;
                }
                set
                {
                if (value.ToLower().Contains("homework"))
                {
                    Feedback += "Bad word in Middle Name\n";
                }
                if (value.Any(char.IsDigit))
                {
                    Feedback += "Number in Middle Name\n";
                }
                if (value.Length == 0)
                {
                    Feedback += "Middle Name empty\n";
                }
                if (Feedback.Length == 0)
                {
                    middleName = value;
                }
            }
            }

            public String LastName
            {
                get
                {
                    return lastName;
                }
                set
                {
                if (value.ToLower().Contains("homework"))
                {
                    Feedback += "Bad word in Last Name\n";
                }
                if (value.Any(char.IsDigit))
                {
                    Feedback += "Number in Last Name\n";
                }
                if (value.Length == 0)
                {
                    Feedback += "Last Name empty\n";
                }
                if (Feedback.Length == 0)
                {
                    lastName = value;
                }
            }
            }

            public String Street1
            {
                get
                {
                    return street1;
                }
                set
                {
                if (value.ToLower().Contains("homework"))
                {
                    Feedback += "Bad word in Street1\n";
                }
                if (value.Length == 0)
                {
                    Feedback += "Street1 empty\n";
                }
                if (Feedback.Length == 0)
                {
                    street1 = value;
                }
            }
            }

            public String Street2
            {
                get
                {
                    return street2;
                }
                set
                {
                if (value.ToLower().Contains("homework"))
                {
                    Feedback += "Bad word in Street 2\n";
                }
                if (value.Length == 0)
                {
                    Feedback += "Street2 empty\n";
                }
                if (Feedback.Length == 0)
                {
                    street2 = value;
                }
            }
            }

            public String City
            {
                get
                {
                    return city;
                }
                set
                {
                if (value.ToLower().Contains("homework"))
                {
                    Feedback += "Bad word in City\n";
                }
                if (value.Any(char.IsDigit))
                {
                    Feedback += "Number in City\n";
                }
                if (value.Length == 0)
                {
                    Feedback += "City empty\n";
                }
                if (Feedback.Length == 0)
                {
                    city = value;
                }
            }
            }

            public String State
            {
                get
                {
                    return state;
                }
                set
                {
                if (value.ToLower().Contains("homework"))
                {
                    Feedback += "Bad word in State\n";
                }
                if (value.Any(char.IsDigit))
                {
                    Feedback += "Number in State\n";
                }
                if (value.Length != 2)
                {
                    Feedback += "State not 2 Characters\n";
                }
                if (Feedback.Length == 0)
                {
                    state = value;
                }
            }
            }

            public String Zip
            {
                get
                {
                    return zip;
                }
                set
                {
                if (!value.All(char.IsDigit))
                {
                    Feedback += "Letters in Zip\n";
                }
                if (value.Length != 5)
                {
                    Feedback += "Zip not 5 Characters\n";
                }
                if (Feedback.Length == 0)
                {
                    zip = value;
                }
            }
            }

            public String Phone
            {
                get
                {
                    return phone;
                }
                set
                {
                if (!value.All(char.IsDigit))
                {
                    Feedback += "Letters in Phone\n";
                }
                if (value.Length != 10)
                {
                    Feedback += "Phone not 10 Characters\n";
                }
                if (value.Length == 0)
                {
                    Feedback += "Phone empty\n";
                }
                if (Feedback.Length == 0)
                {
                    phone = value;
                }
            }
            }

            public String Email
            {
                get
                {
                    return email;
                }
                set
                {
                if (!(value.IndexOf(".") > value.IndexOf("@")) & value.Contains("@"))
                {
                    Feedback += "Email suffix not valid\n";
                }
                if (value.IndexOf(".")+1 == value.Length)
                {
                    Feedback += "Email domain not valid\n";
                }
                if (value.Length == 0)
                {
                    Feedback += "Email empty\n";
                }
                if(Feedback.Length == 0)
                {
                    email = value;
                }
                }
            }

            public String Feedback
            {
                get
                {
                return feedback;
                }
                set
                {
                feedback = value;
                }
            }

        }
}