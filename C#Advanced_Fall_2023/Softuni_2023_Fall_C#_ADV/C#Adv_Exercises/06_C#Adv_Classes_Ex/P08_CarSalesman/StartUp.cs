using System.Reflection;

namespace P08_CarSalesman
{
    public class StartUp
    {
        static void Main()
        {
            List<Engine> engines = new List<Engine>();
            int countOfEngines = int.Parse(Console.ReadLine());
            for (int i = 0; i < countOfEngines; i++)
            {
                string[] tokens = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);
                //"{model} {power} {displacement} {efficiency}"
                //Keep in mind that "displacement" and "efficiency" are optional, they could be missing from the command.
                string model = tokens[0];
                int power = int.Parse(tokens[1]);
                Engine engine = new Engine(model, power);
                if (tokens.Length > 2)
                {
                    //third prop is either displ or efficiency:
                    bool isDisplacement = int.TryParse(tokens[2], out int displacement);
                    if (isDisplacement)
                    {
                        engine.Displacement = displacement;
                    }
                    else
                    {
                        engine.Efficiency = tokens[2];
                    }

                    //if tokens are 4:
                    //index 3 is displ (already set above)
                    //index 4 is eff
                    if (tokens.Length > 3)
                    {
                        engine.Efficiency = tokens[3];
                    }
                }
                engines.Add(engine);
            }

            List<Car> cars = new();
            int countOfCars = int.Parse(Console.ReadLine());
            for (int i = 0; i < countOfCars; i++)
            {
                //"{model} {engine} {weight} {color}".
                string[] tokens = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string model = tokens[0];
                string engineModel = tokens[1];
                Car car = new Car(model, engines.FirstOrDefault(e => e.Model == engineModel));
                if (tokens.Length > 2)
                {
                    bool isWeight = int.TryParse(tokens[2], out int weight);
                    if (isWeight)
                    {
                        car.Weight = weight;
                    }
                    else
                    {
                        car.Color = tokens[2];
                    }

                    if (tokens.Length > 3)
                    {
                        car.Color = tokens[3];
                    }
                }
                cars.Add(car);
            }

            foreach (Car car in cars)
            {
                Console.WriteLine(car.ToString().Trim());
            }
        }
    }
}