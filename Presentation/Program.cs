using Application;
using Infrastructure;
using Presentation;
var builder = WebApplication.CreateBuilder(args);


builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddApplication();
builder.Services.AddPresentation();
builder.Services.AddInfrastructure(builder.Configuration);



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
