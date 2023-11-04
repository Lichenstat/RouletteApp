using RouletteApp.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RouletteApp.Controller
{
    internal interface IRouletteLogic
    {
        // return the user and wagers for the user
        List<(RouletteUser, RouletteWager)> GetUsersWithWagers { get; }

        // get roulette stats
        RouletteStats GetRouletteStats { get; }

        // add a user to the game
        void AddUserToGame(RouletteUser user);

        // remove a user from the game
        void RemoveUserFromGame(int userId);

        // roll for a certain roulette cell and play the bet
        void SpinAndCalculateWagers();

    }
}
