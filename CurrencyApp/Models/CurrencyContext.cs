using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace CurrencyApp.Models
{
    public class CurrencyContext : DbContext
    {
        public CurrencyContext() : base("CurrencyDB")
        {
            //Database.SetInitializer<CurrencyContext>(new CreateDatabaseIfNotExists<CurrencyContext>());
            //Database.SetInitializer(new CurrencyDbInitializer());
            //Database.SetInitializer<CurrencyContext>(new DropCreateDatabaseIfModelChanges<CurrencyContext>());
        }

        public DbSet<Currency> Currency { get; set; }
    }
}