using Cysharp.Threading.Tasks;
using System.Threading;
using UnityEngine;

public class SplashState : IState
{
    public async UniTask EnterAsync(CancellationToken ct) 
    {
        await UniTask.Delay(1000, cancellationToken: ct);
    }

    public UniTask ExitAsync(CancellationToken ct) 
    {
        return UniTask.CompletedTask;
    }
}
