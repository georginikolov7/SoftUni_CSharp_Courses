

using P04_Pizza;

//Read pizza name:
try
{    
      
    string[] pizzaTokens = Console.ReadLine().Split();
    string pizzaName = pizzaTokens[1];

    string[] doughTokens = Console.ReadLine().Split();
    Dough dough = new(doughTokens[1], doughTokens[2], double.Parse(doughTokens[3]));
    Pizza pizza = new(pizzaName, dough);

    string input;
    while ((input = Console.ReadLine()) != "END")
    {
        string[] toppingTokens = input.Split();
        Topping topping = new(toppingTokens[1], double.Parse(toppingTokens[2]));
        pizza.AddTopping(topping);
    }
    Console.WriteLine(pizza);
}
catch(Exception ex)
{
    Console.WriteLine(ex.Message);
}