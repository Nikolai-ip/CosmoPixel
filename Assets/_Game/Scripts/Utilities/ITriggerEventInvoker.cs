using System;
using UnityEngine;

namespace _Game.Scripts.Utilities
{
    public interface ITriggerEventInvoker
    {
        event Action<Collider2D> OnTriggerEnter;
        event Action<Collider2D> OnTriggerExit;
        event Action<Collider2D> OnTriggerStay;
    }
}