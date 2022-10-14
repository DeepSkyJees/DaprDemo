using Google.Api;
using Microsoft.AspNetCore.Mvc;
using Nigel.Dapr.BackendApi;
using Nigel.Dapr.DomainActors;
using Nigel.Extensions.Swashbuckle;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.


builder.Services.AddActors(options =>
{
    options.Actors.RegisterActor<UserActor>();
    options.Actors.RegisterActor<GoodsActor>();
});
builder.Services.AddControllers(opt =>
{
    opt.UseCentralRoutePrefix(new RouteAttribute("Backend"));
});//.AddDapr();
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

//app.UseSwaggerDocs();
app.UseRouting();

app.UseAuthorization();
app.UseEndpoints(endpoints =>
{
    endpoints.MapActorsHandlers();
    endpoints.MapControllers();

});
//app.MapControllers();

app.Run();
