using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Movimentos.Domain.Entities;
using Movimentos.Domain.Interfaces;
using Movimentos.Infra.Data.Context;
using Movimentos.Infra.Data.Repository;
using Movimentos.Service.Services;

namespace Movimentos.Application
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers().AddNewtonsoftJson(options =>
                     options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);
            // Inserir connectionString do sql server no arquivo appsettings.json
            services.AddDbContext<SqlServerContext>
                     (options => options.UseSqlServer
                     (Configuration["Database:SqlServer:ConnectionString"]));

            services.AddScoped<IBaseRepository<Movimento>, BaseRepository<Movimento>>();
            services.AddScoped<IBaseService<Movimento>, BaseService<Movimento>>();

            services.AddScoped<IBaseRepository<Produto>, BaseRepository<Produto>>();
            services.AddScoped<IBaseService<Produto>, BaseService<Produto>>();

            services.AddScoped<IBaseRepository<ProdutoCosif>, BaseRepository<ProdutoCosif>>();
            services.AddScoped<IBaseService<ProdutoCosif>, BaseService<ProdutoCosif>>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseCors(x => x
                   .AllowAnyOrigin()
                   .AllowAnyMethod()
                   .AllowAnyHeader());

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
