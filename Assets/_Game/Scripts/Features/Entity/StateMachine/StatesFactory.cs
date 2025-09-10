using System.Collections.Generic;
using Zenject;

namespace _Game.Scripts.Features.Entity.StateMachine
{
    internal class StatesFactory: IFactory<Dictionary<Type, IExitableState>>
    {
    }
}