﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Entity
{
    public class Role
    {
        public int ID { get; set; }
        public string? Name { get; set; }
        public IEnumerable<User>? Users { get; set; }
    }
}
