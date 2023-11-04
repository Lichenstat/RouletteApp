using RouletteApp.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RouletteApp.Controller
{
    public interface IRouletteStats
    {
        void AddCellToHistory(RouletteCell cell);

        int LongestEvenStreak { get; }

        int LongestOddStreak { get; }

        int LongestRedStreak { get; }

        int LongestBlackStreak { get; }

        int LongestZeroStreak { get; }

        int OccurrenceOfZeros { get; }

        /*
        int LongestWinStreak { get; }

        int LongestLossStreak { get; }

        int OverallMoneyGained { get; }

        int OverallMoneyLost { get; }
        */

    }
}
