using _Game.Scripts.Core.Events;
using UnityEngine.InputSystem;

namespace _Game.Scripts.Features.Entity.StateMachine.Signals
{
    public class InputSignal: ISignal
    {
        public InputActionPhase Phase { get; set; }

    }
}