string[] arr1 = Console
    .ReadLine()
    .Split();
string[] arr2 = Console
    .ReadLine()
    .Split();
//int length;
//if (arr1.Length < arr2.Length) length = arr1.Length;
//else length = arr2.Length;
for (int i = 0; i < arr2.Length; i++)
{
    for (int j = 0; j < arr1.Length; j++)
    {
        if (arr2[i] == arr1[j]) Console.Write(arr2[i] + " ");

    }


}