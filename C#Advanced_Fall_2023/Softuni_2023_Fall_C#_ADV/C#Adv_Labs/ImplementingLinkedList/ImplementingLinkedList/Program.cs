using ImplementingLinkedList;

namespace CustomDoublyLinkedList
{
    public class StartUp
    {
        static void Main()
        {
            DoublyLinkedList<int> linkedList = new();
            linkedList.AddFirst(1);
            linkedList.AddLast(2);
            linkedList.AddLast(5);
            linkedList.RemoveFirst();
            linkedList.AddFirst(3);
             foreach(var item in linkedList)
            {
                Console.WriteLine(item);
            }
            int[] array=linkedList.ToArray();
            Console.WriteLine(string.Join(" ",array));
        }
    }
}