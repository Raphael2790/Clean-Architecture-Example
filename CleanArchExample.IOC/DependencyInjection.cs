using AutoMapper;
using CleanArchExample.Application.Interfaces;
using CleanArchExample.Application.Mapping;
using CleanArchExample.Application.Services;
using CleanArchExample.Data.Context;
using CleanArchExample.Data.Repositories;
using CleanArchExample.Domain.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace CleanArchExample.IOC
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(
                    configuration.GetConnectionString("DefaultConnection"),
                    b => b.MigrationsAssembly(typeof(ApplicationDbContext)
                    .Assembly.FullName)));

            services.AddDatabaseDeveloperPageExceptionFilter();

            services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
                .AddEntityFrameworkStores<ApplicationDbContext>();

            //O  scoped aplica a injeção de dependência em toda a aplicação 
            //Podemos simplesmente agora chamar o product service no controller que será criado uma intância do objeto
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<IProductService, ProductService>();

            //Além do scoped existem também o AddTransient e o AddSingleton
            //AddSingleton reutilizada a mesma intância criada para toda a aplicação
            //AddTransient cria e destroi a instância por chamada

            return services;
        }
    }
}
