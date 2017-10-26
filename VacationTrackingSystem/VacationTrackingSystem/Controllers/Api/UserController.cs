
using BAL.Interfaces;
using Models.Entities;
using Models.ModelsDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
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
    }


}
