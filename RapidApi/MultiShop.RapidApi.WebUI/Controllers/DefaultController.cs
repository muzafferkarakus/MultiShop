using Microsoft.AspNetCore.Mvc;
using MultiShop.RapidApi.WebUI.Models;
using Newtonsoft.Json;

namespace MultiShop.RapidApi.WebUI.Controllers
{
    public class DefaultController : Controller
    {
        public async Task<IActionResult> WeatherDetail()
        {
            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri("https://weather-api167.p.rapidapi.com/api/weather/forecast?place=%C4%B0stanbul&cnt=3&units=standard&type=three_hour&mode=json&lang=en"),
                Headers =
    {
        { "x-rapidapi-key", "83f88aaf35msh5bee98e575be6ebp109084jsn4c2c9f5495b9" },
        { "x-rapidapi-host", "weather-api167.p.rapidapi.com" },
        { "Accept", "application/json" },
    },
            };
            using (var response = await client.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
                var body = await response.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<WeatherViewModel>(body);
                ViewBag.cityTemp = values.temp;
                return View(values);
            }
        }

        public async Task<IActionResult> Exchange()
        {
            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri("https://real-time-finance-data.p.rapidapi.com/currency-exchange-rate?from_symbol=USD&to_symbol=TRY&language=tr"),
                Headers =
    {
        { "x-rapidapi-key", "83f88aaf35msh5bee98e575be6ebp109084jsn4c2c9f5495b9" },
        { "x-rapidapi-host", "real-time-finance-data.p.rapidapi.com" },
    },
            };
            using (var response = await client.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
                var body = await response.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<ExchangeViewModel.Rootobject>(body);
                ViewBag.exchangeRate = values.data.exchange_rate;
                return View();
            }
        }
    }

}
