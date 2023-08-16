using System.ComponentModel.DataAnnotations;

namespace P01_AdvertisementMessage
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int numberOfMessages = int.Parse(Console.ReadLine());
            //List<string> phrases = new List<string> { "Excellent product.", "Such a great product.", "I always use that product.", "Best product of its category.", "Exceptional product.", "I can't live without this product." };
            //List<string> events = new List<string> { "Now I feel good.", "I have succeeded with this product.", "Makes miracles. I am happy of the results!", "I cannot believe but now I feel awesome.", "Try it yourself, I am very satisfied.", "I feel great!" };
            //List<string> authors = new List<string> { "Diana", "Petya", "Stella", "Elena", "Katya", "Iva", "Annie", "Eva" };
            //List<string> cities = new List<string> { "Burgas", "Sofia", "Plovdiv", "Varna", "Ruse" };
            //Random random = new Random();
            for (int i = 0; i < numberOfMessages; i++)
            {
                Message message = new Message();
                Console.WriteLine(message.GetRandomMessage());
            }
        }
    }
    class Message
    {


        private readonly string[] phrases =
        {
            "Excellent product.",
            "Such a great product.",
            "I always use that product.",
            "Best product of its category.",
            "Exceptional product.",
            "I can't live without this product."
        };

        private readonly string[] events =
        {
            "Now I feel good.",
            "I have succeeded with this product.",
            "Makes miracles.I am happy of the results!",
            "I cannot believe but now I feel awesome.",
            "Try it yourself, I am very satisfied.",
            "I feel great!"
        };

        private readonly string[] authors =
        {
            "Diana", "Petya", "Stella", "Elena", "Katya", "Iva", "Annie", "Eva"
        };

        private readonly string[] cities =
        {
            "Burgas", "Sofia", "Plovdiv", "Varna", "Ruse"
        };
        public string GetRandomMessage()
        {
            Random random= new Random();
            string phrase = phrases[random.Next(0, phrases.Length - 1)];
            string @event = events[random.Next(0, events.Length - 1)];
            string author = authors[random.Next(0, authors.Length - 1)];
            string city = cities[random.Next(0, cities.Length - 1)];
            return $"{phrase} {@event} {author} - {city}";
        }
    }
}

