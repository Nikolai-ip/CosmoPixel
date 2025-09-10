using _Game.Scripts.Core.Events;
using _Game.Scripts.Core.StateMachine;
using _Game.Scripts.Features.Entity.StateMachine.Signals;

namespace _Game.Scripts.Features.Entity.StateMachine.States
{
    public class IdleState: IState, ISignalHandler<MoveSignal>
    {
        private StateMachineBase _sm;
        private IEventBus _inputEventBus;

        public IdleState(IEventBus inputEventBus)
        {
            _inputEventBus = inputEventBus;
        }
        public void SetStateMachine(StateMachineBase sm) => _sm = sm;
        public void Enter()
        {
            _inputEventBus.Subscribe<MoveSignal>(this);
        }

        public void Exit()
        {
            _inputEventBus.Remove<MoveSignal>(this);
        }
        
        public void HandleSignal(MoveSignal signal)
        {
            _sm.Enter<MoveState, MoveParams>(signal.MoveParams);
        }
    }
}