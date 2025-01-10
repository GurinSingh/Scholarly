using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scholarly.Domain.Entities
{
    public interface IBaseEntity
    {
        DateTime DateCreated { get; set; }
        DateTime DateModified { get; set; }
        bool IsActive { get; set; }
    }
}
