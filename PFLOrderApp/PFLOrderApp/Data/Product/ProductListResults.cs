using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PFLOrderApp
{
    public class ProductListResults
    {

        public List<APIError> errors
        {
            get;
            set;
        }

        public List<Product> data
        {
            get;
            set;
        }

    }
}