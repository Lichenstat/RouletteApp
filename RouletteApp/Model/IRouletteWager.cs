﻿using System;
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

        // single cell wager (1, 00, etc.)
        int SingleNumber(RouletteCell cell, string number, int money);

        // one of 3 grouping of numbers wager (1-12, 13-24, 25-36)
        int OneToTwelve(RouletteCell cell, int money);
        int ThirteenToTwentyfour(RouletteCell cell, int money);
        int TwentyfiveToThirtysix(RouletteCell cell, int money);

        // one of two grouping of numbers wager (1-18, 19-36)
        int OneToEighteen(RouletteCell cell, int money);
        int NineteenToThirtysix(RouletteCell cell, int money);

        // first, second, and third row wagers (first row has intervals of 1,4,7..., second has intervals of 2,5,8..., third has intervals of 3,6,9...)
        int FirstRow(RouletteCell cell, int money);
        int SecondRow(RouletteCell cell, int money);
        int ThirdRow(RouletteCell cell, int money);

        // even and odd numbers wager
        int EvenNumber(RouletteCell cell, int money);
        int OddNumber(RouletteCell cell, int money);

        // red and black wagers
        int Red(RouletteCell cell, int money);
        int Black(RouletteCell cell, int money);
    }
}