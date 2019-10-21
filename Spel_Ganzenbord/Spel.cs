using System;
using System.Collections.Generic;
using System.Text;

namespace Spel_Ganzenbord
{
    class Spel
    {
        public List<Spelers> spelerLijst = new List<Spelers>();
        public List<Spelers> spelersInPut = new List<Spelers>();

        public Spelbord spelbord = new Spelbord();
        public Dobbelsteen dobbelsteen = new Dobbelsteen();

        public bool winnaarBekend = false;

        public void spelersMaken(int aantalSpelers)
        {

            for (int x = 1; x <= aantalSpelers; x++)
            {
                Console.WriteLine("Voer een Naam in: ");
                string naam = Console.ReadLine();
                Spelers SpelerInstance = new Spelers(naam);
                spelerLijst.Add(SpelerInstance);
            }
        }



        public void spelStarten()
        {
            while (winnaarBekend == false)
            {
                foreach (Spelers speler in spelerLijst)
                {
                    if (speler.inPut == false && speler.beurtenOverslaan.Count == 0){
                        Console.WriteLine("Speler " + Convert.ToString(speler.Naam) + " is aan zet. En staat momenteel op vakje: " + Convert.ToString(speler.Positie) + ".");
                        int gegooideWaarde = dobbelsteen.dobbelen();
                        speler.stappenZetten(gegooideWaarde);
                        Console.WriteLine("Speler " + Convert.ToString(speler.Naam) + " gooide " + gegooideWaarde + " en is hiermee beland op vakje " + Convert.ToString(speler.Positie) + ".");
                        Console.WriteLine(spelbord.checkSpel(speler, gegooideWaarde, ref winnaarBekend, ref spelersInPut));
                        if (spelersInPut.Count > 1)
                        {
                            spelersVerwijderen();
                        }
                        if (winnaarBekend == true) 
                        {
                            break;
                        }
                        Console.WriteLine("Druk ergens op om je beurt te eindigen");
                        Console.WriteLine(" ");
                        Console.ReadKey();
                    }

                    else{
                        if (speler.inPut){
                            Console.WriteLine("Speler "+ Convert.ToString(speler.Naam) +" bevindt zich in de put en moet wachten op een andere speler tot hij/zij gevonden wordt!");
                            Console.WriteLine(" ");
                            continue;
                        }
                        else {
                            List<string> currBeurtenOverslaan = speler.beurtenOverslaan;
                            Console.WriteLine("Speler " + Convert.ToString(speler.Naam) + " moet nog "+ currBeurtenOverslaan.Count +" beurt wachten!");
                            Console.WriteLine(" ");
                            currBeurtenOverslaan.RemoveAt(currBeurtenOverslaan.Count - 1);
                            speler.beurtenOverslaan = currBeurtenOverslaan;
                            continue;
                        }
                    
                    }
                }

            }


        }

        public void spelersVerwijderen()
        {
            foreach (Spelers obj in spelersInPut)
            {
                obj.inPut = false;
            }

            spelersInPut = new List<Spelers>();
        }
    }
}
