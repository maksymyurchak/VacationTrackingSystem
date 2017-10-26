using BAL.Interfaces;
using DAL.Interfaces;
using Models.Entities.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAL.Managers
{
    public class PolicyManager : BaseManager, IPolicyManager
    {
        public PolicyManager(IUnitOfWork uow) : base(uow)
        {

        }
        public List<string> GetPolicies()
        {
            var policies = new List<string>(new string[] { VacationType.PaidDayOffs.ToString(), VacationType.UnPaidSickness.ToString(), VacationType.UnPaidDayOffs.ToString(), VacationType.PaidSickness.ToString() });
            return policies;
        }
    }
}
