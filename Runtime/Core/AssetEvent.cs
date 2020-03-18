using System;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct ChainedEvent
{
    [Tooltip("Leave empty if you want to propagate original parameter")]
    public VarAsset var;
    public ArgumentConverter converter;
    public AssetEvent _event;
}

[CreateAssetMenu(menuName = "Scriptable Goodies/Asset Event")]
public class AssetEvent : ScriptableObject
{

    public VarAsset var = null;

    [SerializeField] List<ChainedEvent> chainedEvents = new List<ChainedEvent>();

    private readonly List<ListenerElement> _listeners = new List<ListenerElement>();

#if UNITY_EDITOR
    
    public List<ListenerElement> EventListeners => _listeners;
#endif

    public void RegisterListener(ListenerElement listener)
    {
        if (!_listeners.Contains(listener))
            _listeners.Add(listener);
    }
    
    public void UnregisterListener(ListenerElement listener)
    {
        if (_listeners.Contains(listener))
            _listeners.Remove(listener);
    }

    public void RaiseWithVar()
    {
        Raise(var);
    }

    public void Raise()
    {
        Raise(new EventAssetArgument());
    }

    public void Raise(object data = null, Action<object> successCallback = null, Action<object> failCallback = null, Action<object> updateCallback = null)
    {
        Raise(new EventAssetArgument(data, successCallback, failCallback, updateCallback));
    }

    public void Raise(VarAsset varAsset)
    {
        Raise(varAsset.GetValue());
    }

    public void Raise(string str)
    {
        Raise(str as object);
    }

    public void Raise(object data)
    {
        if (data is EventAssetArgument) 
        {
            Raise(data as EventAssetArgument);
        }
        else
        {
            Raise(new EventAssetArgument { data = data });
        }
    }

    public void Raise(EventAssetArgument arg)
    {

#if EVENTS_LOG
        object data = arg.data;
        Debug.Log($"<color=blue>EventAsset</color> raised: <color=yellow>{name}</color>, " +
            $"\n parameter: <color=green>{data}</color>", this);
#endif

        for (int i = _listeners.Count - 1; i >= 0; i--)
        {
            _listeners[i].OnEventRaised(arg);
        }

        foreach (var ec in chainedEvents)
        {
            if(ec.var == null)
            {
                /// if a chained event has a converter,
                /// it will be used to convert and/or modify passed parameter
                if(ec.converter != null)
                {
                    ec._event.Raise(new EventAssetArgument(arg, ec.converter.Convert(arg.data)));
                }
                else
                {
                    ec._event.Raise(arg);
                }
            } 
            else
            {
                /// if a chained event has its own VarAsset, 
                /// it will override the parameter
                ec._event.Raise(new EventAssetArgument(arg, ec.var.GetValue()));
            }
        }
    }

}
