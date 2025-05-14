using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CellarManager.model
{
    internal abstract class Beverage
    {
        //public int Id { get; set; } 
        public required string Name { get; set; }

        private string? _country;
        public string Country { 
            get 
            {
                return _country ?? "Unknown";
            }
            set 
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    _country = "Unknown";
                }
                else
                {
                    _country = value;
                }
            } 
        }
        public int Year { get; set; }
        public required double Alcohol { get; set; }

        public override string ToString()
        {
            return $"{Name} ({Alcohol}%) - {Country}, {Year}";
        }

        public virtual string CsvFormat()
        {
            return $"{Name},{Alcohol},{Country},{Year}";
        }

        public abstract JsonBeverage ToJsonBeverage();  
    }
}
