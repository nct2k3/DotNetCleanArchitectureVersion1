using Application;
using Application.Service.Authentication;
using Infrastructure;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using WebApplication3.Errors;
var builder = WebApplication.CreateBuilder(args);


builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers();
builder.Services.AddApplication();
builder.Services.AddInfrastructure(builder.Configuration);

builder.Services.AddSingleton<ProblemDetailsFactory, MyProblemDetailFactory>();




var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();

}
app.UseExceptionHandler("/error");
app.UseHttpsRedirection();
app.UseAuthorization(); 
app.MapControllers();
app.Run();
