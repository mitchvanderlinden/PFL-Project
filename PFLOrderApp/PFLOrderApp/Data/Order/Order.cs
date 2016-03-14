using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PFLOrderApp.Data.Order
{
    public class Order
    {

        public string OrderNumber { get; set; }
        public OrderCustomer OrderCustomer { get; set; }
        public List<OrderItem> Items { get; set; }
        public List<OrderShipment> Shipments { get; set; }
        public string PartnerOrderReference { get; set; }

    }
}