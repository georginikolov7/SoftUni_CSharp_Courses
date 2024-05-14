
using P04_WildFarm.Factories;
using P04_WildFarm.Factories.Interfaces;
using P04_WildFarm.IO.Interfaces;
using P04_WildFarm.Models.Interfaces;


namespace P04_WildFarm.Core
{
    public class Engine
    {
        private readonly IWriter writer;
        private readonly IReader reader;
        private readonly IAnimalFactory animalFactory = new AnimalFactory();
        private readonly IFoodFactory foodFactory = new FoodFactory();
        private List<IAnimal> animals = new();
        public Engine(IReader reader, IWriter writer)
        {
            this.reader = reader;
            this.writer = writer;
        }
        public void Run()
        {
            string input;
            while ((input = reader.ReadLine()) != "End")
            {
                IAnimal currentAnimal = null;
                try
                {
                    string[] tokens = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                    currentAnimal = animalFactory.CreateAnimal(tokens);
                    animals.Add(currentAnimal);

                    tokens = reader.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                    IFood currentFood = foodFactory.CreateFood(tokens);
                    writer.WriteLine(currentAnimal.AskForFood());
                    currentAnimal.Feed(currentFood);
                }
                catch (ArgumentException ex)
                {
                    writer.WriteLine(ex.Message);
                }
                catch (Exception)
                {
                    throw;
                }
            }


            foreach (IAnimal a in animals)
            {
                writer.WriteLine(a.ToString());
            }
        }

    }
}
