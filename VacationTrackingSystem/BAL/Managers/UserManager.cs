using AutoMapper;
using BAL.Interfaces;
using DAL.Interfaces;
using Models.ModelsDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Text;
using System.Threading.Tasks;
using Models.Entities;

namespace BAL.Managers
{
    public class UserManager : BaseManager,IUserManager
    {
        public UserManager(IUnitOfWork uow) : base(uow)
        {

        }
        public List<string> GetAllUserRoles()
        {
            var roles = uow.RoleRepo.All.Select(s => s.RoleType.ToString()).Distinct().ToList();
            return roles;
        }
        public UserDTO Find(string email, string password)
        {

            var user = uow.UserRepo.All.FirstOrDefault(i => i.Email == email && i.Password == password);
            var role = uow.RoleRepo.GetByID(user.RoleId);
            user.Role = role;
            return Mapper.Map<UserDTO>(user);
        }
        public bool CreateUser(RegisterUserDTO user)
        {
            var newUser = new User()
            {
                Email = user.Email,
                LastName = user.LastName,
                FirstName = user.FirstName,
                Password = user.Password,
                Role = new Role { RoleType = user.Role }
            };
            if (user.Experience < 2)
            {
                newUser.InfoAboutVacation = new InfoAboutVacation
                {
                    PaidDayOffs = 40,
                    UnPaidDayOffs = 40,
                    PaidSickness = 40,
                    UnPaidSickness = 40,
                    ExperienceInCompany = user.Experience
                };
            }
            else
            {
                newUser.InfoAboutVacation = new InfoAboutVacation
                {
                    PaidDayOffs = 60,
                    UnPaidDayOffs = 60,
                    PaidSickness = 60,
                    UnPaidSickness = 60,
                    ExperienceInCompany = user.Experience
                };
            }
            var existUser = uow.UserRepo.All.Any(i => i.Email == user.Email);
            if (existUser)
            {
                return false;
            }
            uow.UserRepo.Insert(newUser);
            uow.Save();
            return true;
        }
    }
}
