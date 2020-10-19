using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MicroService.Users.Product.APIs.DTOs.Request
{
    public class ProductDTO
    {
        public string ProductName { get; set; }
        public int Quantity { get; set; }
    }
}
