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
            var maxIndex = rouletteCells.Count;
            var randomIndex = RandomNumberGenerator.GetInt32(maxIndex);
            //var randomIndex = new Random().Next(maxIndex);

            return rouletteCells[randomIndex];
        }
    }
}
