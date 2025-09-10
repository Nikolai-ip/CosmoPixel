using UnityEngine;
using Zenject;

namespace _Game.Scripts.Common.DI
{
    public abstract class SubInstaller: MonoBehaviour
    {
        public abstract void InstallBindings(DiContainer container);
    }
}