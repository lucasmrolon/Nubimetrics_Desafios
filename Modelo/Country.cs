﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Modelo
{
    public class Country
    {
        public string id { get; set; }

        public string name { get; set; }

        public string locale { get; set; }

        public string decimal_separator { get; set; }

        public string thousands_separator { get; set; }

        public string time_zone { get; set; }

        public GeoInformation geo_information { get; set; }

        public State[] states { get; set; }
    }

    public class GeoInformation
    {
        public Location location { get; set; }
    }

    public class Location
    {
        public double latitude { get; set; }

        public double longitude { get; set; }
    }

    public class State
    {
        public string id { get; set; }

        public string name { get; set; }
    }
}
