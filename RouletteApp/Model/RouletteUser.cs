using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RouletteApp.Model
{
    internal class RouletteUser : IRouletteUser
    {
        private readonly int _id;
        private int _money;

        private RouletteUsersMemory _usersMemory = RouletteUsersMemory.Instance;

        public RouletteUser(int money) 
        {
            _id = _usersMemory.GetNewId();
            _money = money;
        }

        public int MoneyTotal
        {
            get { return _money; }
        }

        public void AddMoney(int money)
        {
            _money = _money + money;
        }

        public void SubtractMoney(int money)
        {
            _money = _money - money;
        }

    }
}
