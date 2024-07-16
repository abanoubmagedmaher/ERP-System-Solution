using Core.Interfaces;
using ERP_System.Errors;

using Infrastrucure.Data;
using Microsoft.EntityFrameworkCore;

namespace ERP_System
{
    public class Program
    {
        public static  void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            #region cconection String
            builder.Services.AddDbContext<StoreContext>(op =>
                op.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))
                );
            #endregion

            #region Add repository Servicse
            builder.Services.AddScoped<IProductRepository, ProductRepository>();
            #endregion
            #region Add Genaric Repostry
            builder.Services.AddScoped(typeof(IGenericRepostory<>), typeof(GenericRepostory<>));
            #endregion
            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            #region Add AutoMapper
            builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            #endregion
            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }
            #region HAndel Exception Middelware 
       
            #endregion
            #region Adding Not Found endPoint error
        
            #endregion

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseAuthorization();


            app.MapControllers();
            #region Add Any Migration
            using var scope = app.Services.CreateScope();
            var Services = scope.ServiceProvider;
            var context = Services.GetRequiredService<StoreContext>();
            var logger = Services.GetRequiredService<ILogger<Program>>();
            try
            {
                context.Database.MigrateAsync();
                StoreContextSeed.SeedAsync(context);

            }
            catch (Exception exp)
            {

                logger.LogError(exp, "Why Migrating process");
            }
            #endregion
            app.Run();
        }
    }
}