using RouletteApp.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RouletteApp.Controller
{
    public class RouletteLogic : IRouletteLogic
    {
        private readonly RouletteTable _table = new RouletteTable();
        private List<(RouletteUser, RouletteWager)> _userAndWagers = new List<(RouletteUser, RouletteWager)>();
        private RouletteStats _stats = new RouletteStats();

        public RouletteLogic()
        {

        }

        public List<(RouletteUser, RouletteWager)> GetUsersWithWagers
        {
            get { return _userAndWagers; }
        }

        public RouletteStats GetRouletteStats{
            get { return  _stats; }
        }

        public void AddUserToGame(RouletteUser user)
        {
            _userAndWagers.Add((user, new RouletteWager()));
            _userAndWagers.Last().Item2.CurrentCell = _table.SpinResult;
            
        }

        public void RemoveUserFromGame(int userId)
        {
            int i = 0;

            foreach(var user in _userAndWagers)
            {
                if (user.Item1.Id == userId)
                {
                    _userAndWagers.RemoveAt(i);
                    break;
                }

                i++;
            }
        }

        // it is important to note that the wager is only subtracted from their money pool as soon as play starts,
        // so their money pool will not change by making bets until play
        public void SpinAndCalculateWagers()
        {

            // at the moment wagers will play on the previous cell that was assigned to them, but we will assign the cell it lands on currently this round for next round
            _stats.AddCellToHistory(_table.SpinResult);
            _table.SpinWheel();

            foreach (var userWagers in _userAndWagers)
            {
                if (userWagers.Item1.MoneyTotal > 0)
                {
                    userWagers.Item2.RunAllWagers();
                    userWagers.Item1.AddMoney(userWagers.Item2.WagersRoundProfit);
                }

                userWagers.Item2.CurrentCell = _table.SpinResult;
            }

        }
    }
}
