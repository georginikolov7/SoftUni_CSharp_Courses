int[] arr=Console.ReadLine().Split(" ").Select(int.Parse).ToArray();
bool flag = false;
int i = 0;
for (; i < arr.Length; i++)
{
    int leftSum = 0, rightSum = 0;
	for (int leftIndex = 0; leftIndex < i; leftIndex++)
	{
		leftSum += arr[leftIndex];
	}
	for (int rightIndex = i+1; rightIndex < arr.Length; rightIndex++)
	{
		rightSum += arr[rightIndex];
	}
	if (leftSum == rightSum)
	{
		flag= true;
		
		break;
	}
}
if (flag == true)
{
	Console.WriteLine(i);
}
else
{
    Console.WriteLine("no");
}
