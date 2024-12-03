using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using Service.Services.Interfaces;
using Service.Services;

namespace Repository
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddServicelayer(this IServiceCollection services)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddScoped<IRegionService, RegionService>();
            services.AddScoped<ICountryService, CountryService>();
            services.AddScoped<ICityService, CityService>();
            services.AddScoped<ILocationService, LocationService>();
            services.AddScoped<IDepartmentService, DepartmentService>();
            services.AddScoped<IJobService, JobService>();
            services.AddScoped<IFileService, FileService>();
            services.AddScoped<IEmployeeService, EmployeeService>();
            services.AddScoped<IAccountService, AccountService>();

            return services;
        }

    }
}
