using UnityEngine;
using Zenject;

namespace Lessons.Architecture.PM
{
    public class SceneInstaller : MonoInstaller
    {
        [SerializeField] private ActionHelper actionHelper;
        public override void InstallBindings()
        {
            Container.Bind<PlayerPool>().AsSingle().NonLazy();
            Container.Bind<PresenterFactory>().AsSingle().NonLazy();
            Container.Bind<XPController>().AsSingle().NonLazy();
            Container.BindInterfacesAndSelfTo<StatsController>().AsSingle().WithArguments(actionHelper).NonLazy();
        }
    }

}