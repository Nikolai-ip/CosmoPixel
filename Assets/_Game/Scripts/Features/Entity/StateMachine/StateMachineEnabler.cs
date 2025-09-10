using _Game.Scripts.Common;
using _Game.Scripts.Core.StateMachine;
using _Game.Scripts.Features.Entity.StateMachine.States;

namespace _Game.Scripts.Features.Entity.StateMachine
{
    public class StateMachineEnabler : IEnableable
    {
        private StateMachineBase _sm;
        
        public StateMachineEnabler(StateMachineBase sm)=> _sm = sm;
        public void Enable()
        {
            _sm.Enter<IdleState>();
        }

        public void Disable()
        {
            _sm.Enter<DisabledStateMachineState>();
        }
    }
}