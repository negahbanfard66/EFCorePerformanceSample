using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCorePerformanceTips.CoreLayer.Entities
{
    public class Order
    {
        public int OrderId { get; set; } 
        public int CustomerId { get; set; } 
        public int Price { get; set; } 
        public Customer Custoemr { get; set; }
    }
}
