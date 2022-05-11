﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication6.Models.ViewModel
{
    public class ProductViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Quantity { get; set; }
        public int Price { get; set; }
        public string Description { get; set; }
        public int Category { get; set; }
    }
}