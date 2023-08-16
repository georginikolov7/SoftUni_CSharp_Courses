using System.Security.Cryptography.X509Certificates;

namespace P06_VihicleCatalogue
{
    class Vihicle
    {
        public Vihicle(string type, string model, string color, int hp)
        {
            Type = type;
            Model = model;
            Color = color;
            Hp = hp;
        }

        public string Type { get; set; }
        public string Model { get; set; }
        public string Color { get; set; }
        public int Hp { get; set; }
        public override string ToString()
        {
            string result = string.Empty;
            result += $"Type: {Type}\n";
            result += $"Model: {Model}\n";
            result += $"Color: {Color}\n";
            result += $"Horsepower: {Hp}";
            return result ;
        }

    }
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Vihicle> vihicles = new List<Vihicle>();
            string input;
            while ((input = Console.ReadLine())!= "End")
            {
                string[] arguments = input.Split();
                string vihicleType = Capitalize(arguments[0]);
                string model = arguments[1];
                string color = arguments[2];
                int hp = int.Parse(arguments[3]);
                vihicles.Add(new Vihicle(vihicleType, model, color, hp));
            }
            while((input=Console.ReadLine())!= "Close the Catalogue")
            {
                Console.WriteLine(vihicles.Find(x=>x.Model==input));
            }
            double averageHp=vihicles
                .Where(x=>x.Type=="Car")
                .Select(x=>x.Hp)
                .DefaultIfEmpty()
                .Average();
            Console.WriteLine($"Cars have average horsepower of: {averageHp:f2}.");
            averageHp=vihicles
                .Where(x=>x.Type=="Truck")
                .Select(x=>x.Hp)
                .DefaultIfEmpty()
                .Average();
            Console.WriteLine($"Trucks have average horsepower of: {averageHp:f2}.");
        }
        static string Capitalize(string str)
        {
            char[] temp=str.ToCharArray();
            temp[0]=char.Parse(temp[0].ToString().ToUpper());
            return new String(temp);
        }
    }

}