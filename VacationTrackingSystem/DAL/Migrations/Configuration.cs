namespace DAL.Migrations
{
    using Models.Entities;
    using Models.Entities.Enums;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<DAL.AppContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(DAL.AppContext context)
        {
            ////init manager
            var managerRole = new Role
            {
                RoleType = RoleType.Manager,
                DateCreated = DateTime.UtcNow,
                DateModified = DateTime.UtcNow
            };
            var IAVManager = new InfoAboutVacation
            {
                PaidDayOffs = 60,
                PaidSickness = 60,
                UnPaidDayOffs = 60,
                UnPaidSickness = 60,
                ExperienceInCompany = 5,
                DateCreated = DateTime.UtcNow,
                DateModified = DateTime.UtcNow

            };
            var userManager = new User
            {
                FirstName = "Maksym",
                LastName = "Yurchak",
                Password = "12345",
                Role = managerRole,
                Email = "wukarenf@gmail.com",
                InfoAboutVacation = IAVManager,
                DateCreated = DateTime.UtcNow,
                DateModified = DateTime.UtcNow

            };
            //init employee
            var employeeRole = new Role
            {
                RoleType = RoleType.Employee,
                DateCreated = DateTime.UtcNow,
                DateModified = DateTime.UtcNow
            };
            var IAVEmployee = new InfoAboutVacation
            {
                PaidDayOffs = 40,
                PaidSickness = 40,
                UnPaidDayOffs = 40,
                UnPaidSickness = 40,
                ExperienceInCompany = 1,
                DateCreated = DateTime.UtcNow,
                DateModified = DateTime.UtcNow
            };
            var userEmployee = new User
            {
                FirstName = "Employee",
                LastName = "EmployeeLastName",
                Password = "12345",
                Role = employeeRole,
                InfoAboutVacation = IAVEmployee,
                DateCreated = DateTime.UtcNow,
                DateModified = DateTime.UtcNow

            };
            //init hr 
            var hrRole = new Role
            {
                RoleType = RoleType.HumanResources,
                DateCreated = DateTime.UtcNow,
                DateModified = DateTime.UtcNow

            };
            var IAVHR = new InfoAboutVacation
            {
                PaidDayOffs = 60,
                PaidSickness = 60,
                UnPaidDayOffs = 60,
                UnPaidSickness = 60,
                ExperienceInCompany = 1,
                DateCreated = DateTime.UtcNow,
                DateModified = DateTime.UtcNow
            };
            var userHR = new User
            {
                FirstName = "Human Resources",
                LastName = "HRLastName",
                Password = "12345",
                Role = hrRole,
                InfoAboutVacation = IAVHR,
                DateCreated = DateTime.UtcNow,
                DateModified = DateTime.UtcNow
            };
            //init police
            var policy1 = new Policy
            {
                MinExperienceInCompany = 0,
                ManExperienceInCompany = 1,
                PaidDayOffs = 40,
                PaidSickness = 40,
                UnPaidDayOffs = 40,
                UnPaidSickness = 40,
                DateCreated = DateTime.UtcNow,
                DateModified = DateTime.UtcNow
            };
            var policy2 = new Policy
            {
                MinExperienceInCompany = 2,
                ManExperienceInCompany = 5,
                PaidDayOffs = 60,
                PaidSickness = 60,
                UnPaidDayOffs = 60,
                UnPaidSickness = 60,
                DateCreated = DateTime.UtcNow,
                DateModified = DateTime.UtcNow
            };
            //init holiday
            var holidayCompanyDay = new Holiday()
            {
                Name = "CompanyDay",
                Date = DateTime.ParseExact("10/07/2018", "dd/MM/yyyy", null),
                DateCreated = DateTime.UtcNow,
                DateModified = DateTime.UtcNow
            };

            var holidayNewYear = new Holiday()
            {
                Name = "New Year",
                Date = DateTime.ParseExact("01/01/2018", "dd/MM/yyyy", null),
                DateCreated = DateTime.UtcNow,
                DateModified = DateTime.UtcNow
            };

            context.Holidays.AddOrUpdate(holidayCompanyDay);
            context.Holidays.AddOrUpdate(holidayNewYear);
            context.Policies.AddOrUpdate(policy2);
            context.Policies.AddOrUpdate(policy1);
            context.Roles.AddOrUpdate(employeeRole);
            context.Roles.AddOrUpdate(managerRole);
            context.Roles.AddOrUpdate(hrRole);
            context.Users.AddOrUpdate(userManager);
            context.Users.AddOrUpdate(userEmployee);
            context.Users.AddOrUpdate(userHR);
        }
    }
}
