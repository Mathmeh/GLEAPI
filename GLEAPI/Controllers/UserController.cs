using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GLE.Context;
using GLE.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using AutoMapper;
using GLEAPI.Dto;
using GLEAPI.Rep;


namespace GLEAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly GLEContext context;
        private readonly IMapper mapper;
        private readonly IRepository repos;


        public UserController(IMapper mapper, GLEContext context, IRepository repos)
        {
            this.mapper = mapper;
            this.context = context;
            this.repos = repos;
        }

        [HttpPost]
        public ActionResult<UserReadDto> Add(UserCreateDto NUser)
        {
            if (repos.GetUserByName(NUser.Name) != null) return Conflict();
            User newUser = new User { Name = NUser.Name, Salt = NUser.Salt, PasswordSaltedHashed = NUser.PasswordSaltedHashed, PasswordHashed=NUser.PasswordHashed };
            context.Users.Add(newUser);            
            context.SaveChanges();
            return Ok(mapper.Map<UserReadDto>(newUser));              
        }
        [Route("Login")]
        [HttpPost]
        public ActionResult<UserLoginDto> TryToLogin (UserLoginDto dto)
        {
            var user = context.Users.FirstOrDefault(user => user.Name == dto.Name);
            if (user == null || user.PasswordHashed != dto.PasswordHashed) return Conflict();
            return Ok(mapper.Map<UserReadDto>(user));
        }
    }
}
