using Classes;
class StartUp
{
    static void Main()
    {
        List<Car> cars = new List<Car>();
        int countOfCars = int.Parse(Console.ReadLine());
        for (int i = 0; i < countOfCars; i++)
        {
            // "{model} {fuelAmount} {fuelConsumptionFor1km}"
            string[] inputTokens = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);
            Car currentCar = new Car(inputTokens[0], double.Parse(inputTokens[1]), double.Parse(inputTokens[2]));
            cars.Add(currentCar);
        }
            string command;
            while((command = Console.ReadLine()) != "End")
            {
                //"Drive {carModel} {amountOfKm}"
                string[] tokens = command.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string currentModel = tokens[1];
                double currentDistace = double.Parse(tokens[2]);
                int index=cars.FindIndex(x=>x.Model==currentModel);
                cars[index].Drive(currentDistace);
            }

            foreach (Car car in cars)
            {
                Console.WriteLine(car.ToString());
            }
        
    }
}