using System;
using System.Collections.Generic;
using System.Text;

namespace MicroService.Users.Data.Models
{
    public class Order
    {
        public Guid OrderId { get; set; }
        public Guid ProductId { get; set; }
        public Guid CustomerId { get; set; }
    }
}
