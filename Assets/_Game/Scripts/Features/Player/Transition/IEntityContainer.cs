using System.Collections.Generic;
using _Game.Scripts.Common;

namespace _Game.Scripts.Features.Player.Transition
{
    public interface IEntityBuffer
    {
        public List<IControllableEntity> EntityBuffer { get; set; }
    }
    public interface IEntityContainer
    {
        bool TryGetEntity(out IControllableEntity entity);
        bool TryAddEntity(IControllableEntity entity);
        bool TryRemove(IControllableEntity component);
    }
}