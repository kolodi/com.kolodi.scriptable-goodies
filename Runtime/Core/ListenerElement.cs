
[System.Serializable]
public class ListenerElement
{
    public AssetEvent eventAsset;
    public EventAssetsArgsUnityEvent argResponse;
    public ObjectUnityEvent objectResponce;

    public void OnEventRaised(EventAssetArgument argument)
    {
        argResponse?.Invoke(argument);
        objectResponce?.Invoke(argument.data);
        CastedHandler(argument.data);
    }


    protected virtual void CastedHandler(object data)
    {
        // override to invoke custom handler and casted data 
    }

}
