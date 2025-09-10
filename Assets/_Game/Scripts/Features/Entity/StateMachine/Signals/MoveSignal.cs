using _Game.Scripts.Features.Entity.StateMachine.States;

namespace _Game.Scripts.Features.Entity.StateMachine.Signals
{
    public class MoveSignal: InputSignal
    {
        public MoveParams MoveParams { get; set; } = new();

    }
}