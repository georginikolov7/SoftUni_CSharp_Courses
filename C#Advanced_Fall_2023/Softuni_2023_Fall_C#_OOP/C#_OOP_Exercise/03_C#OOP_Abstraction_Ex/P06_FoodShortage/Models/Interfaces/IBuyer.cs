using P05_Birthday.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P06_FoodShortage.Models.Interfaces
{
    public interface IBuyer:INameable
    {
        public int Food { get;}
        public int BuyFood();
    }
}
