using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RouletteApp.Model
{
    public class RouletteTable : IRouletteTable
    {
        private readonly List<RouletteCell> _tableCells;
        private RouletteCell _spinResult;

        // classic american roulette table
        public RouletteTable()
        {
            _tableCells = new List<RouletteCell>();
            _tableCells.Add(new RouletteCell("0", "None"));
            _tableCells.Add(new RouletteCell("00", "None"));
            _tableCells.Add(new RouletteCell("1", "Red"));
            _tableCells.Add(new RouletteCell("2", "Black"));
            _tableCells.Add(new RouletteCell("3", "Red"));
            _tableCells.Add(new RouletteCell("4", "Black"));
            _tableCells.Add(new RouletteCell("5", "Red"));
            _tableCells.Add(new RouletteCell("6", "Black"));
            _tableCells.Add(new RouletteCell("7", "Red"));
            _tableCells.Add(new RouletteCell("8", "Black"));
            _tableCells.Add(new RouletteCell("9", "Red"));
            _tableCells.Add(new RouletteCell("10", "Black"));
            _tableCells.Add(new RouletteCell("11", "Black"));
            _tableCells.Add(new RouletteCell("12", "Red"));
            _tableCells.Add(new RouletteCell("13", "Black"));
            _tableCells.Add(new RouletteCell("14", "Red"));
            _tableCells.Add(new RouletteCell("15", "Black"));
            _tableCells.Add(new RouletteCell("16", "Red"));
            _tableCells.Add(new RouletteCell("17", "Black"));
            _tableCells.Add(new RouletteCell("18", "Red"));
            _tableCells.Add(new RouletteCell("19", "Red"));
            _tableCells.Add(new RouletteCell("20", "Black"));
            _tableCells.Add(new RouletteCell("21", "Red"));
            _tableCells.Add(new RouletteCell("22", "Black"));
            _tableCells.Add(new RouletteCell("23", "Red"));
            _tableCells.Add(new RouletteCell("24", "Black"));
            _tableCells.Add(new RouletteCell("25", "Red"));
            _tableCells.Add(new RouletteCell("26", "Black"));
            _tableCells.Add(new RouletteCell("27", "Red"));
            _tableCells.Add(new RouletteCell("28", "Black"));
            _tableCells.Add(new RouletteCell("29", "Black"));
            _tableCells.Add(new RouletteCell("30", "Red"));
            _tableCells.Add(new RouletteCell("31", "Black"));
            _tableCells.Add(new RouletteCell("32", "Red"));
            _tableCells.Add(new RouletteCell("33", "Black"));
            _tableCells.Add(new RouletteCell("34", "Red"));
            _tableCells.Add(new RouletteCell("35", "Black"));
            _tableCells.Add(new RouletteCell("36", "Red"));

            //PrintCells();
            SpinWheel();
        }

        // custom roulette table using a uniquely created roulette table
        public RouletteTable(List<RouletteCell> tableCells)
        {
            _tableCells = tableCells;
        }

        // print all cells of the created table
        private void PrintCells()
        {
            foreach (var cell in _tableCells)
            {
                Console.WriteLine("Cell Id:     " + cell.Id);
                Console.WriteLine("Cell Number: " + cell.Number);
                Console.WriteLine("Cell Color:  " + cell.Color);
                Console.WriteLine("Cell Zero:   " + cell.IsZero);
                Console.WriteLine("Cell Even:   " + cell.IsEven);
                Console.WriteLine("Cell Odd:    " + cell.IsOdd);
                Console.WriteLine("Cell Red:    " + cell.IsRed);
                Console.WriteLine("Cell Black:  " + cell.IsBlack);
                Console.WriteLine("- - - - - - -");

            }
        }

        public RouletteCell SpinResult
        {
            get { return _spinResult; }
        }

        // spin the roulette wheel to get a random cell
        public void SpinWheel()
        {
            _spinResult = RouletteWheel.SpinRandomCell(_tableCells);
        }

    }
}
