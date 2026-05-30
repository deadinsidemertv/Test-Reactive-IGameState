using System;
using System.Collections.Generic;

public class ReactiveValue<T>  //дженерик класс
{
    private T _value; //Значение

    private readonly List<Action<T>> _subscribes = new List<Action<T>>(); //Лист методов

    public T Value //прокси свойство
    {
        get => _value; //при обращении перенаправляем к приватному _value
        set
        {
            _value = value;   //При обращении перенаправляем
            foreach(var sub in _subscribes)   //Для каждого метода в листе подписок
            {
                sub(value);                   //вызываем с параметром value
            }
        }
    }

    public IDisposable Subscribe(Action<T> callback, bool invokeImmediately = true)
    {
        _subscribes.Add(callback);
        if (invokeImmediately)
            callback(_value);
        return new Subscription(() => _subscribes.Remove(callback));
    }

    private class Subscription : IDisposable
    {
        private readonly Action _onDispose;
        public Subscription(Action onDispose) => _onDispose = onDispose;
        public void Dispose() => _onDispose();
    }
}
