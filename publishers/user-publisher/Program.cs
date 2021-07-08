using System;
using System.Net.Http;
namespace pub
{
    class Program
    {
        static readonly HttpClient client=new HttpClient();

 
        static readonly string daprPort =Environment.GetEnvironmentVariable("DAPR_HTTP_PORT") ;
        static void Main(string[] args)
        {
            for(int counter=0; counter <100;counter++)
            {
             var data =$"{{\"action\":\"add\",\"id\":\"{counter}\"}}";
             System.Console.WriteLine($"Sending {data}");
             var content = new StringContent(data, System.Text.Encoding.UTF8,"application/json");
             var response = client.PostAsync($"http://localhost:{daprPort}/v1.0/publish/pubsub/above-store-user",content).Result;
            }   
        }
            
    }
}
