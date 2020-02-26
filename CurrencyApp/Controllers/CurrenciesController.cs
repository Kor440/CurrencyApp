using CurrencyApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json;
using System.Net.Http.Formatting;
using AuthorizeAttribute = System.Web.Http.AuthorizeAttribute;
using System.Web.Http.OData.Builder;
using System.Web.Http.OData.Extensions;
using System.Web.Http.OData;
using System.Web.Http.OData.Routing;

namespace CurrencyApp.Controllers
{
    [Authorize]
    public class CurrenciesController : ApiController
    {
        // GET api/currencies?"odata commands"
        [Queryable]
        public HttpResponseMessage Get()
        {
            using (CurrencyContext currencyDb = new CurrencyContext())
            {
                var currencies = currencyDb.Currency.ToList().AsQueryable();
                return Request.CreateResponse(HttpStatusCode.OK, new { data = currencies.AsQueryable()});
            } 
        }

        [System.Web.Http.HttpGet]
        [System.Web.Http.Route("api/currency")]
        public IHttpActionResult GetC(int id)
        {
            using (CurrencyContext currencyDb = new CurrencyContext())
            {
                var currency = currencyDb.Currency.FirstOrDefault(cur => cur.currencyId == id);
                return Ok(new { data = currency });
            }
        }

        // GET api/currenciesT for dataTable
        [System.Web.Http.HttpGet]
        [System.Web.Http.Route("api/currenciesT")]
        public IHttpActionResult GetT()
        {
            using (CurrencyContext currencyDb = new CurrencyContext())
            {
                var currencies = currencyDb.Currency.ToList().AsQueryable();
                return Ok(new { data = currencies });
            }
        }
        
    }
}
