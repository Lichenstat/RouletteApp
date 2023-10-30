using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RouletteApp.Model
{
    public class RouletteUsersMemory : IRouletteUsersMemory
    {
        public int _lastUserId;
        private RouletteUsersMemory()
        {
            _lastUserId = 0;
        }

        private static readonly Lazy<RouletteUsersMemory> lazy = new Lazy<RouletteUsersMemory>(() => new RouletteUsersMemory());

        public static RouletteUsersMemory Instance
        {
            get
            {
                return lazy.Value;
            }
        }

        // return a new user id
        public int GetNewId()
        {
            _lastUserId = _lastUserId + 1;
            return _lastUserId;
        }

    }
}
