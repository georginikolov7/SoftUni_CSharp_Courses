using System.Linq;
using System.Text;

namespace CarManufacturer
{
    public class StartUp
    {
        static void Main()
        {
            List<Tire[]> tires = new List<Tire[]>();
            string command;
            while ((command = Console.ReadLine()) != "No more tires")
            {
                //{year} {pressure}
                //2 2.6 3 1.6 2 3.6 3 1.6
                string[] tokens = command.Split(" ");
                List<Tire> currentSetOfTires= new();
                for (int i = 0; i < tokens.Length-1; i+=2)
                {
                    Tire currentTire = new Tire(int.Parse(tokens[i]), double.Parse(tokens[i + 1]));
                    currentSetOfTires.Add(currentTire);
                }
                tires.Add(currentSetOfTires.ToArray());
            }


            List<Engine> engines = new List<Engine>();
            while ((command = Console.ReadLine()) != "Engines done")
            {
                //{horsePower} {cubicCapacity} 
                string[] tokens = command.Split(" ");
                engines.Add(new Engine(int.Parse(tokens[0]), double.Parse(tokens[1])));
            }

            List<Car> cars = new();
            while ((command = Console.ReadLine()) != "Show special")
            {
                //{make} {model} {year} {fuelQuantity} {fuelConsumption} {engineIndex} {tiresIndex}
                string[] tokens = command.Split(" ");
                string make = tokens[0];
                string model = tokens[1];
                int year = int.Parse(tokens[2]);
                double fuelQuantity = double.Parse(tokens[3]);
                double fuelConsumption = double.Parse(tokens[4]);
                int engineIndex = int.Parse(tokens[5]);
                int tiresIndex = int.Parse(tokens[6]);
               
                cars.Add(new Car(make, model, year, fuelQuantity, fuelConsumption, engines[engineIndex], tires[tiresIndex]));
            }
            List<Car> specialCars = new List<Car>();
            
            
            foreach (Car car in cars
                .Where(x => x.Year >= 2017)
                .Where(x => x.Engine.HorsePower > 330)
                .Where(x => x.Tires.Select(x => x.Pressure).Sum() > 9)
                .Where(x => x.Tires.Select(x => x.Pressure).Sum() < 10)
                .ToList())
            {
                car.Drive(20);
                specialCars.Add(car);
            }

            foreach (Car specialCar in specialCars)
            {
                StringBuilder sb = new StringBuilder();
                sb.AppendLine($"Make: {specialCar.Make}");
                sb.AppendLine($"Model: {specialCar.Model}");
                sb.AppendLine($"Year: {specialCar.Year}");
                sb.AppendLine($"HorsePowers: {specialCar.Engine.HorsePower}");
                sb.AppendLine($"FuelQuantity: {specialCar.FuelQuantity}");
                Console.WriteLine(sb.ToString().Trim());

            }
        }
    }
}
