using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace LINQ
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] currentVideoGames = { "Morrowind", "Uncharted 2", "Fallout 3", "Daxter", "SystemShock 2", "Super Mario" };
            Game.QuerryWithExtensionMethod(currentVideoGames);
            Console.WriteLine();
            IEnumerable<string> subset = Game.GetStringSubset();
            foreach (string item in subset)
            {
                Console.WriteLine(item);
            }

            List<Car> cars = new List<Car>()
            {
                 new Car{ PetName = "Troy", Color="Yellow", Speed=65, Make= "Toyota" },
                new Car{ PetName = "Henry", Color = "Silver", Speed = 100, Make = "BMW"},
                new Car{ PetName = "Daisy", Color = "Tan", Speed = 90, Make = "BMW"},
                new Car{ PetName = "Mary", Color = "Black", Speed = 55, Make = "VW"},
                new Car{ PetName = "Clunker", Color = "Rust", Speed = 5, Make = "Yugo"},
                new Car{ PetName = "Melvin", Color = "White", Speed = 43, Make = "Ford" }              
            };
      
            ArrayList myCars = new ArrayList() 
            {
                new Car{ PetName = "Henry", Color = "Silver", Speed = 100, Make = "BMW"},
                new Car{ PetName = "Daisy", Color = "Tan", Speed = 90, Make = "BMW"},
                new Car{ PetName = "Mary", Color = "Black", Speed = 55, Make = "VW"},
                new Car{ PetName = "Clunker", Color = "Rust", Speed = 5, Make = "Yugo"},
                new Car{ PetName = "Melvin", Color = "White", Speed = 43, Make = "Ford"}
            };
            // var  myCarsE = myCars.OfType<Car>();
            Console.WriteLine();
            GetFastCars(cars);    //List<Car>
            GetFastCars(myCars);  //ArrayList
            NewItem(myCars);
            Diff(cars, myCars);  //
           
            Console.WriteLine();            
        }
        static void GetFastCars(List<Car> myCars)
        {
            Console.WriteLine("Generic");
            // Find all Car objects in the List<>, where the Speed is
            // greater than 55.
            var fastCars = from c in myCars where c.Speed > 5 orderby c.Speed select c; //orderby c.Speed
            foreach (var car in fastCars)
            {
                Console.WriteLine($"{ car.PetName} is going too fast!");
            }
        }

        static void GetFastCars(ArrayList myCarsArrayList)
        {
            Console.WriteLine("Arrar List");           
            var myCarsEnum = myCarsArrayList.OfType<Car>();   // Transform ArrayList into an IEnumerable<T>-compatible type.
            
            var fastCars = from c in myCarsEnum where c.Speed > 55 && c.Speed<100 select c; //We can get all the date without condition
            foreach (var car in fastCars)
            {
                Console.WriteLine($"{car.PetName} is going too fast!");
            }
        }

        static void NewItem(ArrayList arrayList)
        {
            Console.WriteLine("New Item");            
            var carList = arrayList.OfType<Car>();   // Transform ArrayList into an IEnumerable<T>-compatible type.

            var newItems = from i in carList where i.Speed > 85 select new {PetName= i.PetName, Speed=i.Speed }; //Projecting New Data Types with new
            int count = newItems.Count();         //To get the count
            Console.WriteLine($"{count} element ");
            foreach (var item in newItems.Reverse())
            {               
                Console.WriteLine(item.ToString());  // Could also use Name and Description properties directly.
            }
        }

        static void Diff(List<Car> cl, ArrayList ca)
        {
            Console.WriteLine("Difference between collections");
            var myCarsEnumerable = ca.OfType<Car>();
            var carDiff = (from c in cl select c).Concat(from c2 in myCarsEnumerable select c2);
            foreach (var item in carDiff)
            {
                Console.WriteLine(item.PetName);
            }
        }       
    }
}
