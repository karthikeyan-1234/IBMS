using MaterialMaster.Domain.Contracts;
using MaterialMaster.Infrastructure.Contexts;
using MaterialMaster.Infrastructure.Repositories;
using MaterialMaster.Services;
using MaterialMaster.Services.Contracts;
using MaterialAPI;
using MaterialMasterAPI.Dependencies;
using Common.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddSignalR();

//Resolve dependencies
builder.Services.AddBusinessDependencies();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();


app.UseRouting();

app.UseAuthorization();


app.UseEndpoints(static endpoints =>
{
    endpoints.MapControllers();
    endpoints.MapHub<ChatHub>("/chatHub");
});



app.Run();
