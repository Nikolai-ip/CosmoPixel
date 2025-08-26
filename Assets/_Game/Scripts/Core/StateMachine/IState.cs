using Zenject;

namespace _Game.Scripts.Core.StateMachine
{
    public interface IUpdatableState : IState
    {
        void Update();
    }
    public interface IState:IExitableState
    {
        void Enter();
    }
    public interface IPayLoadedState<TPayload>:IExitableState
    {
        void Enter(TPayload payload);
    }

    public interface IExitableState
    {
        void Exit();
    }
}