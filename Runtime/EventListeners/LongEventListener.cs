using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LongEventListener : EventAssetListener
{
    public LongUnityEvent Response;

    public override void OnEventRaised(EventAsset eventAsset)
    {
        Response?.Invoke((long)eventAsset.var);
    }
}
