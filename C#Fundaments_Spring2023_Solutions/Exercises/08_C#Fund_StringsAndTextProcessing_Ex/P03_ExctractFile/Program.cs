namespace P03_ExctractFile
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string filePath = Console.ReadLine();
            int indexOfLastBackslash = filePath.LastIndexOf('\\');
            int indexOfPoint=filePath.IndexOf(".");
            string name=filePath.Substring(indexOfLastBackslash+1,indexOfPoint-indexOfLastBackslash-1);
            string extention=filePath.Substring(indexOfPoint+1);
            
            Console.WriteLine($"File name: {name}");
            Console.WriteLine($"File extension: {extention}");

        }
    }
}