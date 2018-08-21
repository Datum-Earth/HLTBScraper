using HLTBScraper.Processors.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HLTBScraper.Processors
{
    internal class MachineCore
    {
        public ProcessState CurrentState;
        private Dictionary<StateTransition, ProcessState> Transitions;
        public bool IsFinished;

        public MachineCore(ProcessState startState, Dictionary<StateTransition, ProcessState> stateTransitions)
        {
            CurrentState = startState;
            Transitions = stateTransitions;
        }

        public ProcessState GetNext(StateCommand command)
        {
            StateTransition trans = new StateTransition(CurrentState, command);
            ProcessState ret = Transitions[trans];
            return ret;
        }

        public void MoveNext(StateCommand command)
        {
            if (CurrentState == ProcessState.Terminated)
                return;

            CurrentState = GetNext(command);
        }
    }
}
