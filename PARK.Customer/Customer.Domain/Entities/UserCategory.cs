﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class UserCategory : BaseCrudEntity<Guid>
    {
        public string CategoryName { get; set; }

        // Navigation properties
        //public IEnumerable<Profession> Professions { get; set; }
        //public IEnumerable<CompanyCategory> CompanyCategories { get; set; }
    }
}