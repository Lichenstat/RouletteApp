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

        List<RouletteCell> History {  get; }

        int LongestEvenStreak { get; }

        //int FilteredEvenStreak { get; }

        int LongestOddStreak { get; }

        //int FilteredOddStreak { get; }

        int LongestRedStreak { get; }

        //int FilteredRedStreak { get; }

        int LongestBlackStreak { get; }

        //int FilteredBlackStreak { get; }

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
