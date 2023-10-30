using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RouletteApp.Model
{
    internal interface IRouletteUsersMemory
    {
        // get a new id for a user
        int GetNewId();
    }
}
