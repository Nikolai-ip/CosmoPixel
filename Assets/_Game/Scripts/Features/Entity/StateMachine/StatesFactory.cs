using System;
using System.Collections.Generic;
using _Game.Scripts.Core.StateMachine;
using UnityEngine;
using Zenject;

namespace _Game.Scripts.Features.Entity.StateMachine
{
    public abstract class StatesFactory: MonoBehaviour, IFactory<Dictionary<Type, IExitableState>>
    {
        public abstract Dictionary<Type, IExitableState> Create();
    }
}