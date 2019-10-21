using System;
using System.Collections.Generic;

namespace Spel_Ganzenbord
{
    class Spelbord
    {
        public string checkSpel(Spelers speler, int dobbelWaarde, ref bool winnaarGevonden, ref List<Spelers> alleSpelersInPut)
        {
            switch (speler.Positie)
            {
                case 6:
                    speler.stappenZetten(6);
                    return "Speler " + Convert.ToString(speler.Naam) + " heeft de brug genomen en is daarmee naar positie " + Convert.ToString(speler.Positie) + " gelopen!";
                case 19:
                    speler.beurtenOverslaan = new List<string>() { "x" };
                    return "Speler " + Convert.ToString(speler.Naam) + " is aangekomen bij de Herberg en slaat de volgende keer een beurt over.";
                case 31:
                    speler.inPut = true;
                    alleSpelersInPut.Add(speler);
                    return "Speler " + Convert.ToString(speler.Naam) + " is in de put gevallen en moet wachten op een andere speler tot die bij de put komt.";
                case 42:
                    speler.Positie = 39;
                    return "Speler " + Convert.ToString(speler.Naam) + " is verdwaald geraakt in een doolhof en is hierdoor teruggevalle naar plek 39.";
                case 52:
                    speler.beurtenOverslaan = new List<string>() { "x", "x", "x" };
                    return "Speler " + Convert.ToString(speler.Naam) + " zit vast in de gevangenis en moet 3 beurten overslaan.";
                case 58:
                    speler.Positie = 0;
                    return "Speler " + Convert.ToString(speler.Naam) + " is doodgegaan en wordt herboren bij het startpunt 0.";
                case 63:
                    winnaarGevonden = true;
                    return "Speler " + Convert.ToString(speler.Naam) + " heeft gewonnen! Het spel eindigt.";
                case int n when (n > 63):
                    int tooMuch = speler.Positie - 63;
                    speler.Positie = 63 - tooMuch;
                    return "Oeps! te ver gegaan, ga " + Convert.ToString(tooMuch) + " plaatsen terug..";
                default:
                    return "GEEN SPECIAAL VAKJE.";
            }
        }
    }
}
