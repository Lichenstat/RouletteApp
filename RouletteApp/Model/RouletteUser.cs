using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RouletteApp.Model
{
    public class RouletteUser : IRouletteUser
    {
        private readonly int _id;
        private readonly string _name;
        private int _money;

        private RouletteUsersMemory _usersMemory = RouletteUsersMemory.Instance;

        public RouletteUser(string name, int money) 
        {
            _name = name;
            _id = _usersMemory.GetNewId();
            _money = money;
        }

        public int Id
        {
            get { return _id; }
        }

        public string Name
        {
            get { return _name; }
        }

        public int MoneyTotal
        {
            get { return _money; }
        }

        public void AddMoney(int money)
        {
            _money = _money + money;
        }

        /*
        public void SubtractMoney(int money)
        {
            _money = _money - money;
        }
        */
    }
}
