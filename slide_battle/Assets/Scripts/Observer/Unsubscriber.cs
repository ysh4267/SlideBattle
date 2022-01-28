using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unsubscriber<T> : IDisposable {
    private List<IObserver<T>> Observers;
    private IObserver<T> Observer;

    internal Unsubscriber(List<IObserver<T>> observers, IObserver<T> observer) {
        Observers = observers;
        Observer = observer;
    }

    public void Dispose() {
        if (true == Observers.Contains(Observer)) {
            Observers.Remove(Observer);
        }
    }
}
