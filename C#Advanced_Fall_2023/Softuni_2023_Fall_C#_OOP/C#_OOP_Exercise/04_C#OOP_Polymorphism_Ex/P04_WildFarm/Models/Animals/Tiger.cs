using P04_WildFarm.Models.Foods;


namespace P04_WildFarm.Models.Animals
{
    public class Tiger : Feline
    {
        private const double WEIGHT_INCREMENT = 1;
        public Tiger(string name, double weight, string livingRegion, string breed) : base(name, weight, livingRegion, breed)
        {
        }

        protected override IReadOnlyCollection<string> EatenFoodTypes => new List<string>() { typeof(Meat).ToString() };

        protected override double WeightIncrement => WEIGHT_INCREMENT;

        public override string AskForFood()
        {
            return "ROAR!!!";
        }
    }
}
