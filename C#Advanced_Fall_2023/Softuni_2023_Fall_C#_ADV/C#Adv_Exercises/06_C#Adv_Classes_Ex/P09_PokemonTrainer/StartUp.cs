namespace P09_PokemonTrainer
{
    public class StartUp
    {
        static void Main()
        {
            Dictionary<string, Trainer> trainers = new();
            string command;
            while ((command = Console.ReadLine()) != "Tournament")
            {
                //"{trainerName} {pokemonName} {pokemonElement} {pokemonHealth}"
                string[] tokens = command.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string trainerName = tokens[0];
                string pokemonName = tokens[1];
                string pokemonElement = tokens[2];
                int pokemonHealth = int.Parse(tokens[3]);
                if (!trainers.ContainsKey(trainerName))
                {
                    trainers.Add(trainerName, new Trainer(trainerName));
                }
                Pokemon pokemon=new(pokemonName,pokemonElement,pokemonHealth);
                trainers[trainerName].AddPokemon(pokemon);
            }
            while((command = Console.ReadLine()) != "End")
            {
                foreach (var trainer in trainers)
                {
                    if (trainer.Value.Pokemons.Values.Any(p => p.Element == command))
                    {
                        trainer.Value.NumberOfBadges++;
                    }
                    else
                    {
                        foreach(var pokemon in trainer.Value.Pokemons.Values)
                        {
                            pokemon.Health -= 10;
                            if(pokemon.Health <= 0)
                            {
                                trainer.Value.Pokemons.Remove(pokemon.Name);
                            }
                        }
                    }
                }
            }

            foreach (var trainer in trainers.OrderByDescending(x => x.Value.NumberOfBadges))
            {
                Console.WriteLine(trainer.Value.ToString());
            }
        }
    }
}