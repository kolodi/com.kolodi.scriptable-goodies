using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MultipleAssetEventListener : MonoBehaviour
{
    [SerializeField]
    List<EventListenerElement> listeners;

    private void OnEnable()
    {
        foreach (var l in listeners)
        {
            l.eventAsset.RegisterListener(l);
        }
    }

    private void OnDisable()
    {
        foreach (var l in listeners)
        {
            l.eventAsset.UnregisterListener(l);
        }
    }
}
