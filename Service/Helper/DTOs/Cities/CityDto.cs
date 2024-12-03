using Domain.Entities;

namespace Service.Helper.DTOs.Cities
{
    public class CityDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime CreatedDate { get; set; }
        public string CountryName { get; set; }
    }
}
