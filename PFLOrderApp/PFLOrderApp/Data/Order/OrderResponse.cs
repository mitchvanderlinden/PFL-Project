using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PFLOrderApp.Data.Order
{
    public class OrderResponse
    {

        public APIMetaData meta
        {
            get;
            set;
        }

        public OrderResults results
        {
            get;
            set;
        }

    }
}