﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Helper.DTOs.Countries
{
    public class CountryCreateDto
    {
        public string Name { get; set; }
        public int Population { get; set; }
        public int RegionId { get; set; }
    }
}
