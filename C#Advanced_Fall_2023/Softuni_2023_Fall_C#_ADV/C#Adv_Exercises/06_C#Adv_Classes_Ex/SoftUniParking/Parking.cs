using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftUniParking
{
    public class Parking
    {
        private Dictionary<string, Car> cars;
        private int capacity;
        private readonly int count;

        public Parking(int cap)
        {
            Cars = new Dictionary<string, Car>();
            Capacity = cap;
        }
        public Dictionary<string, Car> Cars
        {
            get { return cars; }
            set { cars = value; }
        }

        public int Count
        {
            get { return cars.Count; }
        }

        public int Capacity
        {
            set { capacity = value; }
        }
        public string AddCar(Car car)
        {
            if (cars.ContainsKey(car.RegistrationNumber))
            {
                return ("Car with that registration number, already exists!");
            }
            else if (cars.Count() == capacity)
            {
                return ("Parking is full!");
            }
            cars.Add(car.RegistrationNumber, car);
            return ($"Successfully added new car {car.Make} {car.RegistrationNumber}");

        }
        public string RemoveCar(string registration)
        {
            if (!cars.ContainsKey(registration))
            {
                return "Car with that registration number, doesn't exist!";
            }
            cars.Remove(registration);
            return $"Successfully removed {registration}";
        }
        public Car GetCar(string registration)
        {
            if (cars.ContainsKey(registration))
            {
                return cars[registration];
            }
            return null;
        }
        public void RemoveSetOfRegistrationNumber(List<string> registrationNumber)
        {
            foreach(string registration in registrationNumber)
            {
                if (Cars.ContainsKey(registration))
                {
                    Cars.Remove(registration);
                }
            }
        }
    }
}
