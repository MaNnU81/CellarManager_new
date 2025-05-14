using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CellarManager.model;

namespace CellarManager
{
   
    internal class JsonStorage : IStorage
    {


        public void SaveAllBeverages(List<Beverage> beverages)
        {
            var jsonBeverages = new List<JsonBeverage>();
            foreach (var beverage in beverages)
            {
                jsonBeverages.Add(ToJsonBeverage(beverage));


            }

            var json = System.Text.Json.JsonSerializer.Serialize(jsonBeverages);

            try
            {
                File.WriteAllText("beverages.json", json);
            }
            catch (Exception ex)
            {

                Console.WriteLine("Error saving JSON file: " + ex.Message);
            }
        }


        private JsonBeverage ToJsonBeverage(Beverage beverage)
        {
            if (beverage is Beer beer)
            {
                return new JsonBeverage
                {
                    Class = "Beer",
                    Name = beer.Name,
                    Alcohol = beer.Alcohol,
                    Country = beer.Country,
                    Year = beer.Year,
                    Type = beer.Type.ToString(),
                    IBU = beer.IBU,
                    Grape = string.Empty
                };
            }
            else if (beverage is Wine wine)
            {
                return new JsonBeverage
                {
                    Class = "Wine",
                    Name = wine.Name,
                    Alcohol = wine.Alcohol,
                    Country = wine.Country,
                    Year = wine.Year,
                    Type = wine.Type.ToString(),
                    IBU = -1,
                    Grape = wine.Grape ?? string.Empty
                };
            }
            return null;

        }
        



        List<Beverage> IStorage.LoadAllBeverages()
        {
            var beverages = new List<Beverage>();

            try
            {
                var json = File.ReadAllText("beverages.json");
                var jsonBeverages = System.Text.Json.JsonSerializer.Deserialize<List<JsonBeverage>>(json) ?? [];

                foreach (var jsonBeverage in jsonBeverages)
                {

                    if (jsonBeverage.Class == "Beer")
                    {
                        var beer = new Beer
                        {
                            Name = jsonBeverage.Name,
                            Alcohol = jsonBeverage.Alcohol,
                            Country = jsonBeverage.Country,
                            Year = jsonBeverage.Year,
                            Type = (BeerType)Enum.Parse(typeof(BeerType), jsonBeverage.Type),
                            IBU = jsonBeverage.IBU
                        };
                    }
                    else if (jsonBeverage.Class == "Wine")
                    {
                        var wine = new Wine
                        {
                            Name = jsonBeverage.Name,
                            Alcohol = jsonBeverage.Alcohol,
                            Country = jsonBeverage.Country,
                            Year = jsonBeverage.Year,
                            Type = (WineType)Enum.Parse(typeof(WineType), jsonBeverage.Type),
                            Grape = jsonBeverage.Grape
                        }
                        ;
                    }
                }


                
                

            }
            catch (Exception)
            {

                Console.WriteLine("Error loading JSON file");   
            }
            return beverages;

        }

    
    }


    internal class JsonBeverage
    {
        public required string Class { get; set; } 
        public required string Name { get; set; }
        public required double Alcohol { get; set; }
        public required string Country { get; set; } 
        public required int Year { get; set; }
        public required string Type { get; set; }
        public required int IBU { get; set; }
        public required string Grape { get; set; } 



    }

   
}
