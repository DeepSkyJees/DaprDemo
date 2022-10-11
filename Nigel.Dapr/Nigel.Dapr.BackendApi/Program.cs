using Google.Api;
using Microsoft.AspNetCore.Mvc;
using Nigel.Dapr.BackendApi;
using Nigel.Extensions.Swashbuckle;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.



builder.Services.AddControllers(opt =>
{
    opt.UseCentralRoutePrefix(new RouteAttribute("Backend"));
}).AddDapr();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
//builder.Services.AddSwaggerDocs();

var app = builder.Build();

//// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
//    app.UseSwagger();
//    app.UseSwaggerUI();
//}
app.UseSwagger();
app.UseSwaggerUI();

app.UseAuthorization();

//app.UseSwaggerDocs();
app.MapControllers();

app.Run();
