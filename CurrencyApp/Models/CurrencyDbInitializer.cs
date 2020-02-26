using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace CurrencyApp.Models
{
    // Для инициализации и заполнения Бд
    public class CurrencyDbInitializer : CreateDatabaseIfNotExists<CurrencyContext>
    {
        protected override void Seed(CurrencyContext currency)
        {
            currency.Currency.Add(new Currency { name = "Австралийский доллар", rate = 42.6705 });
            base.Seed(currency);
        }
    }
}