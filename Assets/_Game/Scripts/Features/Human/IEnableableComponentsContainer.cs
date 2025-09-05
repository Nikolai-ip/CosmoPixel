using System.Collections.Generic;
using _Game.Scripts.Common;

namespace _Game.Scripts.Features.Human
{
    public interface IEnableableComponentsContainer
    {
        void SetComponents(List<IEnableable> enableableComponents);
    }
}