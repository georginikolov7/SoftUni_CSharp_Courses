using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballTeamGenerator
{
    public class Team
    {
        private string name;
        private List<Player> players;
        public Team(string name)
        {
            players = new List<Player>();
            Name = name;
        }
        public string Name
        {
            get { return name; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException("A name should not be empty.");

                }
                name = value;
            }
        }
        public int NumberOfPlayers { get => players.Count; }
        public int Rating
        {
            get
            {
                int rating = 0;
                if (players.Count > 0)
                {
                    rating =(int)Math.Round(players.Sum(p => p.SkillLevel) / (double)players.Count);
                }
                return rating;
            }
        }
        public void AddPlayer(Player player)
        {
            players.Add(player);
        }
        public void RemovePlayer(string playerName)
        {
            if (!players.Exists(p => p.Name == playerName))
            {
                throw new Exception($"Player {playerName} is not in {this.Name} team.");
            }
            int index = players.FindIndex(p => p.Name == playerName);
            players.RemoveAt(index);
        }
    }
}
