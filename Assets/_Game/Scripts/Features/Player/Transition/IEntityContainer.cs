using _Game.Scripts.Common;

namespace _Game.Scripts.Features.Player.Transition
{
    public interface IEntityContainer
    {
        IControllableEntity GetEntity();
    }
}