using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scholarly.Domain.Entities.Contents
{
    public class ContentModifiedByUserMap
    {
        public int ContentModifiedByUserMapId { get; set; }
        public int ContentId { get; set; }
        public int ModifiedByUserId { get; set; }
        public DateTime DateModified { get; set; }
    }
}
