using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ListenerString : MonoBehaviour
{
    public class ListenerElementString : ListenerElement
    {
        public StringUnityEvent stringResponce;
        protected override void CastedHandler(object data)
        {
            stringResponce?.Invoke(data as string);
        }
    }

    [SerializeField] AssetEvent _assetEvent = null;
    [SerializeField] StringUnityEvent _handlers = null;

    private ListenerElementString _element;

    private void OnEnable()
    {
        _element = new ListenerElementString
        {
            eventAsset = _assetEvent,
            stringResponce = _handlers
        };
        _assetEvent.RegisterListener(_element);
    }

    private void OnDisable()
    {
        _assetEvent.UnregisterListener(_element);
    }
}
