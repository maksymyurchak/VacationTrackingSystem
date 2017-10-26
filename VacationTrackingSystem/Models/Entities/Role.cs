using Models.Entities.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Entities
{
    public class Role : BaseEntity
    {
        [Key]
        public long Id { get; set; }
        public RoleType RoleType { get; set; }
       
    }
}
