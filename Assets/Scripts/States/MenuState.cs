using Cysharp.Threading.Tasks;
using System.Threading;
using UnityEngine;

public class MenuState : IState
{
    private UniTaskCompletionSource _restartTcs;

    public void RequestRestart()
    {
        _restartTcs?.TrySetResult();
    }

    public async UniTask EnterAsync(CancellationToken ct)
    {
        _restartTcs = new UniTaskCompletionSource();
        await _restartTcs.Task;
    }

    public UniTask ExitAsync(CancellationToken ct)
    {
        return UniTask.CompletedTask;
    }
}
