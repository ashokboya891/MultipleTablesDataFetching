using Microsoft.EntityFrameworkCore;
using MultipleTablesData.DatabaseContext;
using MultipleTablesData.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddDbContext<ApplicationDbContext>(t => t.UseSqlServer(builder.Configuration.GetConnectionString("con")));
builder.Services.AddTransient<IDepartmentRepos, DepartmentRepos>();
builder.Services.AddTransient<IEmployeeRepos, EmployeeRepos>();


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
