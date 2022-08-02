using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using consumerAPI.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using consumerAPI.Business;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddDbContext<ExampleContext>(options => options.UseSqlServer("Initial Catalog=master; Data Source=localhost,1450;Persist Security Info=True;User ID=sa;Password=2Secure*Password2"));
builder.Services.AddCap(options =>
{
    options.UseEntityFramework<ExampleContext>();
    options.UseSqlServer("Initial Catalog=master; Data Source=localhost,1450;Persist Security Info=True;User ID=sa;Password=2Secure*Password2");

    options.UseRabbitMQ(options =>
    {
        options.ConnectionFactoryOptions = options =>
        {
            options.Ssl.Enabled = false;
            options.HostName = "localhost";
            options.UserName = "guest";
            options.Password = "guest";
            options.Port = 5672;
        };
    });
});

builder.Services.AddControllers();


var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseAuthorization();

app.MapControllers();

app.Run();
