using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RouletteApp.model
{
    internal interface IRouletteCellsMemory
    {
        // get new id number that hasn't existed
        int GetNewId();
    }
}
