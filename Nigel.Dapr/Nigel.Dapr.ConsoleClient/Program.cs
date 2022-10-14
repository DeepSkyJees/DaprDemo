// See https://aka.ms/new-console-template for more information
using Dapr.Client;
using Nigel.Dapr.ConsoleClient;
using System.Text.Json;
using Dapr.Actors;
using Dapr.Actors.Client;
using Nigel.Dapr.DomainActors;

Console.WriteLine("Hello, World!");

//using var httpClient = DaprClient.CreateInvokeHttpClient();
//var responseResult = await httpClient.GetAsync("http://backend/WeatherForecast");
//var stringContent = await responseResult.Content.ReadAsStringAsync();
//var weatherForecastDataList = JsonSerializer.Deserialize<List<WeatherForecast>>(stringContent);

//foreach (WeatherForecast item in weatherForecastDataList)
//{
//    Console.WriteLine(JsonSerializer.Serialize(item));
//}

var goodsActor = ActorProxy.Create<IGoodsActor>(ActorId.CreateRandom(), "GoodsActor");

Parallel.ForEach(Enumerable.Range(1, 10), async i =>
{
    while (true)
    {
        var goods = await goodsActor.GetGoodsAsync();
        Console.WriteLine($"[Worker-{i}] Count for Dapr Books '{goods.Name}' is '{goods.Count}'.");

        Console.WriteLine($"[Worker-{i}] buy '1'...");
        try
        {
            await goodsActor.DeductGoodsAsync(new Random().Next(10));
        }
        catch (ActorMethodInvocationException ex)
        {
            Console.WriteLine("[Worker-{i}] Overdraft: " + ex.Message);
        }

        Task.Delay(1000).Wait();
    }
});
Console.ReadKey();
