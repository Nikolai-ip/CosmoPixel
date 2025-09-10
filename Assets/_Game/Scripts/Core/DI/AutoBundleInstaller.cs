using Zenject;

namespace _Game.Scripts.Core.DI
{
    public class AutoBundleInstaller: MonoInstaller
    {
        public override void InstallBindings()
        {
            foreach (var subInstaller in GetComponentsInChildren<SubInstaller>())
            {
                subInstaller.InstallBindings(Container);
            }
        }
    }
}