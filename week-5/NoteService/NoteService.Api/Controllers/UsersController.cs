using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NoteService.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NoteService.Api.Controllers {
    [Route("api/users")]
    [ApiController]
    public class UsersController : ControllerBase {
        private readonly ICollection<Author> _users;

        public UsersController(ICollection<Author> users) {
            _users = users;
        }

        [HttpGet]
        public IActionResult Get() {
            return Ok(_users);
        }
    }
}
