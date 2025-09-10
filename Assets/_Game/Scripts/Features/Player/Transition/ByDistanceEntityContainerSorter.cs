using System.Linq;
using _Game.Scripts.Common;
using UnityEngine;

namespace _Game.Scripts.Features.Player.Transition
{
    public class ByDistanceEntityContainerSorter: IEntityBufferSorter
    {
        public void Sort(IEntityBuffer entities, IControllableEntity current)
        {
            if (current == null) return;
            entities.EntityBuffer = entities.EntityBuffer
                .OrderBy(entity=>Vector2.Distance(entity.EntityGameObject.transform.position, current.EntityGameObject.transform.position))
                .ToList();
            entities.EntityBuffer.Remove(current);
            entities.EntityBuffer.Add(current);
        }
    }
}