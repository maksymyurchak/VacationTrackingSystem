using Models.ModelsDTO;
using Models.ModelsVM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAL.Interfaces
{
    public interface IVacationManager
    {
        bool CreateVacation(VacationRequestDTO vacation);
        List<VacationRequestDTO> GetAllVacations();
        bool ApproveDeclineVacation(ManagerRequestVM model);
        //void DeclineRequest(managerRequestVM model);

    }
}
