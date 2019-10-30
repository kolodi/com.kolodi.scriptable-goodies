[System.Serializable]
public class EventListenerElement
{
    public EventAssetV2 eventAsset;
    public ObjectUnityEvent response;

    public void OnEventRaised(object argument)
    {
        response?.Invoke(argument);
    }
}
