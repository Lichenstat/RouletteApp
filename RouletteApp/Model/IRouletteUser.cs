using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RouletteApp.Model
{
    internal interface IRouletteUser
    {
        // return total users money
        int MoneyTotal { get; }

        // add money to the user
        void AddMoney(int money);

        // deduct money from the user
        void SubtractMoney(int money);
    }
}
