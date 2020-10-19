using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MicroService.User.API.DTOs;
using MicroService.Users.Data.DataContext.Interface;
using MicroService.Users.Data.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace MicroService.User.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {


        private readonly ILogger<UsersController> _logger;
        private IUsersDbConext _usrContext;

        public UsersController(ILogger<UsersController> logger, IUsersDbConext usersDbConext)
        {
            _logger = logger;
            _usrContext = usersDbConext;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<MicroService.Users.Data.Models.User>>> Get()
        {
            return Ok(_usrContext.Users.ToList());
        }

        [HttpPost]
        public async Task<ActionResult<IEnumerable<MicroService.Users.Data.Models.User>>> Post([FromBody] UserDTO userDTO)
        {
            var user = new MicroService.Users.Data.Models.User()
            {
                Age = userDTO.Age,
                FirstName = userDTO.FirstName,
                Gender = userDTO.Gender,
                LastName = userDTO.LastName
            };
            _usrContext.Users.Add(user);
            await _usrContext.SaveChangesAsync();
            return Ok(_usrContext.Users.First(x => x.Id == user.Id));
        }

        [HttpGet("/getbyId")]
        public async Task<ActionResult<MicroService.Users.Data.Models.User>> GetById(Guid UserId)
        {
            return Ok(_usrContext.Users.First(x=>x.Id==UserId));
        }
    }
}
