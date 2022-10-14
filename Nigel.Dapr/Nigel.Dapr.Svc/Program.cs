using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Nigel.Dapr.DomainActors;


var builder = WebApplication.CreateBuilder(args);
builder.Services.AddActors(options =>
{
    options.Actors.RegisterActor<GoodsActor>();
});

var app = builder.Build();
app.UseRouting();

app.UseEndpoints(endpoints =>
{
    endpoints.MapActorsHandlers();
});
app.Run();