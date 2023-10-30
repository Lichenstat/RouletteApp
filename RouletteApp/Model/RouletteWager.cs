using RouletteApp.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RouletteApp.Model
{
    public class RouletteWager : IRouletteWager
    {
        //private List<Action> _wagerQueue;

        public RouletteWager()
        {
            //_wagerQueue = new List<Action>();
        }

        public int SingleNumber(RouletteCell cell, string number, int money)
        {
            if (cell.Number == number)
            {
                return money * 36;
            }

            return 0;
        }

        public int OneToTwelve(RouletteCell cell, int money)
        {
            int[] grouping = Enumerable.Range(1, 12).ToArray();
            int number = int.Parse(cell.Number);

            if (grouping.Contains(number))
            {
                return money * 3;
            }

            return 0;
        }
        
        public int ThirteenToTwentyfour(RouletteCell cell, int money)
        {
            int[] grouping = Enumerable.Range(13, 24).ToArray();
            int number = int.Parse(cell.Number);

            if (grouping.Contains(number))
            {
                return money * 3;
            }

            return 0;
        }

        public int TwentyfiveToThirtysix(RouletteCell cell, int money)
        {
            int[] grouping = Enumerable.Range(25, 36).ToArray();
            int number = int.Parse(cell.Number);

            if (grouping.Contains(number))
            {
                return money * 3;
            }

            return 0;
        }

        public int OneToEighteen(RouletteCell cell, int money)
        {
            int[] grouping = Enumerable.Range(1, 18).ToArray();
            int number = int.Parse(cell.Number);

            if (grouping.Contains(number))
            {
                return money * 2;
            }

            return 0;
        }

        public int NineteenToThirtysix(RouletteCell cell, int money)
        {
            int[] grouping = Enumerable.Range(19, 36).ToArray();
            int number = int.Parse(cell.Number);

            if (grouping.Contains(number))
            {
                return money * 2;
            }

            return 0;
        }

        public int FirstRow(RouletteCell cell, int money)
        {
            int[] grouping = { 1, 4, 7, 10, 13, 16, 19, 22, 25, 28, 31, 34 };
            int number = int.Parse(cell.Number);

            if (grouping.Contains(number))
            {
                return money * 3;
            }

            return 0;
        }

        public int SecondRow(RouletteCell cell, int money)
        {
            int[] grouping = { 2, 5, 8, 11, 14, 17, 20, 23, 26, 29, 32, 35 };
            int number = int.Parse(cell.Number);

            if (grouping.Contains(number))
            {
                return money * 3;
            }

            return 0;
        }

        public int ThirdRow(RouletteCell cell, int money)
        {
            int[] grouping = { 3, 6, 9, 12, 15, 18, 21, 24, 27, 30, 33, 36 };
            int number = int.Parse(cell.Number);

            if (grouping.Contains(number))
            {
                return money * 3;
            }

            return 0;
        }

        public int EvenNumber(RouletteCell cell, int money)
        {
            if (cell.IsEven)
            {
                return money * 2;
            }

            return 0;
        }

        public int OddNumber(RouletteCell cell, int money)
        {
            if (cell.IsOdd)
            {
                return money * 2;
            }

            return 0;
        }

        public int Red(RouletteCell cell, int money)
        {
            if (cell.IsRed)
            {
                return money * 2;
            }

            return 0;
        }

        public int Black(RouletteCell cell, int money)
        {
            if (cell.IsBlack)
            {
                return money * 2;
            }

            return 0;
        }
    }
}
