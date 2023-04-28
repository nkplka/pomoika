using System;
using System.Net;
using Newtonsoft.Json;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("ip pls\nexample - mc.example.ru\n");

        string Url = Console.ReadLine();

        string apiUrl = $"https://api.mcsrvstat.us/2/{Url}";

        using (WebClient webClient = new WebClient())
        {
            try
            {
                string jsonData = webClient.DownloadString(apiUrl);
                dynamic result = JsonConvert.DeserializeObject<dynamic>(jsonData);

                if (result.online == true)
                {
                    Console.WriteLine("IP: " + result.ip);
                    Console.WriteLine("Port: " + result.port);
                    Console.WriteLine("Players Online: " + result.players.online);
                    Console.WriteLine("Version: " + result.version);
                    Console.ReadKey();
                }
                else
                {
                    Console.WriteLine("The server is offline.");
                    Console.ReadKey();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}