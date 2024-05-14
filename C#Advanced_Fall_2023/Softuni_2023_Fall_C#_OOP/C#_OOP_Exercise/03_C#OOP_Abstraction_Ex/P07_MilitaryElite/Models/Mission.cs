using P07_MilitaryElite.Enums;
using P07_MilitaryElite.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P07_MilitaryElite.Models
{
    public class Mission : IMission
    {
        public Mission(string codeName, State state)
        {
            CodeName = codeName;
            State = state;
        }

        public string CodeName { get; private set; }

        public State State { get; private set; }

        public void CompleteMission()
        {
            State = State.Finished;
        }
        public override string ToString()
        {
            return $"Code Name: {CodeName} State: {State}";
        }
    }
}
