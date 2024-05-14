using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P09_PokemonTrainer
{
    public class Trainer
    {
        private string name;
        private int numberOfBadges;
        private Dictionary<string, Pokemon> pokemons;
        public Trainer(string name)
        {
            Name = name;
            Pokemons = new Dictionary<string, Pokemon>();
        }
        public Dictionary<string, Pokemon> Pokemons
        {
            get { return pokemons; }
            set { pokemons = value; }
        }

        public int NumberOfBadges
        {
            get { return numberOfBadges; }
            set { numberOfBadges = value; }
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        public void AddPokemon(Pokemon pokemon)
        {
            if (!pokemons.ContainsKey(pokemon.Name))
            {
                pokemons.Add(pokemon.Name, pokemon);
            }
        }
        public override string ToString()
        {
            return $"{Name} {NumberOfBadges} {Pokemons.Count}";
        }
    }
}
