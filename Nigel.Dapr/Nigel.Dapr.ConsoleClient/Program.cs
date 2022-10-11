// See https://aka.ms/new-console-template for more information
using Dapr.Client;
using Nigel.Dapr.ConsoleClient;
using System.Text.Json;

Console.WriteLine("Hello, World!");

using var httpClient = DaprClient.CreateInvokeHttpClient();
var responseResult = await httpClient.GetAsync("http://backend/WeatherForecast");
var stringContent = await responseResult.Content.ReadAsStringAsync();
var weatherForecastDataList = JsonSerializer.Deserialize<List<WeatherForecast>>(stringContent);

foreach (WeatherForecast item in weatherForecastDataList)
{
    Console.WriteLine(JsonSerializer.Serialize(item));
}Console.ReadLine();