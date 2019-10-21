using System;
using System.Collections.Generic;
using System.Text;

namespace Spel_Ganzenbord
{
    class Dobbelsteen
    {
        public int dobbelen()
        {
            Random rnd = new Random();
            int gegooideStappen = rnd.Next(1, 7);
            return gegooideStappen;
        }
    }
}
