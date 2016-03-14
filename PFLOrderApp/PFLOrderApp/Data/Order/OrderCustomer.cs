using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PFLOrderApp.Data.Order
{
    public class OrderCustomer
    {

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string CountryCode { get; set; }
        public string PostalCode { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }

    }
}