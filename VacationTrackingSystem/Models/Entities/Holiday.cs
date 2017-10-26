using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Entities
{
    public class Holiday : BaseEntity
    {
        [Key]
        public long Id { get; set; }
        public DateTime Date { get; set; }
        public string Name { get; set; }
    }
}
