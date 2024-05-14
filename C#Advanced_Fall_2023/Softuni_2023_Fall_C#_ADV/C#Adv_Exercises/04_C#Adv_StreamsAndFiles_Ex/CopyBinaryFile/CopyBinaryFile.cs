namespace CopyBinaryFile
{
    using System;
    using System.IO;

    public class CopyBinaryFile
    {
        static void Main()
        {
            string inputFilePath = @"..\..\..\copyMe.png";
            string outputFilePath = @"..\..\..\copyMe-copy.png";

            CopyFile(inputFilePath, outputFilePath);
        }

        public static void CopyFile(string inputFilePath, string outputFilePath)
        {
            byte[] buffer;
            using FileStream stream = new FileStream(inputFilePath, FileMode.Open);
            buffer = new byte[stream.Length];
            stream.Read(buffer, 0, buffer.Length);
            using FileStream stream1 = new FileStream(outputFilePath, FileMode.OpenOrCreate);
            stream1.Write(buffer, 0, buffer.Length);

        }
    }
}
