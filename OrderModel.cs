using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace MVC_Web_API_orders.Models
{
    public class OrderModel
    {
       public int orderid { get; set; }
        public string customermobileno { get; set; }
        public string itemname { get; set; }
        public int itemprice { get; set; }
        public int itemquantity { get; set; }

    }
}