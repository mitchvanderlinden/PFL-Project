using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PFLOrderApp
{
    public class ProductListResponse
    {

        public APIMetaData meta
        {
            get;
            set;
        }

        public ProductListResults results
        {
            get;
            set;
        }

    }
}