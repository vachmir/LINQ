using System;
using System.Collections.Generic;
using System.Linq;

namespace LINQ
{
    class Game
    {
        public static void QuerryWithExtensionMethod(string[] currentVideoGames)
        {
            //string[] currentVideoGames = { "Morrowind", "Uncharted 2", "Fallout 3", "Daxter", "SystemShock 2", "Super Mario" };
            IEnumerable<string> subset = from ppp in currentVideoGames where ppp.Contains(" ") orderby ppp select ppp;
            //IEnumerable<string> subset = currentVideoGames.Where(g => g.Contains(" ")).OrderBy(g => g).Select(g => g);
            // Print out the results.
            foreach (string s in subset)
            {
                Console.WriteLine($"Item: {s}");
            }
            subset.ToString();
            int[] numbers = { 10, 20, 30, 40, 1, 3, 2, 0, 4, 8 };
            //get the first element in sequence order
            int number = (from i in numbers where i<10 select i).First();
            Console.WriteLine("First is {0}", number);

        }

       public static IEnumerable<string> GetStringSubset()
        {
            string[] colors = { "Light Red", "Green", "Yellow", "Dark Red", "Red", "Purple" };
            // Note subset is an IEnumerable<string>-compatible object.
            IEnumerable<string> theRedColors = from c in colors where c.Contains("Red") select c;
            return theRedColors;
        }
    }
}
