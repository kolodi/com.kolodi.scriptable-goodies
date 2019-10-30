using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EventAssetListener : MonoBehaviour
{

    [Tooltip("Event to register with.")]
    public EventAsset Event;

    private void OnEnable()
    {
        Event.RegisterListener(this);
    }

    private void OnDisable()
    {
        Event.UnregisterListener(this);
    }

    public virtual void OnEventRaised(EventAsset eventAsset)
    {
        
    }


}
