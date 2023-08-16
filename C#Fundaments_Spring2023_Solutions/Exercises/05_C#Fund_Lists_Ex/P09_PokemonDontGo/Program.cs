namespace P09_PokemonDontGo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> distances = Console.ReadLine()
                 .Split(" ")
                 .Select(int.Parse)
                 .ToList();
            int sumOfRemovedElements = 0;
            while (distances.Count > 0)
            {
                int currentDistaceIndex=int.Parse(Console.ReadLine());
                int valueOfRemovedElement;
                if (currentDistaceIndex < 0)
                {
                    valueOfRemovedElement = distances[0];
                    RemoveFirstElementAndCopyLast(distances);
                }
                else if (currentDistaceIndex >= distances.Count)
                {
                    valueOfRemovedElement= distances[distances.Count-1];
                    RemoveLastElementAndCopyFirst(distances);
                }
                else
                {
                    valueOfRemovedElement = distances[currentDistaceIndex];
                    distances.RemoveAt(currentDistaceIndex);
                }

                sumOfRemovedElements += valueOfRemovedElement;
                for (int i = 0; i < distances.Count; i++)
                {
                    if (distances[i] <= valueOfRemovedElement)
                    {
                        distances[i] += valueOfRemovedElement;
                    }

                    else if (distances[i] > valueOfRemovedElement)
                    {
                        distances[i]-=valueOfRemovedElement;
                    }

                }
            }
            Console.WriteLine(sumOfRemovedElements);
        }

        static void RemoveLastElementAndCopyFirst(List<int> distances)
        {
  
            distances.RemoveAt(distances.Count-1);
            distances.Add(distances[0]);
        }

        static void RemoveFirstElementAndCopyLast(List<int> distances)
        {
            distances.RemoveAt(0);
            distances.Insert(0, distances[distances.Count - 1]);
        }
    }
}