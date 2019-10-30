using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StringEventListener : EventAssetListener
{
    public StringUnityEvent Response;

    public override void OnEventRaised(EventAsset eventAsset)
    {
        Response?.Invoke(eventAsset.var as string);
    }
}
