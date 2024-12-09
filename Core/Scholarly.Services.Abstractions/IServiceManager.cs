using Scholarly.Services.Abstractions.Articles;
using Scholarly.Services.Abstractions.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scholarly.Services.Abstractions
{
    public interface IServiceManager
    {
        IUserService UserService { get; }
        IWorkExperienceService WorkExperienceService { get; }
        IArticleService ArticleService { get; }
    }
}
