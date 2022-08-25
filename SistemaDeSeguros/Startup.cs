using DrivenAdapters.Sql.Contexts;
using EntryPoints.ReactiveWeb.AutoMapper;
using Helpers.Commons.CustomBase;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UseCase.Logica.PolizaSeguro;
using UseCase.Logica.PolizaVehiculos;
using UseCase.Logica.Usuarios;

namespace SistemaDeSeguros
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureService(IServiceCollection services)
        {
            // Add services to the container.

            services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            services.AddDbContext<ApplicationDbContext>(options => 
            options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"), // Conexion a base de datos
            optionsBuilder => optionsBuilder.MigrationsAssembly("SistemaDeSeguros"))); // ensamblado para realizar la migracion a la base de datos del ApplicationDbContext
            services.AddAutoMapper(typeof(AutoMapperProfile)); // AutoMapper
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();
            services.AddScoped<IUsuariosLogica, UsuariosLogica>();
            services.AddScoped<IPolizaSegurosLogica, PolizaSegurosLogica>();
            services.AddScoped<IPolizaVehiculoLogica, PolizaVehiculoLogica>();
           

        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            // Configure the HTTP request pipeline.
            if (env.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
        }
    }
}
