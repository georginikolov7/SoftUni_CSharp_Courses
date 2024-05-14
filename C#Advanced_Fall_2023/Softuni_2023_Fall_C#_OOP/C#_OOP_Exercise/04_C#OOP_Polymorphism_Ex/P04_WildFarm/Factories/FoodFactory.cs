using P04_WildFarm.Factories.Interfaces;
using P04_WildFarm.Models.Foods;
using P04_WildFarm.Models.Interfaces;


namespace P04_WildFarm.Factories
{
    public class FoodFactory : IFoodFactory
    {
        public IFood CreateFood(string[] tokens)
        {
            switch (tokens[0])
            {
                case "Vegetable":
                    return new Vegetable(int.Parse(tokens[1]));
                case "Fruit":
                    return new Fruit(int.Parse(tokens[1]));
                case "Meat":
                    return new Meat(int.Parse(tokens[1]));
                case "Seeds":
                    return new Seeds(int.Parse(tokens[1]));
                default:
                    throw new Exception("Invalid food type!");
            }

        }
    }
}
