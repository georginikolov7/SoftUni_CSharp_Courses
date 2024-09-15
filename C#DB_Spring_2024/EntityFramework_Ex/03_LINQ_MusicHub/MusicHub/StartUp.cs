namespace MusicHub
{
    using System;
    using System.Diagnostics;
    using System.Text;
    using Data;
    using Initializer;
    using MusicHub.Data.Models;

    public class StartUp
    {
        public static void Main()
        {
            MusicHubDbContext context =
                new MusicHubDbContext();

            DbInitializer.ResetDatabase(context);

            //Test your solutions here

            Console.WriteLine(ExportSongsAboveDuration(context, 4));
        }

        public static string ExportAlbumsInfo(MusicHubDbContext context, int producerId)
        {
            var albumData = context.Albums
                .Where(a => a.ProducerId == producerId)
                .Select(a => new
                {
                    a.Name,
                    ReleaseDate = a.ReleaseDate.ToString("MM/dd/yyyy"),
                    ProducerName = a.Producer.Name,
                    Songs = a.Songs
                        .Select(s => new
                        {
                            SongName = s.Name,
                            SongPrice = s.Price,
                            SongWriterName = s.Writer.Name
                        }).ToList(),
                    AlbumPrice = a.Price
                }).ToList();

            StringBuilder sb = new();
            foreach (var album in albumData.OrderByDescending(a => a.AlbumPrice))
            {
                sb.AppendLine($"-AlbumName: {album.Name}");
                sb.AppendLine($"-ReleaseDate: {album.ReleaseDate}");
                sb.AppendLine($"-ProducerName: {album.ProducerName}");
                sb.AppendLine("-Songs:");
                int indexer = 1;
                foreach (var song in album.Songs.OrderByDescending(s => s.SongName).ThenBy(s => s.SongWriterName))
                {
                    sb.AppendLine($"---#{indexer}");
                    sb.AppendLine($"---SongName: {song.SongName}");
                    sb.AppendLine($"---Price: {song.SongPrice:f2}");
                    sb.AppendLine($"---Writer: {song.SongWriterName}");
                    indexer++;
                }
                sb.AppendLine($"-AlbumPrice: {album.AlbumPrice:f2}");
            }

            return sb.ToString().Trim();
        }

        public static string ExportSongsAboveDuration(MusicHubDbContext context, int duration)
        {
            var durationTimeSpan = new TimeSpan(0, 0, duration);
            var songs = context.Songs
               .Where(s => s.Duration > durationTimeSpan)
               .Select(s => new
               {
                   s.Name,
                   Performers = s.SongPerformers
                       .OrderBy(sp => sp.Performer.FirstName)
                       .Select(sp => new
                       {
                           PerformerName = sp.Performer.FirstName + " " + sp.Performer.LastName
                       }).ToList(),
                   WriterName = s.Writer.Name,
                   AlbumProducer = s.Album.Producer.Name,
                   Duration = s.Duration.ToString("c")

               })
               .OrderBy(s => s.Name)
               .ThenBy(s => s.WriterName)
               .ToList();

            StringBuilder sb = new();

            for (int i = 0; i < songs.Count; i++)
            {
                var currentSong = songs[i];
                sb.AppendLine($"-Song #{i + 1}");
                sb.AppendLine($"---SongName: {currentSong.Name}");
                sb.AppendLine($"---Writer: {currentSong.WriterName}");
                if (currentSong.Performers.Any())
                {
                    foreach (var p in currentSong.Performers)
                    {
                        sb.AppendLine($"---Performer: {p.PerformerName}");
                    }
                }
                sb.AppendLine($"---AlbumProducer: {currentSong.AlbumProducer}");
                sb.AppendLine($"---Duration: {currentSong.Duration}");

            }

            return sb.ToString().Trim();
        }
    }
}
