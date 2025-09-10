
using _Game.Scripts.Common;

namespace _Game.Scripts.Features.Player.Transition
{
    public interface IEntityBufferSorter
    {
        void Sort(IEntityBuffer entities, IControllableEntity current);
    }
}