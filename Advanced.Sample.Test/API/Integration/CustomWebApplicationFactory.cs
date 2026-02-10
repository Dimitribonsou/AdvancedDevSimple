using AdvancedDevSample.Domain.Interfaces.Products;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.VisualStudio.TestPlatform.TestHost;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using System;
using System.Collections.Generic;
using System.Text;

namespace AdvancedDevSample.Test.API.Integration
{
    public class CustomWebApplicationFactory : WebApplicationFactory<Program>
    {
        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {
            builder.ConfigureServices(services =>
            {
                //Supprimer le vrai repository si necessaire
                services.RemoveAll(typeof(IProductRepository));
                //Ajouter un repository in memeory
                services.AddSingleton<IProductRepository, InMemoryProductRepository>();
            });
        }
    }
}