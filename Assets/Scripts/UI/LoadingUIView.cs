using System;
using UnityEngine;
using UnityEngine.UI;

public class LoadingUIView : MonoBehaviour
{
    [SerializeField] private Image _progressBar;

    private IDisposable _subscription;

    public void Initialize(LoadState loadState)
    {
        _subscription = loadState.Progress.Subscribe(v =>_progressBar.fillAmount = v);
    }

    public void Release()
    {
        _subscription?.Dispose();
    }
}
