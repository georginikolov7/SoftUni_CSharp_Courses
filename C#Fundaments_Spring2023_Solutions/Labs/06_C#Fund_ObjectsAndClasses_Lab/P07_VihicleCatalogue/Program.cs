using System.Reflection;

namespace P07_VihicleCatalogue
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input;
            Catalogue catalogue = new Catalogue();
            while ((input = Console.ReadLine()) != "end")
            {
                string[] arguments = input.Split('/');
                if (arguments[0] == "Car") 
                {
                    Car currentCar = new Car(arguments[1], arguments[2], int.Parse(arguments[3]));
                    catalogue.Cars.Add(currentCar);
                }
                else
                {
                    Truck currentTruck = new Truck(arguments[1], arguments[2], double.Parse(arguments[3]));
                    catalogue.Trucks.Add(currentTruck);
                }

            }
            Console.WriteLine("Cars:");
            foreach (Car car in catalogue.Cars.OrderBy(x=>x.Brand))
            {
                PrintCar(car.Brand, car.Model, car.HorsePower);
            }
            Console.WriteLine("Trucks:");
            foreach(Truck truck in catalogue.Trucks.OrderBy(x => x.Brand))
            {
                PrintTruck(truck.Brand, truck.Model, truck.Weight);
            }
        }

        static void PrintTruck(string brand, string model, double weight)
        {
            Console.WriteLine($"{brand}: {model} - {weight}kg");
        }

        static void PrintCar(string brand, string model, int horsePower)
        {
            Console.WriteLine($"{brand}: {model} - {horsePower}hp");
        }
    }
    public class Truck
    {
        public Truck(string brand, string model, double weight)
        {
            Brand = brand;
            Model = model;
            Weight = weight;
        }

        public string Brand { get; set; }
        public string Model { get; set; }
        public double Weight { get; set; }

    }
    public class Car
    {

        public Car(string brand, string model, int horsePower)
        {
            Brand = brand;
            Model = model;
            HorsePower = horsePower;
        }

        public string Brand { get; set; }
        public string Model { get; set; }
        public int HorsePower { get; set; }

    }
    public class Catalogue
    {

        public Catalogue()
        {
            Trucks = new List<Truck>();
            Cars = new List<Car>();
        }
        public List<Truck> Trucks { get; set; }
        public List<Car> Cars { get; set;}
    }
}