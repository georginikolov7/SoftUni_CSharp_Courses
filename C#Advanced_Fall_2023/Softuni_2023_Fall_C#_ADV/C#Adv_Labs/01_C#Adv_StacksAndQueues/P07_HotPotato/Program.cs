namespace P07_HotPotato
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Queue<string> participants = new Queue<string>(Console.ReadLine().Split());
            int threshhold = int.Parse(Console.ReadLine());
            int counter = 1;
            while (participants.Count > 1)
            {
                string currentParticipant = participants.Dequeue();
                if (counter == threshhold)
                {
                    Console.WriteLine($"Removed {currentParticipant}");
                    counter = 1;
                }
                else
                {
                    participants.Enqueue(currentParticipant);
                    counter++;
                }
            }
            Console.WriteLine($"Last is {participants.Dequeue()}");
        }

    }
}