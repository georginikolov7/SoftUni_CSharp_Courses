
using P04_WildFarm.Factories.Interfaces;
using P04_WildFarm.Models.Animals;
using P04_WildFarm.Models.Interfaces;

namespace P04_WildFarm.Factories
{
    public class AnimalFactory : IAnimalFactory
    {
        public IAnimal CreateAnimal(params string[] tokens)
        {
            switch (tokens[0])
            {
                case "Owl":
                    return new Owl(tokens[1], double.Parse(tokens[2]), double.Parse(tokens[3]));
                case "Hen":
                    return new Hen(tokens[1], double.Parse(tokens[2]), double.Parse(tokens[3]));
                case "Mouse":
                    return new Mouse(tokens[1], double.Parse(tokens[2]), tokens[3]);
                case "Dog":
                    return new Dog(tokens[1], double.Parse(tokens[2]), tokens[3]);
                case "Cat":
                    return new Cat(tokens[1], double.Parse(tokens[2]), tokens[3], tokens[4]);
                case "Tiger":
                    return new Tiger(tokens[1], double.Parse(tokens[2]), tokens[3], tokens[4]);
                default:
                    throw new Exception("Invalid type!");
            }
        }
    }
}
