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

        public List<RouletteCell> History { 
            get { return _history; } 
        }

        public int LongestEvenStreak
        {
            get { return _LongestEvenStreak(); }
        }
        /*
        public int FilteredEvenStreak
        {
            get { return _EvenStreaks(); }
        }
        */
        public int LongestOddStreak
        {
            get { return _LongestOddStreak(); }
        }
        /*
        public int FilteredOddStreak
        {
            get { return _AverageOddStreak(); }
        }
        */
        public int LongestRedStreak
        {
            get { return _LongestRedStreak(); }
        }
        /*
        public int FilteredRedStreak
        {
            get { return _AverageRedStreak(); }
        }
        */
        public int LongestBlackStreak 
        {
            get { return _LongestBlackStreak(); }
        }
        /*
        public int FilteredBlackStreak
        {
            get { return _AverageBlackStreak(); }
        }
        */
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
                    tempStreak = 0;
                }

                if (tempStreak > streak)
                {
                    streak = tempStreak;
                }
            }

            return streak;
        }
        /*
        private int _EvenStreaks() // List<RouletteCell>
        {
            List<int> streak = new List<int>();
            int tempStreak = 0;

            foreach (RouletteCell cell in _history)
            {
                if (cell.IsEven)
                {
                    tempStreak = tempStreak + 1;
                }

                if (!cell.IsEven)
                {
                    streak.Add(tempStreak);
                    tempStreak = 0;
                }

            }

            // ISSUE WITH AVERAGES, THEY DO NOT APPLY DATA IF NEW DATA IS NOT SENT IN TO FINISH THE .Add ABOVE. FIX LATER

            var filteredStreak = streak.Where(s => s > 0);

            //if (filteredStreak.Count() > 0)
                //return (filteredStreak.Sum() / filteredStreak.Count());

            return 0;
        }
        */
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
                    tempStreak = 0;
                }

                if (tempStreak > streak)
                {
                    streak = tempStreak;
                }
            }

            return streak;
        }
        /*
        private int _AverageOddStreak()
        {
            List<int> streak = new List<int>();
            int tempStreak = 0;

            foreach (RouletteCell cell in _history)
            {
                if (cell.IsOdd)
                {
                    tempStreak = tempStreak + 1;
                }

                if (!cell.IsOdd)
                {
                    streak.Add(tempStreak);
                    tempStreak = 0;
                }

            }

            var filteredStreak = streak.Where(s => s > 0);

            if (filteredStreak.Count() > 0)
                return (filteredStreak.Sum() / filteredStreak.Count());

            return 0;
        }
        */
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
                    tempStreak = 0;
                }

                if (tempStreak > streak)
                {
                    streak = tempStreak;
                }
            }

            return streak;
        }
        /*
        private int _AverageRedStreak()
        {
            List<int> streak = new List<int>();
            int tempStreak = 0;

            foreach (RouletteCell cell in _history)
            {
                if (cell.IsRed)
                {
                    tempStreak = tempStreak + 1;
                }

                if (!cell.IsRed)
                {
                    streak.Add(tempStreak);
                    tempStreak = 0;
                }

            }

            var filteredStreak = streak.Where(s => s > 0);

            if (filteredStreak.Count() > 0)
                return (filteredStreak.Sum() / filteredStreak.Count());

            return 0;
        }
        */
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
                    tempStreak = 0;
                }

                if (tempStreak > streak)
                {
                    streak = tempStreak;
                }
            }

            return streak;
        }
        /*
        private int _AverageBlackStreak()
        {
            List<int> streak = new List<int>();
            int tempStreak = 0;

            foreach (RouletteCell cell in _history)
            {
                if (cell.IsBlack)
                {
                    tempStreak = tempStreak + 1;
                }

                if (!cell.IsBlack)
                {
                    streak.Add(tempStreak);
                    tempStreak = 0;
                }

            }

            var filteredStreak = streak.Where(s => s > 0);

            if (filteredStreak.Count() > 0)
                return (filteredStreak.Sum() / filteredStreak.Count());

            return 0;
        }
        */
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
                    tempStreak = 0;
                }

                if (tempStreak > streak)
                {
                    streak = tempStreak;
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
