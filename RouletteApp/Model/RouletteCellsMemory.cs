using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RouletteApp.model
{
    public sealed class RouletteCellsMemory : IRouletteCellsMemory
    {
        // last cell id assigned to a cell on the roulette table
        private int _lastCellId;

        private RouletteCellsMemory()
        {
            _lastCellId = 0;
        }

        private static readonly Lazy<RouletteCellsMemory> lazy = new Lazy<RouletteCellsMemory>(() => new RouletteCellsMemory());

        public static RouletteCellsMemory Instance
        {
            get
            {
                return lazy.Value;
            }
        }

        public int GetNewId()
        {
            _lastCellId = _lastCellId + 1;
            return _lastCellId;
        }

    }
}
