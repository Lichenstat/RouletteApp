using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RouletteApp.Model
{
    internal interface IRouletteTable
    {
        // get an outcome after spinning the roulette table
        RouletteCell SpinResult { get; }
        // spin the roulette wheel to get a cell for checking
        void SpinWheel();
    }
}
