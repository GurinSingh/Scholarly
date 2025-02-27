﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scholarly.Domain.Entities.Users
{
    public class UserWorkExperience : BaseEntity
    {
        public UserWorkExperience()
        {
            this.User = new();
        }
        public int UserWorkExperienceId { get; set; }
        public string Position { get; set; }
        public DateTime StartDt { get; set; }
        public DateTime EndDt { get; set; }
        public bool IsCurrent { get; set; }
        public string Description { get; set; }
        public string SkillsUsed { get; set; }
        public string CompanyName { get; set; }

        public int UserId { get; set; }
        public virtual User User { get; set; }
    }
}
