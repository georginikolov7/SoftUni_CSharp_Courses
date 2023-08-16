namespace P03_MergingLists
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> nums1 = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();

            List<int> nums2 = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();
            List<int> result = new List<int>();
            int length = GetLength(nums1, nums2);
            for (int i = 0; i < length; i++)
            {
                result.Add(nums1[i]);
                result.Add(nums2[i]);
            }
            if (nums1.Count > nums2.Count)
            {
                result.AddRange(AddRemaingNums(nums1,length));
            }
            else if(nums2.Count > nums1.Count)
            {
                result.AddRange(AddRemaingNums(nums2, length));
            }
            ;
            Console.WriteLine(string.Join(" ",result));
        }

        static List<int> AddRemaingNums(List<int> nums, int length)
        {
            nums.RemoveRange(0, length);
            return nums;
        }

        static int GetLength(List<int> nums1, List<int> nums2)
        {
            if (nums1.Count > nums2.Count)
            {
                return nums2.Count;
            }
            else 
            {                
                return nums1.Count;
            } 

        }
    }
}