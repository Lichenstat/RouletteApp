using RouletteApp.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RouletteApp.Controller
{
    internal interface IRouletteLogic
    {
        // roll for a certain roulette cell
        void SpinAndBet();

    }
}
