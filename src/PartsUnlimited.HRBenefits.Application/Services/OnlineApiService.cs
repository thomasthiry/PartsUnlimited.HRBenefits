using System;
using System.Net.Http;
using Newtonsoft.Json;

namespace PartsUnlimited.HRBenefits.Application.Services
{
    public class OnlineApiService
    {
        public int GetPublicHolidays(int employeeId)
        {
            var httpclient = new HttpClient();
            httpclient.BaseAddress = new Uri("http://localhost:49830");

            var response = httpclient.GetAsync($"/onlineapi/baseholidays?employeeId={employeeId}").Result;
                
            var responseText = response.Content.ReadAsStringAsync().Result;

            var responseObject = JsonConvert.DeserializeObject<ResponseObject>(responseText);

            return Convert.ToInt32(responseObject.BaseHolidays);
        }

        internal class ResponseObject
        {
            public int BaseHolidays { get; set; }
        }
    }
}