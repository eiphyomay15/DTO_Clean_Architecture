using DTO_Clean_Architecture.Application.IServices;
using DTO_Clean_Architecture.Application.Services;
using DTO_Clean_Architecture.Core.IRepositories;
using DTO_Clean_Architecture.Infrastructure.Database;
using DTO_Clean_Architecture.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;

namespace DTO_Clean_Architecture.Api.Extension
{
    public static class ServiceExtension
    {
        public static void ConfigureDatabaseContext(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>(options =>  options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));
        }
        public static void ConfigureServiceResolver(this IServiceCollection services)
        {
            services.AddControllers();
            services.AddScoped<IStaffService, StaffService>();
            services.AddScoped<IStaffInfoRepository, StaffInfoRepository>();
        }
    }
}
