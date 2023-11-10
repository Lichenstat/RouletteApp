using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RouletteApp.Model
{
    internal interface IRouletteWager
    {
        // NOTE - For now this implementation lacks the ability to wager by splitting amongst cells (half to one, quarter to one).
        //        No 17-1 (split), 11-1 (street), 8-1 (corner), 5-1(six-line)
        //        Yes 35-1 (straight), 2-1 (column *labeled as row*), 2-1 (dozen), 1-1 (ood/even, red/black, 1 to 18 & 19 to 36)
        //        Currently wagering is only done in groups or individual cells (odds, reds, 32, 00, etc.)

        // get or set a current cell of the wager
        RouletteCell CurrentCell { get; set; }

        // total wagered money
        int WageredMoneyTotal { get; }

        // total returned from wager
        int WageredReturnedTotal { get; }
        
        // round wagered money
        int WageredMoneyOfRound { get; }

        // round returned money from wager
        int WageredReturnedOfRound { get; }

        // get overall wagers outcomes
        int WagersOverallProfit { get; }

        // get the rounds wagered outcome
        int WagersRoundProfit { get; }

        // get the wager history
        List<List<Action>> WagerHistory { get; }

        // reset the overall wagered stats
        void ResetOverallWageredStats();

        // reset the round wagered stats
        //void ResetRoundWageredStats();

        // run all the wagers made by the player
        void RunAllWagers();

        // inside bets below

        // single cell wager (1, 00, 27, etc.)
        void Straight(RouletteCell cell, string number, int money);

        // split (2 cells, by each other (1 ,2), (2,3), (4,7))
        void Split(RouletteCell cell, (string number1, string number2) numbers, int money);

        // street (3 cells, in column group (4, 5, 6), (10, 11, 12))
        void Street(RouletteCell cell, (string number1, string number2, string number3) numbers, int money);

        // corner (4 cells, in squre (1, 2, 4, 5), (16, 17, 19, 20))
        void Corner(RouletteCell cell, (string number1, string number2, string number3, string number4) numbers, int money);

        // six-line (2 streets by one another (1, 2, 3, 4, 5, 6), (25, 26, 27, 28, 29, 30))
        void SixLine(RouletteCell cell, (string number1, string number2, string number3, string number4, string number5, string number6) numbers, int money);

        // outside bets below

        // one of 3 grouping of numbers wager (1-12, 13-24, 25-36)
        void OneToTwelve(RouletteCell cell, int money);
        void ThirteenToTwentyfour(RouletteCell cell, int money);
        void TwentyfiveToThirtysix(RouletteCell cell, int money);

        // one of two grouping of numbers wager (1-18, 19-36)
        void OneToEighteen(RouletteCell cell, int money);
        void NineteenToThirtysix(RouletteCell cell, int money);

        // first, second, and third row wagers (first row has intervals of 1,4,7..., second has intervals of 2,5,8..., third has intervals of 3,6,9...)
        void FirstRow(RouletteCell cell, int money);
        void SecondRow(RouletteCell cell, int money);
        void ThirdRow(RouletteCell cell, int money);

        // even and odd numbers wager
        void Even(RouletteCell cell, int money);
        void Odd(RouletteCell cell, int money);

        // red and black wagers
        void Red(RouletteCell cell, int money);
        void Black(RouletteCell cell, int money);
    }
}
