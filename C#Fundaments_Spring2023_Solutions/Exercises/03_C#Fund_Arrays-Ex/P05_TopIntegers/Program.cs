int[] nums = Console.ReadLine()
    .Split()
    .Select(int.Parse)
    .ToArray();

for (int i = 0; i < nums.Length - 1; i++)
{
    bool isTop = true;
    for (int j = i + 1; j < nums.Length; j++)
    {
        if (nums[i] <= nums[j])
        {
            isTop = false;
            break;
        }
    }
    if (isTop == true)
    {
        Console.Write(nums[i] + " ");
    }
}
Console.Write(nums[nums.Length - 1]);
