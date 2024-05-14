using System.Collections.Generic;

namespace P03.DetailPrinter
{
    class Program
    {
        static void Main()
        {
            List<Employee> employees = new List<Employee>
            {
                new Employee("Dimitrichko"),
                new Manager("Peshoolu",new List<string> { "doc1","doc2"})

            };
            DetailsPrinter printer = new DetailsPrinter(employees);
            printer.PrintDetails();
        }
    }
}
