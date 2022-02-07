using Microsoft.AspNetCore.Mvc;
using Modelo;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace Desafio_1.Controllers
{
    [Route("paises")]
    public class CountriesController : Controller
    {
        private readonly HttpClient MLClient;

        public CountriesController(IHttpClientFactory clientFactory)
        {
            this.MLClient = clientFactory.CreateClient("MLClient");
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Country>> GetPais([FromRoute] string id)
        {
            if(id.Equals("BR") || id.Equals("CO")){
                return Unauthorized();
            }

            var result = await MLClient.GetAsync($"classified_locations/countries/{id}");
            if (result.StatusCode == System.Net.HttpStatusCode.OK) { 
                return JsonConvert.DeserializeObject<Country>(await result.Content.ReadAsStringAsync());
            }

            return BadRequest();
            
        }
    }
}
