using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntEventListener : EventAssetListener
{
    public IntUnityEvent Response;

    public override void OnEventRaised(EventAsset eventAsset)
    {
        Response?.Invoke(eventAsset.GetFirstVar<IntVar>());
    }
}
    