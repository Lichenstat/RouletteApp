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

        private int _wageredMoneyTotal;
        private int _wageredProfitTotal;

        private int _wageredMoneyOfRound;
        private int _wageredProfitOfRound;
        
        public RouletteWager()
        {
            _wagerQueue = new List<Action>();

            _wageredMoneyTotal = 0;
            _wageredProfitTotal = 0;

            _wageredMoneyOfRound = 0;
            _wageredProfitOfRound = 0;
        }

        public int OverallWagersOutcome
        {
            get { return _wageredProfitTotal - _wageredMoneyTotal; } 
        }

        public int RoundWagersOutcome
        {
            get { return _wageredProfitOfRound - _wageredMoneyOfRound; }
        }

        // reset all stats
        public void ResetOverallWageredStats()
        {
            _wageredMoneyTotal = 0;
            _wageredProfitTotal = 0;

            ResetRoundWageredStats();
        }

        // reset the rounds stats
        private void ResetRoundWageredStats()
        {
            _wageredMoneyOfRound = 0;
            _wageredProfitOfRound = 0;

            //return null;
        }

        private void SumWageredMoney(int money)
        {
            _wageredMoneyTotal = _wageredMoneyTotal + money;

            _wageredMoneyOfRound = _wageredMoneyOfRound + money;
        }

        private void SumWageredProfit(int money)
        {
            _wageredProfitTotal = _wageredProfitTotal + money;

            _wageredProfitOfRound = _wageredProfitOfRound + money;
        }
        
        /*
        public void SingleNumber(RouletteCell cell, string number, int money)
        {
            _wagerQueue.Add(ResetRoundWageredStats());
            _wagerQueue.Add(SingleNumberA(cell, number, money));
        }
        */
        public void SingleNumber(RouletteCell cell, string number, int money)
        {
            SumWageredMoney(money);

            if (cell.Number == number)
            {
                var gain = money * 36;

                SumWageredProfit(gain);
            }

            //return null;
        }

        public void OneToTwelve(RouletteCell cell, int money)
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
        
        public void ThirteenToTwentyfour(RouletteCell cell, int money)
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

        public void TwentyfiveToThirtysix(RouletteCell cell, int money)
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

        public void OneToEighteen(RouletteCell cell, int money)
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

        public void NineteenToThirtysix(RouletteCell cell, int money)
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

        public void FirstRow(RouletteCell cell, int money)
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

        public void SecondRow(RouletteCell cell, int money)
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

        public void ThirdRow(RouletteCell cell, int money)
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

        public void EvenNumber(RouletteCell cell, int money)
        {
            SumWageredMoney(money);

            if (cell.IsEven)
            {
                var gain = money * 2;

                SumWageredProfit(gain);
            }
        }

        public void OddNumber(RouletteCell cell, int money)
        {
            SumWageredMoney(money);

            if (cell.IsOdd)
            {
                var gain = money * 2;

                SumWageredProfit(gain);
            }
        }

        public void Red(RouletteCell cell, int money)
        {
            SumWageredMoney(money);

            if (cell.IsRed)
            {
                var gain = money * 2;

                SumWageredProfit(gain);
            }
        }

        public void Black(RouletteCell cell, int money)
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
