﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class City
    {
        public int Id { get; set; }
        public int CountryId { get; set; }

        public string CityName { get; set; }
    }
}