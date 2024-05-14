using P03_Raiding.Factories;
using P03_Raiding.Factories.Interfaces;
using P03_Raiding.IO.Interfaces;
using P03_Raiding.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace P03_Raiding.Core
{
    public class Engine
    {
        private readonly IWriter writer;
        private readonly IReader reader;
        private readonly IHeroFactory factory = new HeroFactory();
        private List<IHero> heroes = new();
        public Engine(IReader reader, IWriter writer)
        {
            this.reader = reader;
            this.writer = writer;
        }

        public void Run()
        {
            int count = int.Parse(reader.ReadLine());
            while (count > 0)
            {
                string name = reader.ReadLine();
                string type = reader.ReadLine();
                try
                {
                    heroes.Add(factory.CreateHero(name, type));
                    count--;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }


            int bossHealth = int.Parse(reader.ReadLine());
            foreach (var hero in heroes)
            {
                writer.WriteLine(hero.CastAbility());
                bossHealth -= hero.Power;
            }
            if (bossHealth > 0)
            {
                Console.WriteLine("Defeat...");
            }
            else
            {
                Console.WriteLine("Victory!");
            }
        }
    }
}
