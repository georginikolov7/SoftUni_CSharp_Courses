char input = char.Parse(Console.ReadLine());
if (input >= 'a' && input <= 'z')
{
    Console.WriteLine("lower-case");
}
else if(input >='A'&&input <= 'Z')
    Console.WriteLine("upper-case");
