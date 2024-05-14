using System.Reflection.Metadata.Ecma335;

namespace P01.Stream_Progress
{
    public class Music : File
    {
        private string artist;
        private string album;

        public Music(string name, string artist, string album, int length, int bytesSent) : base(name, length, bytesSent)
        {
            this.artist = artist;
            this.album = album;
        }
        

    }
}
