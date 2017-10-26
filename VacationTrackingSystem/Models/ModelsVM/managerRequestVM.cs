using Models.Entities.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.ModelsVM
{
    public class ManagerRequestVM
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string Status { get; set; }
        public VacationType Type { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
