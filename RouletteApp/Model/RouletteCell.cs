using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RouletteApp.model
{
    internal class RouletteCell : IRouletteCell
    {
        // fields to use 
        private readonly int _id;
        private readonly string _number;
        private readonly string _color;
        private readonly bool _zero;
        private readonly bool _even;
        private readonly bool _odd;

        // singleton instance of cells Memory for tracking ids
        private RouletteCellsMemory cellsMemory = RouletteCellsMemory.Instance;

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

        public RouletteCell(string number, string color)
        {
            _id = GetNewCellId();
            _number = number;
            _color = color;

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

        // get a new cell id
        private int GetNewCellId()
        {
            return cellsMemory.GetNewId();
        }

        // check if the number is not 0 or 00 (or any other forms of multiple zeros)
        private bool CheckIfZeros(int number)
        {
            if (number == 0) return true;

            return false;
        }

    }
}
