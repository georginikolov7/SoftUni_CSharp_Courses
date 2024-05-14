using P04_WildFarm.Models.Interfaces;


namespace P04_WildFarm.Models.Animals
{
    public abstract class Animal : IAnimal
    {
        public Animal(string name, double weight)
        {
            Name = name;
            Weight = weight;

        }

        public string Name { get; private set; }

        public double Weight { get; private set; }

        public int FoodEaten { get; private set; }
        protected abstract IReadOnlyCollection<string> EatenFoodTypes { get; }
        protected abstract double WeightIncrement { get; }

        public abstract string AskForFood();

        public void Feed(IFood food)
        {
            if (!EatenFoodTypes.Contains(food.GetType().ToString()))
            {
                throw new ArgumentException($"{GetType().Name} does not eat {food.GetType().Name}!");
            }
            FoodEaten += food.Quantity;
            Weight += WeightIncrement * food.Quantity;
        }

    }
}
