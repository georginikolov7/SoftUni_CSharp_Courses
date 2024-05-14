using P07_RawData;

namespace RawData
{

    public class StartUp
    {
        static void Main()
        {
            List<Car> cars = new List<Car>();
            int count = int.Parse(Console.ReadLine());
            for (int i = 0; i < count; i++)
            {
                string[] input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string model = input[0];
                int engineSpeed = int.Parse(input[1]);
                int enginePower = int.Parse(input[2]);
                int cargoWeight = int.Parse(input[3]);
                string cargotype = input[4];
                double tire1Pressure = double.Parse(input[5]);
                int tire1Age = int.Parse(input[6]);
                double tire2Pressure = double.Parse(input[7]);
                int tire2Age = int.Parse(input[8]);
                double tire3Pressure = double.Parse(input[9]);
                int tire3Age = int.Parse(input[10]);
                double tire4Pressure = double.Parse(input[11]);
                int tire4Age = int.Parse(input[12]);
                cars.Add(new Car(model, engineSpeed, enginePower, cargoWeight, cargotype, tire1Pressure, tire1Age, tire2Pressure, tire2Age, tire3Pressure, tire3Age, tire4Pressure, tire4Age));
             }
            string command = Console.ReadLine();
            if (command == "fragile")
            {
                //print all cars, whose cargo is "fragile" and have a pressure of a single tire < 1.
                foreach (Car car in cars.Where(x => x.Cargo.Type == "fragile").Where(x => x.Tires.Any(x => x.Pressure < 1)))
                {
                    Console.WriteLine(car.Model);
                }
            }
            else if (command == "flammable")
            {
                //	"flammable" - print all cars, whose cargo is "flammable" and have engine power > 250.
                foreach(Car car in cars.Where(c => c.Cargo.Type == "flammable").Where(c=>c.Engine.Power>250))
                {
                    Console.WriteLine(car.Model);
                }
            }
        }
    }
}