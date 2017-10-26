using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Entities
{
    public class Policy : BaseEntity
    {
        [Key]
        public long Id { get; set; }
        public int MinExperienceInCompany { get; set; }

        public int ManExperienceInCompany { get; set; }

        public int PaidDayOffs { get; set; }

        public int PaidSickness { get; set; }

        public int UnPaidDayOffs { get; set; }

        public int UnPaidSickness { get; set; }
    }
}
