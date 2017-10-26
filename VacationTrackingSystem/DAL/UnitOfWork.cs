using DAL.Interfaces;
using DAL.Repositories;
using Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class UnitOfWork : IUnitOfWork,IDisposable
    {
        private AppContext context;
        private IGenericRepository<User> userRepo;
        private IGenericRepository<Role> roleRepo;
        private IGenericRepository<VacationRequest> vacationRequestRepo;
        private IGenericRepository<Holiday> holidayRepo;
        private IGenericRepository<Policy> policyRepo;
        public UnitOfWork()
        {
            context = new AppContext();

            userRepo = new GenericRepository<User>(context);
            roleRepo = new GenericRepository<Role>(context);
            vacationRequestRepo = new GenericRepository<VacationRequest>(context);
            holidayRepo = new GenericRepository<Holiday>(context);
            policyRepo = new GenericRepository<Policy>(context);
        }
        public IGenericRepository<User> UserRepo
        {
            get
            {
                if (userRepo == null) userRepo = new GenericRepository<User>(context);
                return userRepo;
            }
        }

        public IGenericRepository<Role> RoleRepo
        {
            get
            {
                if (roleRepo == null) roleRepo = new GenericRepository<Role>(context);
                return roleRepo;
            }
        }

        public IGenericRepository<Holiday> HolidayRepo
        {
            get
            {
                if (holidayRepo == null) holidayRepo = new GenericRepository<Holiday>(context);
                return holidayRepo;
            }
        }

        public IGenericRepository<VacationRequest> VacationRequestRepo
        {
            get
            {
                if (vacationRequestRepo == null) vacationRequestRepo = new GenericRepository<VacationRequest>(context);
                return vacationRequestRepo;
            }
        }
        public IGenericRepository<Policy> PolicyRepo
        {
            get
            {
                if (policyRepo == null) policyRepo = new GenericRepository<Policy>(context);
                return policyRepo;
            }
        }
        public void UpdateContext()
        {
            context = new AppContext();
        }
        public void Save()
        {

            context.SaveChanges();
        }

        private bool disposed = false;
        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
