using P04_BorderControl.Models;
using P04_BorderControl.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace P04_BorderControl.Core
{
    public class Engine
    {
        public void Run()
        {
            IIdentifiable someone;
            List<IIdentifiable> list = new();
            string input;
            while ((input = Console.ReadLine()) != "End")
            {
                string[] tokens = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                if (tokens.Length == 2)
                {
                    //Robot:
                    someone = new Robot(tokens[0], tokens[1]);
                }
                else
                {
                    someone = new Citizen(tokens[0], int.Parse(tokens[1]), tokens[2]);
                }
                list.Add(someone);
            }
            string invalidLastDigits = Console.ReadLine();
            list = ValidateIds(list, invalidLastDigits);

        }

        private List<IIdentifiable> ValidateIds(List<IIdentifiable> list, string invalidLastDigits)
        {
            foreach (IIdentifiable someone in list)
            {
                if (someone.Id.LastIndexOf(invalidLastDigits) == someone.Id.Length - invalidLastDigits.Length)
                {
                    Console.WriteLine(someone.Id);
                }
            }
            return list;
        }
    }
}
