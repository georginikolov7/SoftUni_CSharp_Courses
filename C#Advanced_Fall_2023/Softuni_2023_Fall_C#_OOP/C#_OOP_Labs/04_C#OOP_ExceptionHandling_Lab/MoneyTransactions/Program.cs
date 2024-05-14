


Dictionary<int, double> accountsBalances = new Dictionary<int, double>();
string[] inputLine = Console.ReadLine().Split(",", StringSplitOptions.RemoveEmptyEntries);

//Fill dictionary:
foreach (string input in inputLine)
{
    string[] account = input.Split("-", StringSplitOptions.RemoveEmptyEntries);
    accountsBalances.Add(int.Parse(account[0]), double.Parse(account[1]));
}

string command;
while ((command = Console.ReadLine()) != "End")
{
    string[] tokens = command.Split(" ", StringSplitOptions.RemoveEmptyEntries);
    string action = tokens[0];
    int accountNumber = int.Parse(tokens[1]);
    double value = double.Parse(tokens[2]);
    try
    {
        switch (action)
        {
            case "Deposit":
                accountsBalances[accountNumber] += value;
                break;
            case "Withdraw":
                if (accountsBalances[accountNumber]-value < 0)
                {
                    throw new ArgumentException("Insufficient balance!");
                }
                accountsBalances[accountNumber] -= value;
                break;
            default:
                throw new ArgumentException("Invalid command!");
        }
        Console.WriteLine($"Account {accountNumber} has new balance: {accountsBalances[accountNumber]:f2}");
    }
    catch (ArgumentException ex)
    {
        Console.WriteLine(ex.Message);
    }
    catch (KeyNotFoundException)
    {
        Console.WriteLine("Invalid account!");
    }
    finally
    {
        Console.WriteLine("Enter another command");
    }

}