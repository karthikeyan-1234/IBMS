using Material.Domain.Contracts;
using Material.Infrastructure.Contexts;
using Material.Infrastructure.Repositories;
using Material.Services;
using Material.Services.Contracts;
using MaterialAPI;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Resolve dependencies

builder.Services.AddDbContext<MaterialContext>();

builder.Services.AddScoped<IMaterialService, MaterialService>();
builder.Services.AddScoped<IMaterialRepository, MaterialRepository>();
builder.Services.AddScoped<IReportRepository, ReportRepository>();
builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(SQLGenericRepository<>));

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
