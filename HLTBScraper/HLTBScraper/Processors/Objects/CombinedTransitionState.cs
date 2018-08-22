using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HLTBScraper.Processors.Objects
{
    internal class CombinedTransitionState
    {
        public int ID { get { return Transition.GetHashCode() + NextState.GetHashCode(); } }
        public StateTransition Transition { get; }
        public ProcessState NextState { get; }

        public CombinedTransitionState(StateTransition trans, ProcessState nextState)
        {
            this.Transition = trans;
            this.NextState = nextState;
        }
    }
}
