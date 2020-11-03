using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace Pairprogramming
{
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
            //starter inMemory servicen
            services.AddDbContext<RecordContext>(options => options.UseInMemoryDatabase("RecordList"));

            services.AddControllers();


            //her giver vi tilladelse at alle der tilgår vores server via zealand.dk har lov til alt ( options.AddPolicy("AllowSpecificOrigin") Det er redundant at have alle 3 på en gang
            services.AddCors(options =>
            {
                options.AddPolicy("AllowSpecificOrigin",
                        builder => builder.WithOrigins("http://zealand.dk").AllowAnyMethod().AllowAnyHeader());
                //her giver vi alle lov til at tilgå server med alle metoder
                options.AddPolicy("AllowAnyOrigin",
                        builder => builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
                //her giver vi alle lov til at bruge get og put på serveren
                options.AddPolicy("AllowAnyOriginGetPut",
                        builder => builder.AllowAnyOrigin().WithMethods("GET", "PUT").AllowAnyHeader());
            });


        }



        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();
            //her vælger vi hvem vi tillader
            app.UseCors("AllowSpecificOrigin");


            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
