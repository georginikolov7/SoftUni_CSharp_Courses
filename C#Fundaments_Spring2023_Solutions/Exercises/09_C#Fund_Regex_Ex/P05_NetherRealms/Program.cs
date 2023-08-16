using System.Text.RegularExpressions;

namespace P05_NetherRealms
{
    class Demon
    {
        public Demon(string name, int health, double damage)
        {
            Name = name;
            Health = health;
            Damage = damage;
        }

        public string Name { get; set; }
        public int Health { get; set; }
        public double Damage { get; set; }
        public override string ToString()
        {
            return $"{Name} - {Health} health, {Damage:f2} damage";
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Demon> demons = new List<Demon>();
            string splitPattern = @"[ ,\n]+";
            string[] demonNames = Regex.Split(Console.ReadLine(), splitPattern);
            //add all demons
            foreach (string demonName in demonNames)
            {
                demons.Add(GenerateDemonInfo(demonName));
            }
            //Print demons:
            PrintDemons(demons);
        }

        static void PrintDemons(List<Demon> demons)
        {
            foreach(Demon demon in demons.OrderBy(x => x.Name))
            {
                Console.WriteLine(demon);
            }
        }

        private static Demon GenerateDemonInfo(string demonName)
        {
            int demonHealth = GetHealth(demonName);
            double baseDamage = GetBaseDamage(demonName);
            double totalDamage = CalculateDamage(demonName, baseDamage);
            Demon demon = new Demon(demonName, demonHealth, totalDamage);
            return demon;
        }

        static double CalculateDamage(string demonName, double baseDamage)
        {
            double damage = baseDamage;
            string pattern = @"[/*]";
            MatchCollection matchCollection = Regex.Matches(demonName, pattern);
            foreach (Match match in matchCollection)
            {
                if (char.Parse(match.Value) == '/')
                {
                    damage /= 2;
                }
                else if (char.Parse(match.Value) == '*')
                {
                    damage *= 2;
                }
            }
            return damage;
        }

        static double GetBaseDamage(string demonName)
        {
            double baseDamage = 0;
            string pattern = @"[+-]*(?:\d+\.\d+|\d+)";
            MatchCollection matchCollection = Regex.Matches(demonName, pattern);
            foreach (Match match in matchCollection)
            {
                baseDamage += double.Parse(match.Value);
            }
            return baseDamage;
        }

        static int GetHealth(string demonName)
        {
            int health = 0;
            string healthPattern = @"[^0-9+\-*/.]";
            MatchCollection matchcollection = Regex.Matches(demonName, healthPattern);
            foreach (Match match in matchcollection)
            {
                health += char.Parse(match.Value);
            }
            return health;
        }
    }
}