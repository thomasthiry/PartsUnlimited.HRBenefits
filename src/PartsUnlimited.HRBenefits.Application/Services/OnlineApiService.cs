﻿using System;
using System.Net;
using System.Net.Http;
using Newtonsoft.Json;

namespace PartsUnlimited.HRBenefits.Application.Services
{
    public class OnlineApiService
    {
        public int GetBaseHolidays(int employeeId)
        {
            var httpClient = new HttpClient {BaseAddress = new Uri("https://partsunlimitedhrbenefits.azurewebsites.net")};

            var response = httpClient.GetAsync($"/externalsystem/baseholidays?employeeId={employeeId}").Result;
                
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