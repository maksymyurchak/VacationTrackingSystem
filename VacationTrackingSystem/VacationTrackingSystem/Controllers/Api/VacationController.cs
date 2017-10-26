using BAL.Interfaces;
using Models.ModelsDTO;
using Models.ModelsVM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Claims;
using System.Web.Http;
using System.Web.Http.Description;
using System.Web.Http.Results;

namespace VacationTrackingSystem.Controllers.Api
{
    [AllowAnonymous]
    public class VacationController : ApiController
    {
        private readonly IVacationManager _vacationManager;
            public VacationController(IVacationManager vacationManager)
            {
                _vacationManager = vacationManager;
            }

        [HttpPost]
        public IHttpActionResult CreateVacation(VacationRequestVM vacation)
        {
            var identity = (ClaimsIdentity)User.Identity;
            var userId = identity.Claims.Where(c => c.Type == ClaimTypes.NameIdentifier)
                   .Select(c => c.Value).SingleOrDefault();
            var vacationToDTO = new VacationRequestDTO
            {
                Id = vacation.Id,
                UserName = User.Identity.Name,
                VacationType = vacation.VacationType,
                StartDate = vacation.StartDate,
                EndDate = vacation.EndDate,
                UserId = Convert.ToInt64(userId)
            };
            try
            {
                var answer = _vacationManager.CreateVacation(vacationToDTO);
                if (answer)
                {
                    return Ok();
                }
                else
                {
                    return Ok("already exist vacation in there dates");
                }
            }
            catch(Exception e)
            {
                return NotFound();
            }
        }
        [HttpGet]
        [ResponseType(typeof(List<VacationRequestVM>))]
        public IHttpActionResult GetAllVacations()
        {
        
            var result = new List<VacationRequestVM>();
            try
            {
                var vacationsDTOs = _vacationManager.GetAllVacations();
                foreach(var vac in vacationsDTOs)
                {
                    var vacVm = new VacationRequestVM
                    {
                        Id = vac.Id,
                        UserName = vac.UserName,
                        StartDate = vac.StartDate,
                        EndDate = vac.EndDate,
                        VacationType = vac.VacationType,
                        UserId = vac.UserId,
                        Staus = vac.Status
                    };
                    result.Add(vacVm);
                }
                return Ok(result);
            }
            catch(Exception e)
            {
                return NotFound();   
            }
        }
    }
}
