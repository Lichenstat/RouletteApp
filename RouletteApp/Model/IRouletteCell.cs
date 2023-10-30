using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RouletteApp.Model
{
    internal interface IRouletteCell
    {
        // set and get a cells id
        //void SetCellId();
        int Id { get; }

        // set and get a cells number
        //void SetCellNumber(string cellNumber);
        string Number { get; }

        // set and get a cells color
        //void SetCellColor(string cellColor);
        string Color { get; }

        // check if the cell is red or back
        bool IsRed { get; }
        bool IsBlack { get; }

        // get if cell is a zero or not
        bool IsZero { get; }

        // set and get if the cell is even
        //void SetCellEven(string cellNumber);
        bool IsEven { get; }

        // set and get if the cell is odd
        //void SetCellOdd(string cellNumber);
        bool IsOdd { get; }
    }
}
