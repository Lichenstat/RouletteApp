using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RouletteApp.Model
{
    public class RouletteCell : IRouletteCell
    {
        // fields to use 
        private readonly int _id;
        private readonly string _number;
        private readonly string _color;
        private readonly bool _red;
        private readonly bool _black;
        private readonly bool _zero;
        private readonly bool _even;
        private readonly bool _odd;

        // singleton instance of cells Memory for tracking ids
        private RouletteCellsMemory _cellsMemory = RouletteCellsMemory.Instance;

        public RouletteCell(string number, string color)
        {
            _id = _cellsMemory.GetNewId();
            _number = number;
            _color = color;

            _red = (_color == "Red" ||  _color == "red");
            _black = (_color == "Black" || _color == "black");

            var n = int.Parse(number);

            _zero = CheckIfZeros(n);

            if (!_zero)
            {
                n = n % 2;

                if (n == 0)
                {
                    _even = true;
                    _odd = false;
                }

                if (n == 1)
                {
                    _even = false;
                    _odd = true;
                }
            }
        }

        public int Id
        {
            get { return _id; }
        }

        public string Number
        {
            get { return _number; }
        }

        public string Color
        {
            get { return _color; }
        }

        public bool IsRed
        {
            get { return _red; }
        }

        public bool IsBlack
        {
            get { return _black; }
        }

        public bool IsZero
        {
            get { return _zero; }
        }

        public bool IsEven
        {
            get { return _even; }
        }

        public bool IsOdd
        {
            get { return _odd; }
        }

        // get a new cell id
        private int GetNewCellId()
        {
            return _cellsMemory.GetNewId();
        }

        // check if the number is not 0 or 00 (or any other forms of multiple zeros)
        private bool CheckIfZeros(int number)
        {
            if (number == 0) return true;

            return false;
        }

    }
}
