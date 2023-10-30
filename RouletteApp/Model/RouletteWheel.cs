using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace RouletteApp.Model
{
    public static class RouletteWheel // : IRouletteWheel
    {
        /*
        private static int SpinRandomNumber(int min, int max)
        {
            return RandomNumberGenerator.GetInt32(min, max);
        }
        */

        public static RouletteCell SpinRandomCell(List<RouletteCell> rouletteCells)
        {
            var maxIndex = rouletteCells.Count - 1;
            var randomIndex = RandomNumberGenerator.GetInt32(0, maxIndex);

            return rouletteCells[randomIndex];
        }
    }
}
