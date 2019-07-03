using AccountingSystem.Models.DB;
using AccountingSystem.Models.Dto.CommodityDtos;
using AccountingSystem.Services.Interfaces.RepositoryInterfaces;
using AccountingSystem.Services.Interfaces.Service;
using AccountingSystem.Services.Repositories;
using AccountingSystem.Services.Services;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace AccountingSystem.Configuration
{
    public static class ServicesConfiguration
    {
        public static IServiceCollection AddAllScoped(this IServiceCollection services)
        {
            services.AddScoped<IApplicationUserService, ApplicationUserService>();

            return services;
        }

        public static IServiceCollection AddAllTransient(this IServiceCollection services)
        {
            services.AddTransient<IAuthenticateService, TokenAuthenticationService>();
            services.AddTransient<IContactInfoService, ContactInfoService>();
            services.AddTransient<ICompanyService, CompanyService>();
            services.AddTransient<ICommodityService, CommodityService>();

            return services;
        }

        public static IServiceCollection AddAllRepository(this IServiceCollection services)
        {
            services.AddTransient<IBaseRepository<ApplicationUser>, BaseRepository<ApplicationUser>>();
            services.AddTransient<IBaseRepository<ContactInfo>, BaseRepository<ContactInfo>>();
            services.AddTransient<IBaseRepository<Commodity>, BaseRepository<Commodity>>();
            services.AddTransient<IBaseRepository<Company>, BaseRepository<Company>>();

            return services;
        }
    }
}
