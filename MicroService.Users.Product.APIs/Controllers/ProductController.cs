using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MicroService.Users.Data.DataContext.Interface;
using MicroService.Users.Data.Models;
using MicroService.Users.Product.APIs.DTOs.Request;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace MicroService.Users.Product.APIs.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : ControllerBase
    {


        private readonly ILogger<ProductController> _logger;
        private readonly IProductDbContext _productDbContext;

        public ProductController(ILogger<ProductController> logger, IProductDbContext productDbContext)
        {
            _logger = logger;
            _productDbContext = productDbContext;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<MicroService.Users.Data.Models.Product>>> Get()
        {
            return Ok(_productDbContext.Products.ToList());
        }

        [HttpPost]
        public async Task<ActionResult<MicroService.Users.Data.Models.Product>> Post([FromBody] ProductDTO productDTO)
        {
            var product = new MicroService.Users.Data.Models.Product()
            {
                ProductName = productDTO.ProductName,
                Quantity = productDTO.Quantity
            };
            _productDbContext.Products.Add(product);
            await _productDbContext.SaveChangesAsync();
            return Ok(_productDbContext.Products.First(x => x.ProductId == product.ProductId));
        }

        [HttpGet("/getbyId")]
        public async Task<ActionResult<MicroService.Users.Data.Models.Product>> GetById(Guid ProductId)
        {
            return Ok(_productDbContext.Products.First(x => x.ProductId == ProductId));
        }
    }
}
