using BAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace VacationTrackingSystem.Controllers.Api
{
    public class PolicyController : ApiController
    {
        private readonly IPolicyManager _policyManager;
        public PolicyController(IPolicyManager policyManager)
        {
            _policyManager = policyManager;
        }
        [HttpGet]
        public IHttpActionResult GetAllPolicies()
        {
            var result = _policyManager.GetPolicies();
            return Ok(result);
        }
    }
}
