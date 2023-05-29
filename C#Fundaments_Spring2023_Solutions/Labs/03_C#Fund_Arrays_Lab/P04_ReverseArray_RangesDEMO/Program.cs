
string[] input = Console.ReadLine().Split();
for (int i = 0; i < input.Length/2; i++)
{
    string temp = input[i];
    input[i] = input[^(1+i)];
    input[^(1 + i)] = temp;
}
Console.WriteLine(string.Join(' ', input));