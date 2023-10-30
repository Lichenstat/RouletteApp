using RouletteApp.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RouletteApp.Model
{
    internal interface IRouletteWheel
    {
        // choose a random number between min and max (0 .. 100) etc.
        //string SpinRandomNumber(int min, int max);

        // choose a random number given a list of cells 
        //static abstract string SpinRandomNumber(List<RouletteCell> cellsList);
    }
}
