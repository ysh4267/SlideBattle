using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public abstract class ObserverContainer<T> : MonoBehaviour, IObserver<T> {
    public virtual void OnCompleted() {
        throw new NotImplementedException();
    }

    public virtual void OnError(Exception error) {
        throw new NotImplementedException();
    }

    public abstract void OnNext(T value);
}
