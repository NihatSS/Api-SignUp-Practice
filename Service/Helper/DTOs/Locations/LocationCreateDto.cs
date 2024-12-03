using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Helper.DTOs.Locations
{
    public class LocationCreateDto
    {
        public string StreetAddress { get; set; }
        public string PostalCode { get; set; }
        public int CityId { get; set; }
    }
}
