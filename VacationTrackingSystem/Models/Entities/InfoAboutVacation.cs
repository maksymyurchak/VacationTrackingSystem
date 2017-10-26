using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Entities
{
    public class InfoAboutVacation : BaseEntity
    {
        public int PaidDayOffs { get; set; }
        public int PaidSickness { get; set; }
        public int UnPaidDayOffs { get; set; }
        public int UnPaidSickness { get; set; }
        public int ExperienceInCompany { get; set; }
        [Key, ForeignKey(nameof(User))]
        public long UserId { get; set; }
        public virtual User User { get; set; }


    }
}
