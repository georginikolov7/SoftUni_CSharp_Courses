using System.Linq;

namespace P06_SongsQueue
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine()
                .Split(", ")
                .ToArray();
            Queue<string> songs = new Queue<string>(input);
            string command;
            while (songs.Count > 0)
            {
                command = Console.ReadLine();
                string[] tokens = command
                    .Split();
                switch (tokens[0])
                {
                    case "Play":
                        songs.Dequeue();
                        break;
                    case "Add":
                        string songToAdd = string.Join(" ", tokens.Skip(1));
                        if (songs.Contains(songToAdd))
                        {
                            Console.WriteLine($"{songToAdd} is already contained!");
                        }
                        else
                        {
                            songs.Enqueue(songToAdd);
                        }
                        break;
                    case "Show":
                        Console.WriteLine(string.Join(", ", songs));
                        break;

                }

            }
            Console.WriteLine("No more songs!");
        }
    }
}