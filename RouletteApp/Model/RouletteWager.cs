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
        private List<Action> _wagerQueue;
        private List<List<Action>> _wagerHistory;

        private RouletteCell _currentCell;

        private int _wageredMoneyTotal;
        private int _wageredReturnTotal;

        private int _wageredMoneyOfRound;
        private int _wageredReturnOfRound;
        
        public RouletteWager()
        {
            _wagerQueue = new List<Action>();
            _wagerHistory = new List<List<Action>>();

            _currentCell = new RouletteCell("-1", "Green");

            _wageredMoneyTotal = 0;
            _wageredReturnTotal = 0;

            _wageredMoneyOfRound = 0;
            _wageredReturnOfRound = 0;
        }

        public RouletteCell CurrentCell { 
            get { return _currentCell; } 
            set { _currentCell = value; }
        }

        public int WageredMoneyTotal
        {
            get { return _wageredMoneyTotal; }
        }

        public int WageredReturnedTotal
        { 
            get { return _wageredReturnTotal; }
        }

        public int WageredMoneyOfRound
        {
            get { return _wageredMoneyOfRound; }
        }

        public int WageredReturnedOfRound
        {
            get { return _wageredReturnOfRound; }
        }

        public int WagersOverallProfit
        {
            get { return _wageredReturnTotal - _wageredMoneyTotal; } 
        }

        public int WagersRoundProfit
        {
            get { return _wageredReturnOfRound - _wageredMoneyOfRound; }
        }

        // reset all stats
        public void ResetOverallWageredStats()
        {
            _wageredMoneyTotal = 0;
            _wageredReturnTotal = 0;

            ResetRoundWageredStats();
        }

        // reset the rounds stats
        private void ResetRoundWageredStats()
        {
            _wageredMoneyOfRound = 0;
            _wageredReturnOfRound = 0;
        }

        private void SumWageredMoney(int money)
        {
            _wageredMoneyTotal = _wageredMoneyTotal + money;

            _wageredMoneyOfRound = _wageredMoneyOfRound + money;
        }

        private void SumWageredProfit(int money)
        {
            _wageredReturnTotal = _wageredReturnTotal + money;

            _wageredReturnOfRound = _wageredReturnOfRound + money;
        }

        // run all the wagers and 
        public void RunAllWagers()
        {
            ResetRoundWageredStats();

            _wagerHistory.Add(_wagerQueue);

            foreach(Action action in _wagerQueue)
            {
                action();
            }

            _wagerQueue.Clear();
        }

        public void SingleNumber(string number, int money)
        {
            _wagerQueue.Add(() => _SingleNumber(_currentCell, number, money));
        }

        public void SingleNumber(RouletteCell cell, string number, int money)
        {
            _wagerQueue.Add(() => _SingleNumber(cell, number, money));
        }
        
        private void _SingleNumber(RouletteCell cell, string number, int money)
        {
            SumWageredMoney(money);

            if (cell.Number == number)
            {
                var gain = money * 36;

                SumWageredProfit(gain);
            }
        }

        public void OneToTwelve(int money)
        {
            _wagerQueue.Add(() => _OneToTwelve(_currentCell, money));
        }

        public void OneToTwelve(RouletteCell cell, int money)
        {
            _wagerQueue.Add(() => _OneToTwelve(cell, money));
        }

        private void _OneToTwelve(RouletteCell cell, int money)
        {
            int[] grouping = Enumerable.Range(1, 12).ToArray();
            int number = int.Parse(cell.Number);

            SumWageredMoney(money);

            if (grouping.Contains(number))
            {
                var gain = money * 3;

                SumWageredProfit(gain);
            }
        }

        public void ThirteenToTwentyfour(int money)
        {
            _wagerQueue.Add(() => _ThirteenToTwentyfour(_currentCell, money));
        }

        public void ThirteenToTwentyfour(RouletteCell cell, int money)
        {
            _wagerQueue.Add(() => _ThirteenToTwentyfour(cell, money));
        }

        private void _ThirteenToTwentyfour(RouletteCell cell, int money)
        {
            int[] grouping = Enumerable.Range(13, 24).ToArray();
            int number = int.Parse(cell.Number);

            SumWageredMoney(money);

            if (grouping.Contains(number))
            {
                var gain = money * 3;

                SumWageredProfit(gain);
            }
        }

        public void TwentyfiveToThirtysix(int money)
        {
            _wagerQueue.Add(() => _TwentyfiveToThirtysix(_currentCell, money));
        }

        public void TwentyfiveToThirtysix(RouletteCell cell, int money)
        {
            _wagerQueue.Add(() => _TwentyfiveToThirtysix(cell, money));
        }

        private void _TwentyfiveToThirtysix(RouletteCell cell, int money)
        {
            int[] grouping = Enumerable.Range(25, 36).ToArray();
            int number = int.Parse(cell.Number);

            SumWageredMoney(money);

            if (grouping.Contains(number))
            {
                var gain = money * 3;

                SumWageredProfit(gain);
            }
        }

        public void OneToEighteen(int money)
        {
            _wagerQueue.Add(() => _OneToEighteen(_currentCell, money));
        }

        public void OneToEighteen(RouletteCell cell, int money)
        {
            _wagerQueue.Add(() => _OneToEighteen(cell, money));
        }

        private void _OneToEighteen(RouletteCell cell, int money)
        {
            int[] grouping = Enumerable.Range(1, 18).ToArray();
            int number = int.Parse(cell.Number);

            SumWageredMoney(money);

            if (grouping.Contains(number))
            {
                var gain = money * 2;

                SumWageredProfit(gain);
            }
        }

        public void NineteenToThirtysix(int money)
        {
            _wagerQueue.Add(() => _NineteenToThirtysix(_currentCell, money));
        }

        public void NineteenToThirtysix(RouletteCell cell, int money)
        {
            _wagerQueue.Add(() => _NineteenToThirtysix(cell, money));
        }

        private void _NineteenToThirtysix(RouletteCell cell, int money)
        {
            int[] grouping = Enumerable.Range(19, 36).ToArray();
            int number = int.Parse(cell.Number);

            SumWageredMoney(money);

            if (grouping.Contains(number))
            {
                var gain = money * 2;

                SumWageredProfit(gain);
            }
        }

        public void FirstRow(int money)
        {
            _wagerQueue.Add(() => _FirstRow(_currentCell, money));
        }

        public void FirstRow(RouletteCell cell, int money)
        {
            _wagerQueue.Add(() => _FirstRow(cell, money));
        }

        private void _FirstRow(RouletteCell cell, int money)
        {
            int[] grouping = { 1, 4, 7, 10, 13, 16, 19, 22, 25, 28, 31, 34 };
            int number = int.Parse(cell.Number);

            SumWageredMoney(money);

            if (grouping.Contains(number))
            {
                var gain = money * 3;

                SumWageredProfit(gain);
            }
        }

        public void SecondRow(int money)
        {
            _wagerQueue.Add(() => _SecondRow(_currentCell, money));
        }

        public void SecondRow(RouletteCell cell, int money)
        {
            _wagerQueue.Add(() => _SecondRow(cell, money));
        }

        private void _SecondRow(RouletteCell cell, int money)
        {
            int[] grouping = { 2, 5, 8, 11, 14, 17, 20, 23, 26, 29, 32, 35 };
            int number = int.Parse(cell.Number);

            SumWageredMoney(money);

            if (grouping.Contains(number))
            {
                var gain = money * 3;

                SumWageredProfit(gain);
            }
        }

        public void ThirdRow(int money)
        {
            _wagerQueue.Add(() => _ThirdRow(_currentCell, money));
        }

        public void ThirdRow(RouletteCell cell, int money)
        {
            _wagerQueue.Add(() => _ThirdRow(cell, money));
        }

        private void _ThirdRow(RouletteCell cell, int money)
        {
            int[] grouping = { 3, 6, 9, 12, 15, 18, 21, 24, 27, 30, 33, 36 };
            int number = int.Parse(cell.Number);

            SumWageredMoney(money);

            if (grouping.Contains(number))
            {
                var gain = money * 3;

                SumWageredProfit(gain);
            }
        }

        public void EvenNumber(int money)
        {
            _wagerQueue.Add(() => _EvenNumber(_currentCell, money));
        }

        public void EvenNumber(RouletteCell cell, int money)
        {
            _wagerQueue.Add(() => _EvenNumber(cell, money));
        }

        private void _EvenNumber(RouletteCell cell, int money)
        {
            SumWageredMoney(money);

            if (cell.IsEven)
            {
                var gain = money * 2;

                SumWageredProfit(gain);
            }
        }

        public void OddNumber(int money)
        {
            _wagerQueue.Add(() => _OddNumber(_currentCell, money));
        }

        public void OddNumber(RouletteCell cell, int money)
        {
            _wagerQueue.Add(() => _OddNumber(cell, money));
        }

        private void _OddNumber(RouletteCell cell, int money)
        {
            SumWageredMoney(money);

            if (cell.IsOdd)
            {
                var gain = money * 2;

                SumWageredProfit(gain);
            }
        }

        public void Red(int money)
        {
            _wagerQueue.Add(() => _Red(_currentCell, money));
        }

        public void Red(RouletteCell cell, int money)
        {
            _wagerQueue.Add(() => _Red(cell, money));
        }

        private void _Red(RouletteCell cell, int money)
        {
            SumWageredMoney(money);

            if (cell.IsRed)
            {
                var gain = money * 2;

                SumWageredProfit(gain);
            }
        }

        public void Black(int money)
        {
            _wagerQueue.Add(() => _Black(_currentCell, money));
        }

        public void Black(RouletteCell cell, int money)
        {
            _wagerQueue.Add(() => _Black(cell, money));
        }

        private void _Black(RouletteCell cell, int money)
        {
            SumWageredMoney(money);

            if (cell.IsBlack)
            {
                var gain = money * 2;

                SumWageredProfit(gain);
            }
        }
    }
}
