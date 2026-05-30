using Cysharp.Threading.Tasks;
using System.Threading;
using Unity.VisualScripting;
using UnityEngine;
using VContainer.Unity;

public class GameBootstrapper : IAsyncStartable
{
    private readonly StateController _states;
    private readonly SplashState _splash;
    private readonly LoadState _load;
    private readonly MenuState _menu;
    private readonly LoadingUIView _loadingView;
    private readonly MenuUIView _menuUIView;

    public GameBootstrapper(StateController states, SplashState splash,
        LoadState load, LoadingUIView loadingView,
        MenuState menu, MenuUIView menuUIView)
    {
        _states = states;
        _splash = splash;
        _load = load;
        _loadingView = loadingView;
        _menu = menu;
        _menuUIView = menuUIView;
    }

    public async UniTask StartAsync(CancellationToken ct)
    {
        await _states.EnterStateAsync(_splash);
        await RunLoadAsync(ct);

        
    }

    public async UniTask RunLoadAsync(CancellationToken ct)
    {
        _loadingView.Initialize(_load);
        await _states.EnterStateAsync(_load);
        _loadingView.Release();


        _menuUIView.Initialize(() => _menu.RequestRestart());
        await _states.EnterStateAsync(_menu);

        _menuUIView.Release();


        await RunLoadAsync(ct);
    }
}
