using Microsoft.AspNetCore.Mvc;
using Nigel.Extensions.Swashbuckle;

var builder = WebApplication.CreateBuilder(args);

//// Add services to the container.


builder.Services.AddControllers(opt =>
{
    opt.UseCentralRoutePrefix(new RouteAttribute("front"));
}).AddDapr();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
//builder.Services.AddSwaggerGen();
builder.Services.AddSwaggerDocs();

var app = builder.Build();

//app.UseSwagger();
//app.UseSwaggerUI();
app.UseSwaggerDocs();

app.UseAuthorization();

app.MapControllers();

app.Run();
