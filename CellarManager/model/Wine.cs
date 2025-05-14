using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CellarManager.model
{
    internal class Wine : Beverage
    {
        public string? Grape { get; set; }
        public required WineType Type { get; set; }
        public override string ToString()
        {
            return $"{base.ToString()} - {Type} - Grape: {Grape}";
        }

        public override string CsvFormat()
        {
            return $"Wine,{base.CsvFormat()},{Type},,{Grape}";
        }

        //public override JsonBeverage ToJsonBeverage()
        //{
        //    return new JsonBeverage()
        //    {
        //        Class = "Wine",
        //        Name = Name,
        //        Alcohol = Alcohol,
        //        Country = Country,
        //        Year = Year,
        //        Type = Type.ToString(),
        //        IBU = -1,
        //        Grape = Grape ?? string.Empty
        //    };
        //}
    }

    public enum WineType
    {
        Red,
        White,
        Rose,
        Sparkling,
        Dessert
    }
}