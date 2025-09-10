using Zenject;

namespace _Game.Scripts.Common.DI
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