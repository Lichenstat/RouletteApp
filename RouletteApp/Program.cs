using RouletteApp.Controller;
using RouletteApp.Model;
using System.Linq;

namespace RouletteApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var RouletteLogic = new RouletteLogic();
            var bob = new RouletteUser("bob", 100);

            RouletteLogic.AddUserToGame(bob);

            var x = RouletteLogic.GetUsersWithWagers;

            while(bob.MoneyTotal > 0)
            {

                x[0].Item2.ThirdRow(10);
                x[0].Item2.Red(10);

                RouletteLogic.SpinAndCalculateWagers();

            }

            Console.WriteLine("Total rounds wagered: " + (x[0].Item2.WagerHistory.Where(l => l.Count > 0)).Count());
            Console.WriteLine("Wagered money total:  " + x[0].Item2.WageredMoneyTotal);
            Console.WriteLine("Wagered profit total: " + x[0].Item2.WagersOverallProfit);
            Console.WriteLine("Longest red streak:   " + RouletteLogic.GetRouletteStats.LongestRedStreak);
            Console.WriteLine("Longest black streak: " + RouletteLogic.GetRouletteStats.LongestBlackStreak);
            Console.WriteLine("Longest even streak:  " + RouletteLogic.GetRouletteStats.LongestEvenStreak);
            Console.WriteLine("Longest odd streak:   " + RouletteLogic.GetRouletteStats.LongestOddStreak);
            
            //Console.WriteLine("Hello, World!");
        }
    }
}