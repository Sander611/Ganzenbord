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
            nieuwspel.updateMessage += update_Message;
            nieuwspel.waitForKey += wait_For_Key_Message;
            nieuwspel.readMessage += read_Message;

            update_Message("Hoeveel spelers doen er mee?: ");
            string AantalSpelers = read_Message();

            nieuwspel.SpelersMaken(int.Parse(AantalSpelers));

            nieuwspel.SpelStarten();

        }

        private static void update_Message(string message)
        {
            Console.WriteLine(message);
        }

        private static string read_Message()
        {
            return Console.ReadLine();
        }
        private static void wait_For_Key_Message()
        {
            Console.ReadKey();
        }

        


    }
}
