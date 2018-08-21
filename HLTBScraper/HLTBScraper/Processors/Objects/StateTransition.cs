using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HLTBScraper.Processors.Objects
{
    internal class StateTransition
    {
        public ProcessState CurrentState { get; set; }
        public StateCommand Command { get; set; }

        public StateTransition(ProcessState currentState, StateCommand command)
        {
            this.CurrentState = currentState;
            this.Command = command;
        }
        public override int GetHashCode()
        {
            return 17 + 31 * CurrentState.GetHashCode() + 31 * Command.GetHashCode();
        }
        public override bool Equals(object obj)
        {
            StateTransition other = (StateTransition)obj;
            return other != null && this.CurrentState == other.CurrentState && this.Command == other.Command;
        }
    }
}
