using System;
using UnityEngine;

public class GenericEvent<T>
{
    public event EventHandler<T> onEventCalled;
    public void callEvent(T param) => onEventCalled?.Invoke(this, param);
}
