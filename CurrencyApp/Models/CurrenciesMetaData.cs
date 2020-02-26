using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Xml.Serialization;

namespace CurrencyApp.Models
{
    //Класс для сериализации XML
    [Serializable]
    [XmlRoot("Valute")]
    public class CurrenciesMetaData
    {
        public int currencyId { get; set; }

        [XmlElement("Name")]
        public string name { get; set; }

        [XmlElement("Value")]
        public double rate { get; set; }
    }

    [MetadataType(typeof(CurrenciesMetaData))]
    public partial class Currency
    {
    }
}