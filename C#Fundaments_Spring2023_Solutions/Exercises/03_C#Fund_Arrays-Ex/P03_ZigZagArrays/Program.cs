int numOfLines=int.Parse(Console.ReadLine());
int[] arr1= new int[numOfLines];
int[] arr2= new int[numOfLines];
int arr1Index = 0;
int arr2Index = 1;
for(int i=0; i<numOfLines; i++)
{
    int[] input = Console.ReadLine().Split().Select(int.Parse).ToArray();
    arr1[i] = input[arr1Index];
    arr2[i] = input[arr2Index];
    (arr1Index, arr2Index) = (arr2Index, arr1Index);

}
Console.WriteLine(string.Join(" ",arr1));
Console.WriteLine(string.Join(" ", arr2));