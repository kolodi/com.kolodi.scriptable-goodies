using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoolEventListener : EventAssetListener
{
    public BoolUnityEvent Response;

    public override void OnEventRaised(EventAsset eventAsset)
    {
        Response?.Invoke((bool)eventAsset.var);
    }
}
