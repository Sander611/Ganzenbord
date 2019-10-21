using System;
using System.Collections.Generic;
using System.Text;

namespace Spel_Ganzenbord
{
    class Program
    {
        static void Main(string[] args)
        {
            Spel nieuwspel = new Spel();
            Console.WriteLine("Hoeveel spelers doen er mee?: ");
            string AantalSpelers = Console.ReadLine();

            nieuwspel.spelersMaken(int.Parse(AantalSpelers));

            nieuwspel.spelStarten();

        }


        


    }
}
