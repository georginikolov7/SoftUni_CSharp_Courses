

using ShoppingSpree;
using System.Collections.Generic;

public class StartUp
{
    static void Main()
    {
        Func<string, decimal, Person> personCreator = (name, money) => new Person(name, money);
        Func<string, decimal, Product> productCreator = (name, cost) => new Product(name, cost);
        try
        {
            string[] peopleInput = Console.ReadLine().Split(";",StringSplitOptions.RemoveEmptyEntries);
            List<Person> people = FillList<Person>(peopleInput, personCreator);
            string[] productsInput = Console.ReadLine().Split(";",StringSplitOptions.RemoveEmptyEntries);
            List<Product> products = FillList<Product>(productsInput, productCreator);

            string command;
            while ((command = Console.ReadLine()) != "END")
            {
                string[] tokens = command.Split(" ");
                string name = tokens[0];
                string productName = tokens[1];
                people.FirstOrDefault(x => x.Name == name).BuyProduct(products.FirstOrDefault(x => x.Name == productName));

            }

            foreach (var person in people)
            {
                person.PrintProducts();
            }

        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            return;
        }
    }
    private static List<T> FillList<T>(string[] inputData, Func<string, decimal, T> Tcreator)
    {
        List<T> list = new();
        foreach (string input in inputData)
        {
            string[] arguments = input.Split("=");
            T currentObj = Tcreator(arguments[0], decimal.Parse(arguments[1]));
            list.Add(currentObj);
        }
        return list;
    }
}