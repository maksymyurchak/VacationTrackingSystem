﻿
using BAL.Interfaces;
using Models.Entities;
using Models.ModelsDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Claims;
using System.Web.Http;

namespace VacationTrackingSystem.Controllers.Api
{
    public class UserController : ApiController
    {
        private readonly IUserManager _userManager;
        public UserController(IUserManager userManager)
        {
            _userManager = userManager;
        }
        [HttpGet]
        public List<string> GetAllUserRoles()
        {
            var result = _userManager.GetAllUserRoles();
            return result;
        }
        [HttpPost]
        public IHttpActionResult CreateUser(RegisterUserDTO user)
        {
            try
            {
                var response = _userManager.CreateUser(user);
                if (response)
                {
                    return Ok();
                }
                else
                {
                    return Ok("User with this email exist");
                }
            }
            catch (Exception ex)
            {
                return NotFound();
            }
            
        }
        [HttpGet]
        [Route("api/User/CheckRole")]
        public string CheckRole()
        {
            var identity = (ClaimsIdentity)User.Identity;
            var role = identity.Claims.Where(c => c.Type == ClaimTypes.Role)
                   .Select(c => c.Value).SingleOrDefault();
            return role;
        }
    }


}
