using Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface IUnitOfWork
    {
        IGenericRepository<User> UserRepo { get; }
        IGenericRepository<Role> RoleRepo { get; }
        IGenericRepository<VacationRequest> VacationRequestRepo { get; }
        IGenericRepository<Holiday> HolidayRepo { get; }
        IGenericRepository<Policy> PolicyRepo { get; }
        void Save();
        void Dispose();
    }
}
