using System;
using System.Collections.Generic;
using System.Text;

namespace Spel_Ganzenbord
{
    class Spelers
    {
        public string Naam { get; set; }
        public int Positie { get; set; }
        public List<string> beurtenOverslaan {get;set;}
        public bool inPut {get;set;}

        public Spelers(string ingevoerdeNaam)
        {
            Naam = ingevoerdeNaam;
            Positie = 0;
            inPut = false;
            beurtenOverslaan = new List<string>();

        }

        public void stappenZetten(int aantalStappen)
        {
            Positie += aantalStappen;
        }
    }
}
