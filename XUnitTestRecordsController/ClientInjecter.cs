using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Pairprogramming;

namespace XUnitTestRecordsController
{
    class ClientInjecter
    {
        //her laver vi en context til 
        protected readonly string URL = "https://pairprogrammingzealand.azurewebsites.net";
        protected readonly HttpClient testClient;

        protected ClientInjecter()
        {
            var AppFactory = new WebApplicationFactory<Startup>().WithWebHostBuilder(builder =>
            {
                builder.ConfigureServices(services =>
                {
                    services.RemoveAll(typeof(RecordContext));
                    services.AddDbContext<RecordContext>(options =>
                    {
                        options.UseInMemoryDatabase("IntegrationDB");
                    });
                });
            });
            testClient = AppFactory.CreateClient();

        }


    }
}
