﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace WebApplication6.Models
{
    public class ApplicationDbContext:DbContext
    {


        public DbSet<Category> Categories { get; set; }
        public DbSet<Products> Products { get; set; }

    }
}