using AutoMapper;
using Domain.Entities;
using Service.Helper.DTOs.Account;
using Service.Helper.DTOs.Cities;
using Service.Helper.DTOs.Countries;
using Service.Helper.DTOs.Departments;
using Service.Helper.DTOs.Employees;
using Service.Helper.DTOs.Jobs;
using Service.Helper.DTOs.Locations;
using Service.Helper.DTOs.Regions;

namespace Service.Helpers.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {

            #region Region
            CreateMap<Region, RegionDto>();
            CreateMap<RegionCreateDto, Region>();
            CreateMap<RegionEditDto, Region>()
                .ForAllMembers(opts =>
                {
                    opts.AllowNull();
                    opts.Condition((src, dest, srcMember) => srcMember != null);
                });
            #endregion

            #region Country
            CreateMap<Country, CountryDto>()
                .ForMember(dest => dest.RegionName, opt => opt.MapFrom(src => src.Region.Name));
            CreateMap<CountryCreateDto, Country>();
            CreateMap<CountryEditDto, Country>()
                .ForAllMembers(opts =>
                {
                    opts.AllowNull();
                    opts.Condition((src, dest, srcMember) => srcMember != null);
                });
            #endregion

            #region City
            CreateMap<City, CityDto>()
                .ForMember(dest => dest.CountryName, opt => opt.MapFrom(src => src.Country.Name));
            CreateMap<CityCreateDto, City>();
            CreateMap<CityEditDto, City>()
                .ForAllMembers(opts =>
                {
                    opts.AllowNull();
                    opts.Condition((src, dest, srcMember) => srcMember != null);
                });
            #endregion

            #region Location
            CreateMap<Location, LocationDto>()
                .ForMember(dest => dest.CityName, opt => opt.MapFrom(src => src.City.Name));
            CreateMap<LocationCreateDto, Location>();
            CreateMap<LocationEditDto, Location>()
                .ForAllMembers(opts =>
                {
                    opts.AllowNull();
                    opts.Condition((src, dest, srcMember) => srcMember != null);
                });
            #endregion

            #region City
            CreateMap<City, CityDto>()
                .ForMember(dest => dest.CountryName, opt => opt.MapFrom(src => src.Country.Name));
            CreateMap<CityCreateDto, City>();
            CreateMap<CityEditDto, City>()
                .ForAllMembers(opts =>
                {
                    opts.AllowNull();
                    opts.Condition((src, dest, srcMember) => srcMember != null);
                });
            #endregion

            #region Department
            CreateMap<Department, DepartmentDto>();
            CreateMap<DepartmentCreateDto, Department>();
            CreateMap<DepartmentEditDto, Department>()
                .ForAllMembers(opts =>
                {
                    opts.AllowNull();
                    opts.Condition((src, dest, srcMember) => srcMember != null);
                });
            #endregion

            #region Job
            CreateMap<Job, JobDto>()
                .ForMember(dest => dest.Employees, opt => opt.MapFrom(src => src.JobHistories.Select(m => m.Employee.Name)));
            CreateMap<JobCreateDto, Job>();
            CreateMap<JobEditDto, Job>()
                .ForAllMembers(opts =>
                {
                    opts.AllowNull();
                    opts.Condition((src, dest, srcMember) => srcMember != null);
                });
            #endregion

            #region Employee
            CreateMap<Employee, EmployeeDto>()
                .ForMember(dest => dest.DepartmentName, opt => opt.MapFrom(src => src.Department.Name))
                .ForMember(dest => dest.Jobs, opt => opt.MapFrom(src => src.Histories.Select(m => m.Job.Title)));
            CreateMap<EmployeeCreateDto, Employee>()
                .ForMember(dest => dest.Image, opt => opt.Ignore());
            CreateMap<EmployeeEditDto, Employee>()
                .ForMember(dest => dest.Image, opt => opt.Ignore())
                .ForAllMembers(opts =>
                {
                    opts.AllowNull();
                    opts.Condition((src, dest, srcMember) => srcMember != null);
                });
            #endregion

            #region Account
            CreateMap<SignUpDto, AppUser>();
            CreateMap<AppUser, UserDto>();
            #endregion
        }
    }
}
