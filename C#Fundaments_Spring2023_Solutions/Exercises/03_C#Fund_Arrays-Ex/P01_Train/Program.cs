int n=int.Parse(Console.ReadLine());
int[] peopleOnWagon=new int[n];
for(int i = 0; i < peopleOnWagon.Length; i++)
{
    peopleOnWagon[i]=int.Parse(Console.ReadLine());
}
Console.WriteLine(string.Join(" ",peopleOnWagon));
Console.WriteLine(peopleOnWagon.Sum());
