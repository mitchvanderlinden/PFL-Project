using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PFLOrderApp.Data.Order
{
    public class OrderResults
    {

        public List<APIError> errors
        {
            get;
            set;
        }
        public Order data
        {
            get;
            set;
        }

    }
}