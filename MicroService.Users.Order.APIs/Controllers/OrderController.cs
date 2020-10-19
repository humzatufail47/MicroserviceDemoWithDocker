using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using MicroService.Users.Data.DataContext.Interface;
using MicroService.Users.Order.APIs.DTOs;
using MicroService.Users.Order.APIs.DTOs.Request;
using MicroService.Users.Product.APIs.DTOs.Response;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace MicroService.Users.Order.APIs.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrderController : ControllerBase
    {

        private readonly ILogger<OrderController> _logger;
        private readonly IOrderContext _orderContext;
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IConfiguration _configuration;

        public OrderController(ILogger<OrderController> logger, IOrderContext orderContext, IHttpClientFactory httpClientFactory,
            IConfiguration configuration)
        {
            _logger = logger;
            _orderContext = orderContext;
            _httpClientFactory = httpClientFactory;
            _configuration = configuration;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<MicroService.Users.Data.Models.Order>>> Get()
        {
            return Ok(_orderContext.Orders.ToList());
        }

        [HttpGet("/getbyId")]
        public async Task<ActionResult<OrderInfo>> GetById(Guid OrderId)
        {
            var orderdata = _orderContext.Orders.FirstOrDefault(x => x.OrderId == OrderId);
            var usersClinet = _httpClientFactory.CreateClient("UsersApi");
            usersClinet.BaseAddress = new Uri(_configuration["USER_API_URL"]);
            var result = await usersClinet.GetAsync($"/api/getById/{orderdata.CustomerId}");
            var stream = await result.Content.ReadAsStringAsync();
            var CustomerData = JsonConvert.DeserializeObject<UserInfo>(stream);

            var ProductClinet = _httpClientFactory.CreateClient("ProductApi");
            ProductClinet.BaseAddress = new Uri(_configuration["PRODUCT_API_URL"]);
            var result1 = await usersClinet.GetAsync($"/api/getById/{orderdata.CustomerId}");
            var stream1 = await result.Content.ReadAsStringAsync();
            var ProductData = JsonConvert.DeserializeObject<ProductInfo>(stream);
            return Ok(new OrderInfo()
            {
                Age = CustomerData.Age,
                FirstName = CustomerData.FirstName,
                Gender = CustomerData.Gender,
                LastName = CustomerData.LastName,
                ProductName = ProductData.ProductName
            }
                );
        }
    }
}
