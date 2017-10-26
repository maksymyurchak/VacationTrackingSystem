using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Entities
{
  
    public class User : BaseEntity
    {
        [Key]
        public long Id { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Password { get; set; }
        public long RoleId { get; set; }
        [ForeignKey("RoleId")]
        public virtual Role Role { get; set; }
        public virtual List<VacationRequest> VacationRequests { get; set; }
        //public long? InfoAboutVacationId { get; set; }
        //[ForeignKey(nameof(InfoAboutVacationId))]
        public virtual InfoAboutVacation InfoAboutVacation { get; set; }
        public User()
        {
            VacationRequests = new List<VacationRequest>();
        }
    }
}
