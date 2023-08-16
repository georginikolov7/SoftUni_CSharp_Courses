namespace P02_ChangeList
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> nums = Console.ReadLine().Split().Select(int.Parse).ToList();
            string input;
            while ((input=Console.ReadLine())!="end")
            {
                string[] command = input.Split().ToArray();
                int element;
                int position;
                if (command[0] == "Delete")
                {
                    element = int.Parse(command[1]);
                    nums.RemoveAll(x => x == element);
                }
                else if (command[0] == "Insert")
                {
                    element = int.Parse(command[1]);
                    position = int.Parse(command[2]);
                    nums.Insert(position,element);  
                }
            }
            Console.WriteLine(string.Join(" ",nums));
        }
    }
}