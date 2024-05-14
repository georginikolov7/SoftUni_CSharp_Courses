using P01.Stream_Progress.Interfaces;

namespace P01.Stream_Progress
{
    public class Program
    {
        static void Main()
        {
            
            IStreamable musicFile = new Music("Pink Floyd - Wish you were here", "Pink Floyd", "Wish you were here", 300000, 30000);
            StreamProgressInfo streamer = new(musicFile);
            System.Console.WriteLine(streamer.CalculateCurrentPercent());
        }
    }
}
