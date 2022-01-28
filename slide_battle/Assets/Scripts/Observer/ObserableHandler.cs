using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObserableHandler<T> : IObservable<T> {
    protected List<IObserver<T>> Observers;
    protected T Information;

    public ObserableHandler() {
        Observers = new List<IObserver<T>>();
    }

    public IDisposable Subscribe(IObserver<T> observer) {
        if (false == Observers.Contains(observer)) {
            Observers.Add(observer);
            observer.OnNext(Information);
        }
        return new Unsubscriber<T>(Observers, observer);
    }

    public void NotifyObservers() {
        foreach (var it in Observers) {
            it.OnNext(Information);
        }
    }
}