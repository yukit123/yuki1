﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApiTest.Models
{
    public class Player
    {
        public int Id { get; set; }
        public int No { get; set; }
        public string Name { get; set; }
        public string Position { get; set; }
        public string Team { get; set; }
    }
}