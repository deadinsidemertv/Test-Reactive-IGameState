using UnityEngine;
using VContainer;
using VContainer.Unity;

public class GameLifetimeScope : LifetimeScope
{
    [SerializeField] private LoadingUIView _loadingView;
    [SerializeField] private MenuUIView _menuView;
    protected override void Configure(IContainerBuilder builder)
    {
        builder.RegisterEntryPoint<GameBootstrapper>();
        builder.Register<StateController>(Lifetime.Singleton);
        builder.Register<SplashState>(Lifetime.Singleton);
        builder.Register<LoadState>(Lifetime.Singleton);
        builder.Register<MenuState>(Lifetime.Singleton);
        builder.RegisterInstance(_loadingView);
        builder.RegisterInstance(_menuView);
    }
}
