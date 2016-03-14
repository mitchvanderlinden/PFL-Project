using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PFLOrderApp.Data.Order
{
    public class OrderItem
    {

        public short ItemSequenceNumber { get; set; }
        public int ProductID { get; set; }
        public int Quantity { get; set; }
        public int ItemID { get; set; }

    }
}