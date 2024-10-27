using Microsoft.EntityFrameworkCore;
using Scholarly.Domain.Repositories;
using Scholarly.Persistence;
using Scholarly.Persistence.Repositories;
using Scholarly.Services;
using Scholarly.Services.Abstractions;
using System.Net;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers()
    .AddApplicationPart(typeof(Scholarly.Presentation.AssemblyReference).Assembly);

builder.Services.AddDbContext<ScholarlyDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("Scholarly")));

builder.Services.AddScoped<IServiceManager, ServiceManager>();
builder.Services.AddScoped<IRepositoryManager, RepositoryManager>();

builder.Services.AddAutoMapper(typeof(Scholarly.Contracts.AssemblyReference).Assembly);

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseAuthorization();

app.MapControllers();

app.Run();
