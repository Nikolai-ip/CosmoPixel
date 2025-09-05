using System.Collections.Generic;

namespace _Game.Scripts.Common
{
    public interface IEnableableComponentsContainer
    {
        void SetComponents(List<IEnableable> enableableComponents);
    }
}