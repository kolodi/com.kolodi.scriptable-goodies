using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ListenerObject : MonoBehaviour
{
    [SerializeField] AssetEvent _assetEvent = null;
    [SerializeField] ObjectUnityEvent _handlers = null;

    private ListenerElement _element;

    private void OnEnable()
    {
        _element = new ListenerElement
        {
            eventAsset = _assetEvent,
            objectResponce = _handlers
        };
        _assetEvent.RegisterListener(_element);
    }

    private void OnDisable()
    {
        _assetEvent.UnregisterListener(_element);
    }


}
