using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scholarly.Contracts.DTOs.Articles
{
    public class WriteArticleDto
    {
        public string Title { get; set; }
        public string Introduction { get; set; }
        public string Description { get; set; }
    }
}
