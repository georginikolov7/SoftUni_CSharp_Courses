using System;
using System.Collections.Generic;
using System.Runtime.ConstrainedExecution;

namespace Animals
{
    public class StartUp
    {
        public static void Main(string[] args)
        {


            List<Animal> animals = new List<Animal>();
            string input;
            while ((input = Console.ReadLine()) != "Beast!")
            {
                string type = input;
                string[] animalProps = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
                if (animalProps.Length != 3)
                {
                    throw new Exception("Invalid input!");
                }
                string name = animalProps[0];
                int age = 0;
                try
                {
                    age = int.Parse(animalProps[1]);
                }
                catch (Exception)
                {
                    throw new Exception("Invalid input!");
                }
                string gender = animalProps[2];

                switch (type)
                {
                    case "Dog":
                        Dog dog = new Dog(name, age, gender);
                        animals.Add(dog);
                        break;
                    case "Cat":
                        Cat cat = new Cat(name, age, gender);
                        animals.Add(cat);
                        break;
                    case "Frog":
                        Frog frog = new(name, age, gender);
                        animals.Add(frog);
                        break;
                    case "Kitten":
                        Kitten kitten = new Kitten(name, age);
                        animals.Add(kitten);
                        break;
                    case "Tomcat":
                        Tomcat tomcat = new Tomcat(name, age);
                        animals.Add(tomcat);
                        break;

                }
            }
            foreach (var animal in animals)
            {
                PrintAnimal(animal);
            }
        }

        private static void PrintAnimal(Animal animal)
        {
            Console.WriteLine(animal.GetType().Name);
            Console.WriteLine($"{animal.Name} {animal.Age} {animal.Gender}");
            Console.WriteLine(animal.ProduceSound());
        }
    }
}
