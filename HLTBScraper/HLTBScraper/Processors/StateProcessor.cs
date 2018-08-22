using HLTBScraper.Objects;
using HLTBScraper.Processors.Maps;
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
        private readonly MachineCore Core;
        public bool IsFinished;
        private ProcessorMap Map { get; }
        private Dictionary<StateTransition, ProcessState> Transitions { get; }

        public StateProcessor(ProcessState startState)
        {
            this.Transitions = GenerateStateTransitions();
            this.Map = new ProcessorMap();
            this.IsFinished = false;

            this.Core = new MachineCore(startState, Transitions);
        }

        public void Enumerate(ref GameData gameData)
        {
            var startMovement = StateCommand.Forward;

            while (this.IsFinished == false)
            {
                DrillNode(ref gameData, ref startMovement);
                Console.ReadLine();
            }
        }
        
        private void DrillNode(ref GameData gameData, ref StateCommand movement)
        {
            var currentState = Core.CurrentState;

            // if our state is terminated, exit
            if (currentState == ProcessState.Terminated)
                this.IsFinished = true;

            // do our work here
            var thingToDo = Map.GetValues(currentState);
            Console.WriteLine(thingToDo.NextCommand.ToString() + ' ' + String.Join(", ", thingToDo.Values) + ' ' + Core.CurrentState);
            movement = thingToDo.NextCommand;

            // tell the state machine to transition, and run our method again
            Core.MoveNext(movement);
            DrillNode(ref gameData, ref movement);
            
        }

        private Dictionary<StateTransition, ProcessState> GenerateStateTransitions()
        {
            var trans = new Dictionary<StateTransition, ProcessState>()
            {
                { new StateTransition(ProcessState.Start, StateCommand.Forward), ProcessState.MainTables },
                { new StateTransition(ProcessState.Start, StateCommand.Backward), ProcessState.Terminated },
                { new StateTransition(ProcessState.MainTables, StateCommand.Forward), ProcessState.BodyTables },
                { new StateTransition(ProcessState.MainTables, StateCommand.Backward), ProcessState.Terminated },
                { new StateTransition(ProcessState.BodyTables, StateCommand.Forward), ProcessState.Rows },
                { new StateTransition(ProcessState.BodyTables, StateCommand.Backward), ProcessState.MainTables},
                { new StateTransition(ProcessState.Rows, StateCommand.Forward), ProcessState.Elements },
                { new StateTransition(ProcessState.Rows, StateCommand.Backward), ProcessState.BodyTables },
                { new StateTransition(ProcessState.Elements, StateCommand.Forward), ProcessState.Rows },
                { new StateTransition(ProcessState.Elements, StateCommand.Backward), ProcessState.Rows }
            };

            return trans;
        }
    }
}
