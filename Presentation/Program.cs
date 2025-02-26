using Application;
using Application.Service.Authentication;
using Infrastructure;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using WebApplication3.Errors;
using WebApplication3.Fillters;
using WebApplication3.Middleware;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
// handling error when bug resutl from controller
builder.Services.AddControllers( 
    options=>options.Filters.Add<ErrorHandlingFillterAttribute>()
    );
builder.Services.AddApplication();
builder.Services.AddInfrastructure(builder.Configuration);

// convert result error to fotmat RFC
builder.Services.AddSingleton<ProblemDetailsFactory, MyProblemDetailFactory>();




var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    
    
    
    
}
// handling error not handdle by fillter - controller result text exception
app.UseMiddleware<ErrorHandlingMiddleware>();
app.UseExceptionHandler("/error");
app.UseHttpsRedirection();
app.Map("/error", (HttpContext httpContext) =>
{
    Exception? exception = httpContext.Features.Get<IExceptionHandlerFeature>()?.Error;

    return Results.Problem();
});

app.UseAuthorization(); 


app.MapControllers();

app.Run();
// version handling erorr 1