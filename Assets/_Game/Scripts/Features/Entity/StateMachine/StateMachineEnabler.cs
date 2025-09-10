using System;
using _Game.Scripts.Common;
using _Game.Scripts.Core.StateMachine;
using _Game.Scripts.Features.Entity.StateMachine.States;
using UnityEngine;
using Zenject;

namespace _Game.Scripts.Features.Human
{
    public class StateMachineRunner : IEnableable
    {
        private StateMachineBase _sm;
        
        public StateMachineRunner(StateMachineBase sm)=> _sm = sm;
        public void Enable()
        {
            _sm.Enter<IdleState>();
        }

        public void Disable()
        { }
    }
}