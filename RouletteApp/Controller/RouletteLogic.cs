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
        private RouletteTable _table = new RouletteTable();
        private List<Action> _wagerList = new List<Action>();
        
        public RouletteLogic() { }


    }
}
