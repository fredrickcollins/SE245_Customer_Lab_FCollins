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
                            city, state, zip, phone, email;

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
        }

            //get and set helper functions to allow access to private properties from outside classes
            public String FirstName
            {
                get
                {
                    return firstName;
                }
                set
                {
                    firstName = value;
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
                    middleName = value;
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
                    lastName = value;
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
                    street1 = value;
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
                    street2 = value;
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
                    city = value;
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
                    state = value;
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
                    zip = value;
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
                    phone = value;
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
                    email = value;
                }
            }

        }
}