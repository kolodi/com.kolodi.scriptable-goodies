using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ListenerVector3 : MonoBehaviour
{
    public class ListenerElementVector3 : ListenerElement
    {
        public Vector3UnityEvent responce;
        protected override void CastedHandler(object data)
        {
            responce?.Invoke((Vector3)data);
        }
    }

    [SerializeField] AssetEvent _assetEvent = null;
    [SerializeField] Vector3UnityEvent _handlers = null;

    private ListenerElement _element;

    private void OnEnable()
    {
        _element = new ListenerElementVector3
        {
            eventAsset = _assetEvent,
            responce = _handlers
        };
        _assetEvent.RegisterListener(_element);
    }

    private void OnDisable()
    {
        _assetEvent.UnregisterListener(_element);
    }
}
