namespace P07_CompanyUsers
{
    class Company
    {
        public Company(string name, List<string> ids)
        {
            Name = name;
            Ids = ids;
        }

        public string Name { get; set; }
        public List<string> Ids { get; set; }
        public void PrintNames()
        {
            foreach (string id in Ids)
            {
                Console.WriteLine($"-- {id}");
            }
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            var companies = new Dictionary<string, Company>();
            string input;
            while ((input = Console.ReadLine()) != "End")
            {
                string[] arguments = input
                    .Split(" -> ");
                string companyName = arguments[0];
                string userId= arguments[1];
                if (!companies.ContainsKey(companyName))
                {
                    companies.Add(companyName, new Company(companyName, new List<string>()));
                }

                if (!companies[companyName].Ids.Contains(userId))
                {
                    companies[companyName].Ids.Add(userId);
                }
            }
            foreach(Company company in companies.Values)
            {
                Console.WriteLine(company.Name);
                company.PrintNames();
            }
        }
    }
}