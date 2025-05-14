using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CellarManager.model;

namespace CellarManager
{
    internal class Tui
    {

        private ILogic _logic;
        public Tui(ILogic logic)
        {
            _logic = logic;
        }

        internal void Start()
        {
            //_logic.AddBeer("Pilsner", 5.0, BeerType.Pilsner, "Germany", 2020, 40);
            //_logic.AddBeer("IPA", 6.5, BeerType.IPA, "USA", 2021, 60);
            //_logic.AddWine("Chardonnay", 13.5, WineType.White, "France", 2019, "Chardonnay");
            //_logic.AddWine("Merlot", 14.0, WineType.Red, "Italy", 2018, "Merlot");
            //_logic.AddWine("Sauvignon Blanc", 12.5, WineType.White, "New Zealand", 2020, "Sauvignon Blanc");

            //foreach (var bev in _logic.GetBeverages())
            //{
            //    Console.WriteLine(bev.ToString());
            //}

            while (true)
            {

                Console.WriteLine("Welcome to the Cellar Manager!");
                Console.WriteLine("1. Add Beer");
                Console.WriteLine("2. Add Wine");
                Console.WriteLine("3. List Beverages");
                Console.WriteLine("4. Delete Beverage");
                Console.WriteLine("5. Search Beverage");  
                Console.WriteLine("6. Exit");
                Console.Write("Please select an option: ");
                string? input = Console.ReadLine();
                switch (input)
                {
                    case "1":
                        AddBeer();
                        break;
                    case "2":
                        AddWine();
                        break;
                    case "3":
                        ListBeverages();
                        break;
                    case "4":
                        DeleteBeverage();
                        break;
                    case "5":
                        Search();
                        break;
                    case "6":
                        return;
                    default:
                        Console.WriteLine("Invalid option, please try again.");
                        break;
                }
            }
        }

      

        private void AddBeer()
        {
            Console.Write("Enter beer name: ");
            string? name = Console.ReadLine();
            Console.Write("Enter alcohol percentage: ");
            double alcohol = double.Parse(Console.ReadLine() ?? "0");
            Console.Write("Enter beer type (Pilsner, IPA, Stout): ");
            BeerType type = Enum.TryParse<BeerType>(Console.ReadLine(), out BeerType parsedType) ? parsedType : BeerType.Pilsner;
            //BeerType type = (BeerType)Enum.Parse(typeof(BeerType), Console.ReadLine() ?? "Pilsner");
            Console.Write("Enter country of origin: ");
            string? country = Console.ReadLine();
            Console.Write("Enter year of production: ");
            int? year = int.TryParse(Console.ReadLine(), out int y) ? y : null;
            Console.Write("Enter IBU: ");
            int? ibu = ParseInt(Console.ReadLine());
            _logic.AddBeer(name ?? "ecco", alcohol, type, country, year, ibu);
        }

        private int ParseInt(string? input)
        {
            //int result;

            //try
            //{
            //    result = int.Parse(input ?? "0");
            //}
            //catch(Exception ex) {
            //    Console.WriteLine($"Invalid input, please enter a valid integer: {ex.Message}");
            //    result = -1;
            //}


            //return result;

            //var anim = new Animal("Dog", 5);

            //var res = changeName("cucciolino", anim);

            //Console.WriteLine($"Animal name changed: {anim.Name}");


            var success = int.TryParse(input, out int result);

            if (success) return result;

            return 0;

        }


        //private bool changeName(string input, Animal animale)
        //{
        //    if (input.Length > 5)
        //    {
        //        animale.Name = input;
        //        return true;
        //    }
        //    return false;
        //}

        private void AddWine()
        {
            Console.Write("Enter wine name: ");
            string? name = Console.ReadLine();
            Console.Write("Enter alcohol percentage: ");
            double alcohol = double.Parse(Console.ReadLine() ?? "0");
            Console.Write("Enter wine type (Red, White, Rose): ");
            WineType type = Enum.TryParse<WineType>(Console.ReadLine(), out WineType parsedType) ? parsedType : WineType.Red;
            //WineType type = (WineType)Enum.Parse(typeof(WineType), Console.ReadLine() ?? "Red");
            Console.Write("Enter country of origin: ");
            string? country = Console.ReadLine();
            Console.Write("Enter year of production: ");
            int? year = int.TryParse(Console.ReadLine(), out int y) ? y : null;
            Console.Write("Enter grape variety: ");
            string? grape = Console.ReadLine();
            _logic.AddWine(name ?? "ecco", alcohol, type, country, year, grape);
        }

        private void ListBeverages()
        {
            Console.WriteLine("Beverages in the cellar:");
            for(int i = 0; i < _logic.GetBeverages().Count; i++)
            {
                Console.WriteLine($"{i + 1}) {_logic.GetBeverages()[i].ToString()}");
            }

        }


        private void DeleteBeverage()
        {
            Console.WriteLine("Inserisci il numero della bevanda da eliminare");
            ListBeverages();    
            var res = int.TryParse(Console.ReadLine(), out int index) ;
            if (res)
            {
                _logic.DeleteBeverage(index);
            }
        }

        private void Search()
        {
            Console.WriteLine("Inserisci il nome della bevanda da ricercare");
            var name = Console.ReadLine();

            var res = _logic.GetBeverages().Where(b => b.Name.ToLower().Contains(name.ToLower())).ToList();
            if (res.Count == 0)
            {
                Console.WriteLine("Nessun risultato trovato");
            }
            else
            {
                Console.WriteLine("Risultati trovati:");
                foreach (var item in res)
                {
                    Console.WriteLine(item.ToString());
                }
            }
        }

    }

    //class Animal
    //{
    //    public string Name { get; set; }
    //    public int Age { get; set; }
    //    public Animal(string name, int age)
    //    {
    //        Name = name;
    //        Age = age;
    //    }
    //    public override string ToString()
    //    {
    //        return $"{Name} is {Age} years old.";
    //    }
    //}

}
