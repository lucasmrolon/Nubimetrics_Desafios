using System;
using System.Collections.Generic;
using System.Text;

namespace Modelo
{
    public class Currency
    {
        public string Id { get; set; }

        public string Symbol { get; set; }

        public string Description { get; set; }

        public int Decimal_places { get; set; }

        public Todolar Todolar { get; set; }
    }

    public class Todolar
    {
        public string Currency_base { get; set; }

        public string Currency_quote { get; set; }

        public double Ratio { get; set; }

        public double Rate { get; set; }

        public double Inv_rate { get; set; }

        public string Creation_date { get; set; }

        public string Valid_until { get; set; }
    }
}
