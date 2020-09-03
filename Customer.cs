using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Midterm
{

    //Customer class inherits PersonV2 properties
    class Customer : PersonV2 {

        //define properties
        private DateTime customerSince;
        private double totalPurchases;
        private bool discountMember;
        private int rewardsEarned;

        //constructor sets properties to default values
        public Customer() {
            customerSince = DateTime.Now;
            totalPurchases = 0;
            discountMember = false;
            rewardsEarned = 0;
        }

        //get and set functions to allow access and modification of private properties
        public DateTime CustomerSince {
            get {
                return customerSince;
            }
            set {
                customerSince = value;
            }
        }

        public double TotalPurchases {
            get {
                return totalPurchases;
            }
            set {
                totalPurchases = value;
            }
        }

        public bool DiscountMember {
            get {
                return discountMember;
            }
            set {
                discountMember = value;
            }
        }

        public int RewardsEarned{
            get {
                return rewardsEarned;
            }
            set {
                rewardsEarned = value;
            }
        }

    }
}
