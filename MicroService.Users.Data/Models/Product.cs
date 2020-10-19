using System;
using System.Collections.Generic;
using System.Text;

namespace MicroService.Users.Data.Models
{
    public class Product
    {
        public  Guid ProductId   { get; set; }
        public string ProductName { get; set; }
        public int Quantity { get; set; }
    }
}
