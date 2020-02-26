using CurrencyApp.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;
using System.Xml.Linq;

namespace CurrencyApp.Controllers
{
    public class HomeController : Controller
    {
        //private CurrencyContext currencyDb = new CurrencyContext();

        public ActionResult Index()
        {
            //Database.SetInitializer<ApplicationDbContext>(new AppSecurityDbInitializer());
            //Database.SetInitializer(new CurrencyDbInitializer());
            ViewBag.Title = "Main CurrenyApp Page";
            return View();
        }


        //Метод для обновления данных в таблице 
        //[Authorize]
        //[HttpPost]
        public ActionResult Update()
        {
            HttpClient http = new HttpClient();
            var data = http.GetAsync("http://www.cbr.ru/scripts/XML_daily.asp").Result.Content.ReadAsStringAsync().Result;
            XDocument xDoc = XDocument.Parse(data);

            List<Currency> currencyList = xDoc.Descendants("Valute").Select
                (currency => new Currency
                {
                    name = currency.Element("Name").Value,
                    rate = Convert.ToDouble(currency.Element("Value").Value)
                }).ToList();

            using (CurrencyContext currencyDb = new CurrencyContext())
            {
                foreach (var i in currencyList)
                {
                    var v = currencyDb.Currency.Where(cur => cur.name.Equals(i.name)).FirstOrDefault();

                    if (v != null)
                    {
                        v.name = i.name;
                        v.rate = i.rate;
                    }
                    else
                    {
                        currencyDb.Currency.Add(i);
                    }

                    currencyDb.SaveChanges();
                }
            }

            ViewBag.Success = "Updated successfully..";

            return View("Index");
        }
    }
}
