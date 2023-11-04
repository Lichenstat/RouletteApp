using RouletteApp.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RouletteApp.Controller
{
    public class RouletteStats : IRouletteStats
    {
        private List<RouletteCell> _history;

        public RouletteStats()
        {
            _history = new List<RouletteCell>();
        }

        public int LongestEvenStreak
        {
            get { return _LongestEvenStreak(); }
        }

        public int LongestOddStreak
        {
            get { return _LongestOddStreak(); }
        }

        public int LongestRedStreak
        {
            get { return _LongestRedStreak(); }
        }

        public int LongestBlackStreak 
        {
            get { return _LongestBlackStreak(); }
        }

        public int LongestZeroStreak
        {
            get { return _LongestZeroStreak(); }
        }

        public int OccurrenceOfZeros
        {
            get { return _OccurrenceOfZeros(); }
        }

        /*
        public int OverallMoneyGained
        {
            get { }
        }

        public int OverallMoneyLost
        {
            get { }
        }
        */

        public void AddCellToHistory(RouletteCell cell)
        {
            _history.Add(cell);
        }

        private int _LongestEvenStreak()
        {
            int streak = 0;
            int tempStreak = 0;

            foreach(RouletteCell cell in _history)
            {
                if (cell.IsEven)
                {
                    tempStreak = tempStreak + 1;
                }

                if (!cell.IsEven)
                {
                    if (tempStreak > streak) 
                    {
                        streak = tempStreak;
                    }
                    tempStreak = 0;
                }
            }

            return streak;
        }

        private int _LongestOddStreak()
        {
            int streak = 0;
            int tempStreak = 0;

            foreach (RouletteCell cell in _history)
            {
                if (cell.IsOdd)
                {
                    tempStreak = tempStreak + 1;
                }

                if (!cell.IsOdd)
                {
                    if (tempStreak > streak)
                    {
                        streak = tempStreak;
                    }
                    tempStreak = 0;
                }
            }

            return streak;
        }

        private int _LongestRedStreak()
        {
            int streak = 0;
            int tempStreak = 0;

            foreach (RouletteCell cell in _history)
            {
                if (cell.IsRed)
                {
                    tempStreak = tempStreak + 1;
                }

                if (!cell.IsRed)
                {
                    if (tempStreak > streak)
                    {
                        streak = tempStreak;
                    }
                    tempStreak = 0;
                }
            }

            return streak;
        }

        private int _LongestBlackStreak()
        {
            int streak = 0;
            int tempStreak = 0;

            foreach (RouletteCell cell in _history)
            {
                if (cell.IsBlack)
                {
                    tempStreak = tempStreak + 1;
                }

                if (!cell.IsBlack)
                {
                    if (tempStreak > streak)
                    {
                        streak = tempStreak;
                    }
                    tempStreak = 0;
                }
            }

            return streak;
        }

        private int _LongestZeroStreak()
        {
            int streak = 0;
            int tempStreak = 0;

            foreach (RouletteCell cell in _history)
            {
                if (cell.IsZero)
                {
                    tempStreak = tempStreak + 1;
                }

                if (!cell.IsZero)
                {
                    if (tempStreak > streak)
                    {
                        streak = tempStreak;
                    }
                    tempStreak = 0;
                }
            }

            return streak;
        }

        private int _OccurrenceOfZeros()
        {
            int streak = 0;

            foreach(RouletteCell cell in _history)
            {
                if (cell.IsZero)
                {
                    streak = streak + 1;
                }
            }

            return streak;
        }
    }
}
