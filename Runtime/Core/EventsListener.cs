using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class EventsListener : MonoBehaviour
{
    [SerializeField]
    List<ListenerElement> listeners = new List<ListenerElement>();
    public List<ListenerElement> Listeners => listeners;

    private void OnEnable()
    {
        foreach (var l in listeners)
        {
#if EVENTS_LOG
            l.argResponse.AddListener(DebugListener);
#endif
            l.eventAsset.RegisterListener(l);
        }
    }

    private void OnDisable()
    {
        foreach (var l in listeners)
        {
#if EVENTS_LOG
            l.argResponse.RemoveListener(DebugListener);
#endif
            l.eventAsset.UnregisterListener(l);
        }
    }

#if EVENTS_LOG

    private void DebugListener(object arg)
    {
        Debug.Log($"<color=lightblue>EventListener</color> called on: <color=yellow>{gameObject.name}</color>, " +
            $"\n parameter: <color=green>{arg}</color>", this);

    }

#endif
}
