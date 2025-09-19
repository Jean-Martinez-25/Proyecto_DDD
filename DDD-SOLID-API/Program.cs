using DDD_SOLID.Application.Commands.CreateCustomer;
using DDD_SOLID.Domain.Interfaces;
using DDD_SOLID.Infrastructure.Persistence.Repositories;
using DDD_SOLID.Infrastructure.Persistence;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using DDD_SOLID.Application.Behaviors;
using MediatR;
using DDD_SOLID.Application.Mapping;

var builder = WebApplication.CreateBuilder(args);
//EF CORE
builder.Services.AddDbContext<AppDbContext>(options => 
    options.UseSqlServer(builder.Configuration.GetConnectionString("Conexion")));

// Repositorio

builder.Services.AddScoped<ICustomerRepository, CustomerRepository>();
builder.Services.AddScoped<ICallRepository, CallRepository>();

// MediatR, FluentValidation, AutoMapper (si no lo hiciste antes) 

builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(CreateCustomerHandler).Assembly));
builder.Services.AddValidatorsFromAssembly(typeof(CreateCustomerHandler).Assembly);
builder.Services.AddAutoMapper(typeof(CreateCustomerHandler).Assembly);

builder.Services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));
//Validator
builder.Services.AddValidatorsFromAssemblyContaining<CreateCustomerValidator>();
//AutoMaper
builder.Services.AddAutoMapper(typeof(CallProfile).Assembly);
// Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
