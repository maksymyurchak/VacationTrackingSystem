using Models.ModelsDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAL.Interfaces
{
    public interface IUserManager
    {
        List<string> GetAllUserRoles();
        UserDTO Find(string email, string password);
        bool CreateUser(RegisterUserDTO user);
    }
}
