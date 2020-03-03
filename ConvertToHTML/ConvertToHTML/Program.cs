using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConvertToHTML
{
    class Program
    {
        static void Main(string[] args)
        {
            //var club = new FootballClub("Milan", 1899, 12, 7);
            
            //club.ConvertToHTML();

            var car = new Car() { CarName = "Audi", CarYear = 2018, BodyType = "sedan", 
                BodyColor = "black", HorsePower = 250, Passengers = 5 };

            car.ConvertToHTML();

            //Console.ReadKey();
        }
    }
}
