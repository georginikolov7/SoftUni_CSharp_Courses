
Func<string, bool> startsWithUppercase = x => char.IsUpper(x[0]);
string input = Console.ReadLine();
string[] words = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);
words.Where(startsWithUppercase).ToList().ForEach(word =>Console.WriteLine(word));
