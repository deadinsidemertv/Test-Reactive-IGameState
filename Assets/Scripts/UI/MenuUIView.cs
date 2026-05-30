using UnityEngine;
using UnityEngine.UI;
using System;

public class MenuUIView : MonoBehaviour
{
    [SerializeField] private Button _restartButton;

    private Action _onRestart;

    public void Initialize(Action onRestart)
    {
        gameObject.SetActive(true);
        _onRestart = onRestart;
        _restartButton.onClick.AddListener(() => _onRestart?.Invoke());
    }

    public void Release()
    {
        gameObject.SetActive(false);
        _restartButton.onClick.RemoveAllListeners();
    }
}
