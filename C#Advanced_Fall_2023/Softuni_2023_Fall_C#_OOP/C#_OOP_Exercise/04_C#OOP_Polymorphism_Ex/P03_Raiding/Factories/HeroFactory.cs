using P03_Raiding.Factories.Interfaces;
using P03_Raiding.Models;
using P03_Raiding.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P03_Raiding.Factories
{
    public class HeroFactory : IHeroFactory
    {
        public IHero CreateHero(string name, string type)
        {
            switch (type)
            {
                case "Druid":
                    return new Druid(name);
                case "Paladin":
                    return new Paladin(name);
                case "Rogue":
                    return new Rogue(name);
                case "Warrior":
                    return new Warrior(name);
                default:
                    throw new ArgumentException("Invalid hero!");

            }
        }
    }
}
