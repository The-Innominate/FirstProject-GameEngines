using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(menuName = "Events/Int Event")]
public class IntEvent : ScriptableObjectBase
{
    public UnityAction<int> onEventRaised;

    public void RaiseEvent(int value)
    {
        onEventRaised?.Invoke(value);   //The ? is a null check. If onEventRaised is null, it won't try to invoke it.
    }

    public void Subscribe(UnityAction<int> function)
    {
        onEventRaised += function;
    }

    public void Unsubscribe(UnityAction<int> function)
    {
        onEventRaised -= function;
    }
}
