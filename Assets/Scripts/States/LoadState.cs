using Cysharp.Threading.Tasks;
using System.Threading;
using UnityEngine;

public class LoadState : IState
{
    public ReactiveValue<float> Progress = new();
    public async UniTask EnterAsync(CancellationToken ct)
    {
        for(int i = 0; i <= 5; i++)
        {
            await UniTask.Delay(200,cancellationToken: ct);
            Progress.Value = i / 5f;
        }

        await UniTask.CompletedTask;
    }

    public UniTask ExitAsync(CancellationToken ct)
    {
        return UniTask.CompletedTask;
    }
}
