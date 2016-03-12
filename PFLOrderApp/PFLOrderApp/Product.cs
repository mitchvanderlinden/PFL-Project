using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PFLOrderApp
{
    public class Product
    {

        public int id { get; set; }
        public int productID { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public string imageURL { get; set; }
        public bool hasTemplate { get; set; }

    }
}