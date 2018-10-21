using System;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Threading;
using Microsoft.Extensions.Configuration;

namespace NewReleaseMonitor
{
    class Program
    {
        public static IConfigurationRoot Configuration { get; set; }

        static void Main(string[] args)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Path.Combine(AppContext.BaseDirectory))
                .AddJsonFile("appsettings.json", optional: true);
            Configuration = builder.Build();

            Console.WriteLine("Monitoring started...");

            var previousLastUpdate = GetLastUpdateTime();
            var lastUpdate = previousLastUpdate;

            while (true)
            {
                if (lastUpdate != previousLastUpdate)
                {
                    Process.Start(@"powershell", $@"-c (New-Object Media.SoundPlayer '../../../emergency030.wav').PlaySync();");
                    Thread.Sleep(1500);

                    Process.Start(@"powershell", $@"-c (New-Object Media.SoundPlayer '../../../NewVersion.wav').PlaySync();");

                    previousLastUpdate = lastUpdate;
                }

                Thread.Sleep(5000);
                var serverResponse = GetLastUpdateTime();

                if (serverResponse.Length < 45) // E.g. Last update: Sun 10/21/2018 20:05:09.17, longer would be an error message.
                {
                    lastUpdate = serverResponse;
                }
            }
        }

        private static string GetLastUpdateTime()
        {
            var httpClient = new HttpClient(CreateHttpClientHandlerForConfiguration()) { BaseAddress = new Uri("http://partsunlimitedhrbenefits.azurewebsites.net") };

            var response = httpClient.GetAsync("/lastupdate.txt").Result;

            var lastUpdate = response.Content.ReadAsStringAsync().Result;

            Console.WriteLine($"{lastUpdate}");
            
            return lastUpdate;
        }

        private static HttpClientHandler CreateHttpClientHandlerForConfiguration()
        {
            var proxyAddress = Configuration["proxyAddress"];

            if (proxyAddress != "")
            {
                return new HttpClientHandler
                {
                    Proxy = new WebProxy(proxyAddress, BypassOnLocal: true),
                    PreAuthenticate = true,
                    UseDefaultCredentials = false,
                };
            }
            else
            {
                return new HttpClientHandler();
            }
        }
    }
}
