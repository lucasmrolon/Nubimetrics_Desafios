using Microsoft.AspNetCore.Mvc;
using Modelo;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace Desafio_2.Controllers
{
    [Route("busqueda")]
    public class SearchsController : Controller
    {
        private readonly HttpClient MLClient;

        public SearchsController(IHttpClientFactory clientFactory)
        {
            this.MLClient = clientFactory.CreateClient("MLClient");
        }

        [HttpGet("{termino}")]
        public async Task<ActionResult<SearchResult>> GetSearchResults([FromRoute] string termino)
        {

            var result = await MLClient.GetAsync($"sites/MLA/search?q={termino}#json");
            if (result.StatusCode == System.Net.HttpStatusCode.OK)
            {
                return JsonConvert.DeserializeObject<SearchResult>(await result.Content.ReadAsStringAsync());
            }

            return BadRequest();

        }
    }
}

