using BAL.Interfaces;
using Models.ModelsVM.AuthModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Claims;
using System.Web;
using System.Web.Mvc;

namespace VacationTrackingSystem.Controllers
{
    [AllowAnonymous]
    public class AuthController : Controller
    {
        private readonly IUserManager _userManager;
        public AuthController(IUserManager userManager)
        {
            _userManager = userManager;
        }
        [HttpGet]
        public ActionResult LogIn()
        {
            var model = new LogInModel();
            return View(model);
        }

        [HttpPost]
        public ActionResult LogIn(LogInModel model)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            // 1. take user from db
            var user = _userManager.Find(model.Email, model.Password);
            if (user == null)
            {
                ModelState.AddModelError("", "Invalid email or password");
                return View();
            }
                var identity = new ClaimsIdentity(
                    new[] {
                        new Claim(ClaimTypes.Name, user.FirstName +" "+ user.LastName),
                        new Claim(ClaimTypes.Email,user.Email),
                        new Claim(ClaimTypes.Role,user.Role.RoleType.ToString(), ClaimValueTypes.String),
                         new Claim(ClaimTypes.NameIdentifier,user.Id.ToString(), ClaimValueTypes.String),
                    },
                    "ApplicationCookie");
            
                var ctx = Request.GetOwinContext();
                var authManager = ctx.Authentication;

                authManager.SignIn(identity);
                return Redirect("Home/Index");
        }
        public ActionResult LogOut()
        {
            var ctx = Request.GetOwinContext();
            var authManager = ctx.Authentication;

            authManager.SignOut("ApplicationCookie");
            return RedirectToAction("index", "home");
        }
        private string GetRedirectUrl(string returnUrl)
        {
            if (string.IsNullOrEmpty(returnUrl) || !Url.IsLocalUrl(returnUrl))
            {
                return Url.Action("index", "home");
            }

            return returnUrl;
        }
    }
}
