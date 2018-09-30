using System;
using System.Diagnostics;
using System.Net.Http;
using System.Threading;

namespace NewReleaseMonitor
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Monitoring started...");

            var lastUpdate = GetLastUpdateTime();
            
            while (true)
            {
                Thread.Sleep(5000);

                var newLastUpdate = GetLastUpdateTime();

                if (newLastUpdate != lastUpdate)
                {
                    Process.Start(@"powershell", $@"-c (New-Object Media.SoundPlayer '../../../emergency030.wav').PlaySync();");
                    Thread.Sleep(1500);
                    Process.Start(@"powershell", $@"-c (New-Object Media.SoundPlayer '../../../NewVersion.wav').PlaySync();");

                    lastUpdate = newLastUpdate;
                }
            }
        }

        private static string GetLastUpdateTime()
        {
            var httpClient = new HttpClient { BaseAddress = new Uri("http://partsunlimitedhrbenefits.azurewebsites.net") };

            var response = httpClient.GetAsync("/lastupdate.txt").Result;

            var lastUpdate = response.Content.ReadAsStringAsync().Result;

            Console.WriteLine($"Last update: {lastUpdate}");
            
            return lastUpdate;
        }
    }
}
