﻿using Models.Entities.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.ModelsVM
{
    public class VacationRequestVM
    {
        public long Id { get; set; }
        public string UserName { get; set; }
        public VacationType VacationType { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public long UserId { get; set; }
        public string Status { get; set; }
    }
}
