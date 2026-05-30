using System.Threading;
using Cysharp.Threading.Tasks;
public interface IState 
{
    UniTask EnterAsync(CancellationToken ct);
    UniTask ExitAsync(CancellationToken ct);
}
