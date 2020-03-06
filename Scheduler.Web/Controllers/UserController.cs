using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Scheduler.ReadModel;
using Scheduler.ReadModel.Models;

namespace Scheduler.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IRepository<User> _userRepository;
        public UserController(IRepository<User> userRepository)
        {
            _userRepository = userRepository;
            var res =_userRepository.New();
            _userRepository.Save(res);
        }

        [HttpPost("authenticate")]
        public IActionResult Authenticate(User user)
        {
            return Ok(user);
        }
    }
}