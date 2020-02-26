using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CurrencyApp.Models
{
    public partial class Currency
    {
        // ID Валюты
        public int currencyId { get; set; }

        // Имя валюты
        public string name { get; set; }

        //rate валюты
        public double rate { get; set; }
    }
}