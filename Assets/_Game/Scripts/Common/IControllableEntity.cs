using System.Collections.Generic;
using UnityEngine;

namespace _Game.Scripts.Common
{
    public interface IControllableEntity: IEnableableComponentsContainer
    {
        void StartControl();
        void StopControl();
        GameObject EntityGameObject { get; }
    }
    public abstract class IControllableEntityMono: MonoBehaviour, IControllableEntity
    {
        public abstract void StartControl();
        public abstract void StopControl();
        public abstract GameObject EntityGameObject { get; }
        public abstract void SetComponents(List<IEnableable> enableableComponents);
    }
}