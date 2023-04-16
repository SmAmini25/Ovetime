using DapperRepository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using OvetimePolicies.Application.Interface.Contexts;
using OvetimePolicies.Application.Services.People.Create;
using OvetimePolicies.Persistence.Data;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<DataBaseContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("WebApiContext") ?? throw new InvalidOperationException("Connection string 'WebApiContext' not found.")));

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

#region Services
builder.Services.AddScoped<IRepository, Repository>();
builder.Services.AddScoped<IDBContextApplication, DataBaseContext>();
builder.Services.AddScoped<ICreatePersonService, CreatePersonService>();
builder.Services.AddScoped<IEditPersonService, EditPersonService>();
builder.Services.AddScoped<IGetPersonService, GetPersonService>();
builder.Services.AddScoped<IGetListPersonService, GetListPersonService>();
#endregion


builder.Services.AddScoped<IRepository, Repository>();

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
