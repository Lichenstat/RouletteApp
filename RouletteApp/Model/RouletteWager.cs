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

        public List<List<Action>> WagerHistory
        {
            get { return _wagerHistory; }
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

            _wagerHistory.Add(new List<Action>(_wagerQueue));

            foreach(Action action in _wagerQueue)
            {
                action();
            }

            _wagerQueue.Clear();
        }

        // --- Straight
        public void Straight(string number, int money)
        {
            _wagerQueue.Add(() => _Straight(_currentCell, number, money));
        }

        public void Straight(RouletteCell cell, string number, int money)
        {
            _wagerQueue.Add(() => _Straight(cell, number, money));
        }

        private void _Straight(RouletteCell cell, string number, int money)
        {
            SumWageredMoney(money);

            if (cell.Number == number)
            {
                var gain = money * 36;

                SumWageredProfit(gain);
            }
        }

        // --- Split
        public void Split((string number1, string number2) numbers, int money)
        {
            _wagerQueue.Add(() => _Split(_currentCell, numbers, money));
        }

        public void Split(RouletteCell cell, (string number1, string number2) numbers, int money)
        {
            _wagerQueue.Add(() => _Split(cell, numbers, money));
        }
        
        private void _Split(RouletteCell cell, (string number1, string number2) numbers, int money)
        {
            SumWageredMoney(money);

            if (cell.Number == numbers.number1 || 
                cell.Number == numbers.number2)
            {
                var gain = money * 18;

                SumWageredProfit(gain);
            }
        }

        // --- Street
        public void Street((string number1, string number2, string number3) numbers, int money)
        {
            _wagerQueue.Add(() => _Street(_currentCell, numbers, money));
        }

        public void Street(RouletteCell cell, (string number1, string number2, string number3) numbers, int money)
        {
            _wagerQueue.Add(() => _Street(cell, numbers, money));
        }

        private void _Street(RouletteCell cell, (string number1, string number2, string number3) numbers, int money)
        {
            SumWageredMoney(money);

            if (cell.Number == numbers.number1 || 
                cell.Number == numbers.number2 || 
                cell.Number == numbers.number3)
            {
                var gain = money * 12;

                SumWageredProfit(gain);
            }
        }

        // --- Corner
        public void Corner((string number1, string number2, string number3, string number4) numbers, int money)
        {
            _wagerQueue.Add(() => _Corner(_currentCell, numbers, money));
        }

        public void Corner(RouletteCell cell, (string number1, string number2, string number3, string number4) numbers, int money)
        {
            _wagerQueue.Add(() => _Corner(cell, numbers, money));
        }

        private void _Corner(RouletteCell cell, (string number1, string number2, string number3, string number4) numbers, int money)
        {
            SumWageredMoney(money);

            if (cell.Number == numbers.number1 || 
                cell.Number == numbers.number2 || 
                cell.Number == numbers.number3 || 
                cell.Number == numbers.number4)
            {
                var gain = money * 9;

                SumWageredProfit(gain);
            }
        }

        // --- Six Line
        public void SixLine((string number1, string number2, string number3, string number4, string number5, string number6) numbers, int money)
        {
            _wagerQueue.Add(() => _SixLine(_currentCell, numbers, money));
        }

        public void SixLine(RouletteCell cell, (string number1, string number2, string number3, string number4, string number5, string number6) numbers, int money)
        {
            _wagerQueue.Add(() => _SixLine(cell, numbers, money));
        }

        private void _SixLine(RouletteCell cell, (string number1, string number2, string number3, string number4, string number5, string number6) numbers, int money)
        {
            SumWageredMoney(money);

            if (cell.Number == numbers.number1 || 
                cell.Number == numbers.number2 || 
                cell.Number == numbers.number3 || 
                cell.Number == numbers.number4 || 
                cell.Number == numbers.number5 || 
                cell.Number == numbers.number6)
            {
                var gain = money * 6;

                SumWageredProfit(gain);
            }
        }

        // --- One To Twelve
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

        // --- Thirteen To Twentyfour
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
            int[] grouping = Enumerable.Range(13, 12).ToArray();
            int number = int.Parse(cell.Number);

            SumWageredMoney(money);

            if (grouping.Contains(number))
            {
                var gain = money * 3;

                SumWageredProfit(gain);
            }
        }

        // --- Twentyfive To Thirtysix
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
            int[] grouping = Enumerable.Range(25, 12).ToArray();
            int number = int.Parse(cell.Number);

            SumWageredMoney(money);

            if (grouping.Contains(number))
            {
                var gain = money * 3;

                SumWageredProfit(gain);
            }
        }

        // --- One To Eighteen
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

        // --- Ninteen To Thirtysix
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
            int[] grouping = Enumerable.Range(19, 18).ToArray();
            int number = int.Parse(cell.Number);

            SumWageredMoney(money);

            if (grouping.Contains(number))
            {
                var gain = money * 2;

                SumWageredProfit(gain);
            }
        }

        // --- First Row
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

        // --- Second Row
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

        // --- Third Row
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

        // --- Even Number
        public void Even(int money)
        {
            _wagerQueue.Add(() => _Even(_currentCell, money));
        }

        public void Even(RouletteCell cell, int money)
        {
            _wagerQueue.Add(() => _Even(cell, money));
        }

        private void _Even(RouletteCell cell, int money)
        {
            SumWageredMoney(money);

            if (cell.IsEven)
            {
                var gain = money * 2;

                SumWageredProfit(gain);
            }
        }

        // --- Odd Number
        public void Odd(int money)
        {
            _wagerQueue.Add(() => _Odd(_currentCell, money));
        }

        public void Odd(RouletteCell cell, int money)
        {
            _wagerQueue.Add(() => _Odd(cell, money));
        }

        private void _Odd(RouletteCell cell, int money)
        {
            SumWageredMoney(money);

            if (cell.IsOdd)
            {
                var gain = money * 2;

                SumWageredProfit(gain);
            }
        }

        // --- Red Color
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

        // --- Black Color
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
