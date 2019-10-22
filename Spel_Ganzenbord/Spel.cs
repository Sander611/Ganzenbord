using System;
using System.Collections.Generic;
using System.Text;

namespace Spel_Ganzenbord
{
    class Spel
    {
        public event updateMessageDelegate updateMessage;
        public event readMessageDelegate readMessage;
        public event waitForKeyMessageDelegate waitForKey;

        public List<Spelers> spelerLijst = new List<Spelers>();
        public List<Spelers> spelersInPut = new List<Spelers>();

        public Spelbord spelbord = new Spelbord();
        public Dobbelsteen dobbelsteen = new Dobbelsteen();

        public bool winnaarBekend = false;

        public void SpelersMaken(int aantalSpelers)
        {

            for (int x = 1; x <= aantalSpelers; x++)
            {
                updateMessage("Voer een Naam in: ");
                string naam = readMessage();
                Spelers SpelerInstance = new Spelers(naam);
                spelerLijst.Add(SpelerInstance);
            }
        }



        public void SpelStarten()
        {
            while (winnaarBekend == false)
            {
                foreach (Spelers speler in spelerLijst)
                {
                    if (speler.inPut == false && speler.beurtenOverslaan.Count == 0){

                        updateMessage("Speler " + Convert.ToString(speler.Naam) + " is aan zet. En staat momenteel op vakje: " + Convert.ToString(speler.Positie) + ".");

                        int gegooideWaarde = dobbelsteen.dobbelen();
                        speler.stappenZetten(gegooideWaarde);

                        updateMessage("Speler " + Convert.ToString(speler.Naam) + " gooide " + gegooideWaarde + " en is hiermee beland op vakje " + Convert.ToString(speler.Positie) + ".");
                        updateMessage(spelbord.checkSpel(speler, gegooideWaarde, ref winnaarBekend, ref spelersInPut));

                        if (spelersInPut.Count > 1)
                        {
                            SpelersVerwijderen();
                        }
                        if (winnaarBekend == true) 
                        {
                            break;
                        }

                        updateMessage("Druk ergens op om je beurt te eindigen");
                        updateMessage(" ");
                        waitForKey();
                    }

                    else{
                        if (speler.inPut){

                            updateMessage("Speler "+ Convert.ToString(speler.Naam) +" bevindt zich in de put en moet wachten op een andere speler tot hij/zij gevonden wordt!");
                            updateMessage(" ");

                            continue;
                        }
                        else {
                            List<string> currBeurtenOverslaan = speler.beurtenOverslaan;

                            updateMessage("Speler " + Convert.ToString(speler.Naam) + " moet nog "+ currBeurtenOverslaan.Count +" beurt wachten!");
                            updateMessage(" ");

                            currBeurtenOverslaan.RemoveAt(currBeurtenOverslaan.Count - 1);
                            speler.beurtenOverslaan = currBeurtenOverslaan;
                            continue;
                        }
                    
                    }
                }

            }


        }

        public void SpelersVerwijderen()
        {
            foreach (Spelers obj in spelersInPut)
            {
                obj.inPut = false;
            }

            spelersInPut = new List<Spelers>();
        }
    }
}
