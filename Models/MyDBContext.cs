﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace solo.Models
    {
    public class MyDBContext:DbContext
        {
        public DbSet<Customer> Customers { get; set; }
        public MyDBContext()
            {
            
            }
        }
    }