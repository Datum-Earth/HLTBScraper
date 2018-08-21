using HLTBScraper.Objects;
using HLTBScraper.Processors.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HLTBScraper.Processors
{
    internal class StateProcessor
    {
        private MachineCore core;
        private bool IsFinished;
        public GameData GameInformation { get; }

        public StateProcessor(string startState, IEnumerable<StateTransition> transitions)
        {
            //core = new MachineCore(startState, transitions);
            //IsFinished = false;
            //GameInformation = new GameData();
        }

        public void Enumerate()
        {
            
        }
        
        private void EnumerationFinished()
        {
            IsFinished = true;
        }

        private void DrillNode(ref GameData gameData)
        {

        }

        private void GenerateStateTransitions()
        {
            var trans = new List<StateTransition>()
            {
            };
        }
    }
}
