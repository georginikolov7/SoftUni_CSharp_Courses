using P03_Raiding.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P03_Raiding.Factories.Interfaces
{
    public interface IHeroFactory
    {
        IHero CreateHero(string name, string type);
    }
}
