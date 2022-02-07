using System;
using System.Collections.Generic;
using System.Text;

namespace Modelo
{
    public class SearchResult
    {
        public string site_id { get; set; }

        public string country_default_time_zone { get; set; }

        public string query { get; set; }

        public Paging paging { get; set; }

        public Result[] results { get; set; }
    }

    public class Paging
    {
        public int total { get; set; }

        public int primary_results { get; set; }

        public int offset { get; set; }

        public int limit { get; set; }
    }

    public class Result
    {
        public string id { get; set; }

        public string site_id { get; set; }

        public string title { get; set; }

        public double price { get; set; }

        public Seller seller { get; set; }
    }

    public class Seller
    {
        public string id { get; set; }

        public string permalink { get; set; }

    }
    
}
