using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;

namespace  Mustakim
{
    public class Order
    {
        public int OrderId {get;set;}
        public string CustomerName {get; set;}
        public DateTime OrderDate {get;set;}
        public decimal TotalAmount{ get; set; }
        public string Status { get; set; }

      



       
        

    }
}