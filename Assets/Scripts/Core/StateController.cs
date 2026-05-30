using Cysharp.Threading.Tasks;
using System.Threading;
using UnityEngine;

public class StateController 
{
    private IState _currentState;
    private CancellationTokenSource _cts = new();

    public async UniTask EnterStateAsync(IState newState)
    {
        var ct = _cts.Token;

        if (_currentState != null)
            await _currentState.ExitAsync(ct);

        _currentState = newState;
        await _currentState.EnterAsync(ct);
    }

}
