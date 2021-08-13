using Microsoft.AspNetCore.SignalR.Client;
using System;
using System.Threading.Tasks;

namespace ChatClient
{
    class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine("Write Stuff, and Receive Stuff.");
            Console.WriteLine("Enter your name:");
            string user = Console.ReadLine();

            HubConnection connection = new HubConnectionBuilder()
                .WithUrl("http://localhost:5000/chat").Build();

            connection.Closed += async (error) =>
            {
                await Task.Delay(new Random().Next(0, 5) * 1000);
                await connection.StartAsync();
            };

            connection.On<string, string>("ReceiveMessage", (user, message) =>
            {
                Console.WriteLine($"{user}:: {message}");
            });

            try
            {
                await connection.StartAsync();
                while (true)
                {
                    string message = Console.ReadLine();
                    await connection.InvokeAsync("SendMessage", user, message);
                }
            } catch (Exception ex)
            {
                ;
            }
        }
    }
}
