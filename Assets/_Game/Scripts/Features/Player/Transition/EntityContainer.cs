using System.Collections.Generic;
using _Game.Scripts.Common;

namespace _Game.Scripts.Features.Player.Transition
{
    public class EntityContainer: IEntityContainer, IEntityBuffer
    {
        public List<IControllableEntity> EntityBuffer { get; set; }
        public EntityContainer(List<IControllableEntity> entityBuffer)
        {
            EntityBuffer = entityBuffer;
        }

        public bool TryAddEntity(IControllableEntity entity)
        {
            if (EntityBuffer.Contains(entity))
                return false;
            
            EntityBuffer.Add(entity);
            return true;
        }

        public bool TryRemove(IControllableEntity component)
        {
            return EntityBuffer.Remove(component);
        }

        public void SetEntityLastPosition(IControllableEntity currentEntity)
        {
            EntityBuffer.Remove(currentEntity);
            EntityBuffer.Add(currentEntity);
        }

        public bool TryGetEntity(out IControllableEntity entity)
        {
            if (EntityBuffer.Count > 0)
            {
                entity = EntityBuffer[0];
                return true;
            }
            entity = null;
            return false;
        }
    }
}