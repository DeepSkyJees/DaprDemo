// See https://aka.ms/new-console-template for more information
using Dapr.Client;
using Nigel.Dapr.ConsoleClient;
using System.Text.Json;
using Dapr.Actors;
using Dapr.Actors.Client;
using Nigel.Dapr.DomainActors;
using Dapr.Client.Autogen.Grpc.v1;

Console.WriteLine("Hello, World!");

//using var httpClient = DaprClient.CreateInvokeHttpClient();
//var responseResult = await httpClient.GetAsync("http://backend/WeatherForecast");
//var stringContent = await responseResult.Content.ReadAsStringAsync();
//var weatherForecastDataList = JsonSerializer.Deserialize<List<WeatherForecast>>(stringContent);

//foreach (WeatherForecast item in weatherForecastDataList)
//{
//    Console.WriteLine(JsonSerializer.Serialize(item));
//}
var client = new DaprClientBuilder().Build();
 
//var bindRequest = new BindingRequest("myevent", "create");

// var response = await client.InvokeBindingAsync(bindRequest);
await client.InvokeBindingAsync("myevent", "create", "word Dapr");
////消息发布
//client.PublishEventAsync<string>("pubsub", "receiveUserMessage", $"backend-{DateTime.Now}").GetAwaiter().GetResult();
//client.PublishEventAsync<string>("pubsub", "deathStarStatus", " dapr").GetAwaiter().GetResult();
//var actorId = "111";
//var goodsActor = ActorProxy.Create<IGoodsActor>(new ActorId(actorId), "GoodsActor");

//var startTime = DateTime.Now;

//Parallel.ForEach(Enumerable.Range(1, 10), async i =>
//{
//    while (true)
//    {
//        if (startTime.AddSeconds(10) <= DateTime.Now)
//        {
//            break;
//        }

//        var buyCount = new Random().Next(100);
//        var goods = await goodsActor.GetGoodsAsync();
//        Console.WriteLine($"[Worker-{i}] Count for Dapr Books '{goods.Name}' is '{goods.Count}'.");

//        Console.WriteLine($"[Worker-{i}] buy '{buyCount}'...");
//        try
//        {
//            await goodsActor.DeductGoodsAsync(buyCount);

//        }
//        catch (ActorMethodInvocationException ex)
//        {
//            Console.WriteLine("[Worker-{i}] Overdraft: " + ex.Message);
//        }

//        Task.Delay(1000).Wait();
//    }
//});
Console.ReadKey();
