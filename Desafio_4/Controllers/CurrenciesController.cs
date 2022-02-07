using CsvHelper;
using Microsoft.AspNetCore.Mvc;
using Modelo;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Desafio_4.Controllers
{
    [Route("currencies")]
    public class CurrenciesController : Controller
    {
        private readonly HttpClient MLClient;

        public CurrenciesController(IHttpClientFactory clientFactory)
        {
            this.MLClient = clientFactory.CreateClient("MLClient");
        }
                
        [HttpGet]
        public async Task<ActionResult> GetCurrencies()
        {
            var currenciesResult = await MLClient.GetAsync("currencies");
            List<Currency> currencies = new List<Currency>();

            var now = DateTime.Now;
            var actualDirectory = $"{Directory.GetCurrentDirectory()}/files/{now.ToString("ddMMyyyy_hhmmss")}";
            if (!Directory.Exists(actualDirectory))
                Directory.CreateDirectory(actualDirectory);

            if (currenciesResult.StatusCode == System.Net.HttpStatusCode.OK)
            {
                var json = await currenciesResult.Content.ReadAsStringAsync();
                currencies = JsonConvert.DeserializeObject<List<Currency>>(json);
                SaveCurrencies(json, actualDirectory);
            }

            foreach (var currency in currencies)
            {
                var currencyConversionResult = await MLClient.GetAsync($"currency_conversions/search?from={currency.Id}&to=USD");
                if (currencyConversionResult.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    var toDolar = JsonConvert.DeserializeObject<Todolar>(await currencyConversionResult.Content.ReadAsStringAsync());
                    currency.Todolar = toDolar;
                }
            }
            GenerateAndSaveCSV(currencies, actualDirectory);

            return Ok(currencies);
        }

        private void SaveCurrencies(string json, string directory)
        {
            System.IO.File.WriteAllText($"{directory}/currencies_{DateTime.Now.ToString("ddMMyyyy_HHmmss")}.json", json);
        }

        private void GenerateAndSaveCSV(IList<Currency> currencies, string directory)
        {

            using (var textWriter = new StreamWriter($"{directory}/currency_conversions_{DateTime.Now.ToString("ddMMyyyy_HHmmss")}.csv"))
            {
                var writer = new CsvWriter(textWriter, CultureInfo.InvariantCulture);

                foreach (var currency in currencies)
                {
                    writer.WriteField(currency.Id);
                }
                writer.NextRecord();
                foreach (var currency in currencies)
                {
                    writer.WriteField(currency.Todolar != null ? currency.Todolar.Ratio.ToString() : "SIN DATOS");
                }
                writer.NextRecord();
            }
        }
    }
}
