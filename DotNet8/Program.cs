// See https://aka.ms/new-console-template for more information
using System.Net;


#region HTTP/3

using var client = new HttpClient
{
    DefaultRequestVersion = HttpVersion.Version30,
    DefaultVersionPolicy = HttpVersionPolicy.RequestVersionExact
};

Console.WriteLine("--- localhost:5001 ---");

HttpResponseMessage resp = await client.GetAsync("https://jsonplaceholder.typicode.com/todos/1");
string body = await resp.Content.ReadAsStringAsync();

Console.WriteLine(
    $"status: {resp.StatusCode}, version: {resp.Version}, " +
    $"body: {body.Substring(0, Math.Min(100, body.Length))}");

#endregion
