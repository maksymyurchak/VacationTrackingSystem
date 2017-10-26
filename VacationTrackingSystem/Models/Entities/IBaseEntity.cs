using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Entities
{
    public interface IBaseEntity
    {
        DateTime DateCreated { get; set; }
        DateTime DateModified { get; set; }
    }
}
