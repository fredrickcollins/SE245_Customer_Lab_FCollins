//import needed libraries
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Midterm
{

    //basic tools class with helper functions for validating user input
    class Basic_Tools
    {

        //helper function determines if a string is numberic or not
        public static bool isNumeric(string text) {
            double test;
            return double.TryParse(text, out test);
        }

        //validation feedback method, returns whether all inputs are proper datatypes
        public static Boolean validate(PersonV2 p) {

            if (isNumeric(p.FirstName) || isNumeric(p.MiddleName) || isNumeric(p.LastName) || isNumeric(p.Street1) || isNumeric(p.Street2)
                || isNumeric(p.City) || isNumeric(p.State) || isNumeric(p.Email) || isNumeric(p.InstagramURL)) {
                return false;
            }
            if(!isNumeric(p.Zip) || !isNumeric(p.Phone) || !isNumeric(p.CellPhone)) {
                return false;
            }
            return true;        

        }

        //check zipcode input against length limit, return true or false
        public static Boolean errorZip(String zip)
        {
            if (zip.Length > 5) {
                return true;
            }
            return false;
        }

        //check email input against length limit, contains @, return true or false
        public static Boolean errorEmail(String email)
        {
            if (email.Length > 8)
            {
                return true;
            }
            if (!email.Contains("@"))
            {
                return true;
            }
            return false;
        }

        //check state input against length limit, return true or false
        public static Boolean errorState(String state)
        {
            if (state.Length > 2)
            {
                return true;
            }
            return false;
        }

        //check instagram url for validity, return true or false
        public static Boolean errorIG(String url)
        {
            if (!url.ToLower().StartsWith("instagram.com/"))
            {
                return true;
            }
            return false;
        }

    }
}
