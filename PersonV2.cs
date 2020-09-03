using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Midterm {
    
    //PersonV2 class inherits properties from Person class
    class PersonV2 : Person {

        //define object properties
        private String cellPhone, instagramURL, firstName, middleName, lastName, street1, street2,
                            city, state, zip, phone, email;

        //constructor sets default property values
        public PersonV2() {
            cellPhone = "";
            instagramURL = "";
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

        //get and set functions to allow access and modification of private properties
        public String CellPhone {
            get {
                return cellPhone;
            }
            set {
                cellPhone = value;
            }
        }

        public String InstagramURL {
            get {
                return instagramURL;
            }
            set {
                instagramURL = value;
            }
        }

    }
}
