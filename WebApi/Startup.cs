using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Npgsql;
using Npgsql.EntityFrameworkCore;
using Npgsql.EntityFrameworkCore.PostgreSQL;

namespace WebApi
{
    //to get help
    //https://www.codingame.com/playgrounds/35462/creating-web-api-in-asp-net-core-2-0/part-1---web-api

    //Swagger
    //https://docs.microsoft.com/tr-tr/aspnet/core/tutorials/getting-started-with-swashbuckle?view=aspnetcore-3.0&tabs=visual-studio-code

    /*
    dotnet new sln
dotnet new webapi -o webApiNetCore3.WebApi --no-https true --auth None
dotnet new classlib -o webApiNetCore3.EFCore



dotnet add package Microsoft.EntityFrameworkCore --version 3.0.0
dotnet add package Npgsql.EntityFrameworkCore.PostgreSQL --version 3.0.1


dotnet tool install --global dotnet-ef

dotnet ef migrations add InitialCreate
dotnet ef database update


dotnet add package Microsoft.EntityFrameworkCore.Design
     */
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            services.AddDbContext<Models.ApiDbContext>();
            services.AddScoped<Services.EmployeeService>();
            services.AddLogging(logging => logging.AddConsole());


        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            //app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
