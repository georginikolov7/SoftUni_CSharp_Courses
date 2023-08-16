namespace P03_Songs
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int numberOfSongs = int.Parse(Console.ReadLine());
            List<Song> songs = new List<Song>();
            for (int i = 0; i < numberOfSongs; i++)
            {
                string[] arguments = Console.ReadLine()
                    .Split("_")
                    .ToArray();
                Song currentSong = new Song(arguments[0], arguments[1], arguments[2]);
                songs.Add(currentSong);
            }
            string printOption=Console.ReadLine();

            if (printOption == "all")
            {
                foreach(Song song in songs)
                {
                    Console.WriteLine(song.Name);
                }
            }
            else
            {
                foreach (Song song in songs)
                {
                    if (song.TypeList == printOption)
                    {
                        Console.WriteLine(song.Name);
                    }
                }
            }
        }
    }
    internal class Song
    {
        public Song(string typeList,string name,string time)
        {
            TypeList = typeList;
            Name = name;
            Time = time;
        }

        public string TypeList { get; set; }
        public string Name { get; set; }
        public string Time { get; set; }

    }

}