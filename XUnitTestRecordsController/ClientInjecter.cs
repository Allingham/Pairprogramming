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
        //her laver vi en context til vores azure server
        protected readonly string URL = "https://pairprogrammingzealand.azurewebsites.net";
        protected readonly HttpClient testClient;

        protected ClientInjecter()
        {
            //Her laver vi en ny startuo funktion på en webHostBuilder hvor vi 
            var AppFactory = new WebApplicationFactory<Startup>().WithWebHostBuilder(builder =>
            {
                //her for vi fat på configurService hvor vi fjerne vores allerede tilsluttet RecordContext til vores inmemory og
                //tilslutter den igen under et nyt navn så vi ikke arbejder på vores produktionsdata men istedet ny test data
                builder.ConfigureServices(services =>
                {
                    services.RemoveAll(typeof(RecordContext));
                    services.AddDbContext<RecordContext>(options =>
                    {
                        options.UseInMemoryDatabase("IntegrationDB");
                    });
                });
            });

            //her laves en instans testClient som starter denne context oprettelse
            testClient = AppFactory.CreateClient();

        }


    }
}
