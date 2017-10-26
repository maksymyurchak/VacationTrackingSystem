using BAL.Interfaces;
using Models.ModelsVM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace VacationTrackingSystem.Controllers.Api
{
    public class ManagerController : ApiController
    {
        private readonly IVacationManager _vacationManager;
        public ManagerController(IVacationManager vacationManager)
        {
            _vacationManager = vacationManager;
        }

        [HttpPost]
        public IHttpActionResult ApproveDeclineVacation(ManagerRequestVM model)
        {
            try
            {
                // get claims and take one with name
                var result =_vacationManager.ApproveDeclineVacation(model);
                if (!result)
                {
                    return Ok("u have not got enough :" +model.Type.ToString());
                }
                return Ok();
            }
            catch (Exception ex)
            {
                return NotFound();
            }
        }
        //[HttpPut]
        //[Route("Decline/{id}/{userId}")]
        //public IHttpActionResult Decline(managerRequestVM model)
        //{
        //    try
        //    {
        //        _vacationManager.DeclineRequest(model);
        //        return Ok();
        //    }
        //    catch (Exception ex)
        //    {
        //        return NotFound();
        //    }
        //}

    }
}
