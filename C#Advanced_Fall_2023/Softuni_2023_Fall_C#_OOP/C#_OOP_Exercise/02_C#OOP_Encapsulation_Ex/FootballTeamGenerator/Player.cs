using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballTeamGenerator
{
    public class Player
    {
        private const string WrongStatDataMessage = "{0} should be between 0 and 100.";
        private int endurance;
        private int sprint;
        private int dribble;
        private int passing;
        private int shooting;
        private string name;

        public Player(string name, int endurance, int sprint, int dribble, int passing, int shooting)
        {
            Name = name;
            Endurance = endurance;
            Sprint = sprint;
            Dribble = dribble;
            Passing = passing;
            Shooting = shooting;
        }

        public string Name
        {
            get { return name; }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("A name should not be empty.");

                }
                name = value;
            }
        }

        public int Endurance
        {
            get => endurance;
            set
            {
                if (!IsValidStat(value))
                {
                    throw new ArgumentException(string.Format(WrongStatDataMessage, nameof(Endurance)));
                }
                endurance = value;
            }
        }
        public int Sprint
        {
            get => sprint;
            private set
            {

                if (!IsValidStat(value))
                {
                    throw new ArgumentException(string.Format(WrongStatDataMessage, nameof(Sprint)));
                }
                sprint = value;
            }
        }
        public int Dribble
        {
            get => dribble;
            private set
            {

                if (!IsValidStat(value))
                {
                    throw new ArgumentException(string.Format(WrongStatDataMessage, nameof(Dribble)));
                }
                dribble = value;
            }
        }

        public int Passing
        {
            get => passing;
            private set
            {

                if (!IsValidStat(value))
                {
                    throw new ArgumentException(string.Format(WrongStatDataMessage, nameof(Passing)));
                }
                passing = value;
            }
        }
        public int Shooting
        {
            get => shooting;
            private set
            {
                if (!IsValidStat(value))
                {
                    throw new ArgumentException(string.Format(WrongStatDataMessage, nameof(Shooting)));
                }
                shooting = value;
            }
        }



        public int SkillLevel
        {
            get
            {
                return (int)Math.Round((endurance + sprint + dribble + passing + shooting) / 5.0);
            }
        }
        private bool IsValidStat(int value)
        {
            return value >= 0 && value <= 100;
        }
    }
}
