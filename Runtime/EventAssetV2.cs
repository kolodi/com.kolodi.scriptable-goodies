using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Scriptable Goodies/Event Asset V2")]
public class EventAssetV2 : ScriptableObject
{
    [SerializeField] VarAsset var;

    private readonly List<EventListenerElement> eventListeners =
        new List<EventListenerElement>();

    public void RegisterListener(EventListenerElement listener)
    {
        if (!eventListeners.Contains(listener))
            eventListeners.Add(listener);
    }

    public void UnregisterListener(EventListenerElement listener)
    {
        if (eventListeners.Contains(listener))
            eventListeners.Remove(listener);
    }

    [ContextMenu("Test Raise")]
    void TestRaise()
    {
        Raise(var);
    }

    public void Raise(VarAsset varAsset)
    {
        Raise(varAsset.GetValue());
    }

    public void Raise(object arg)
    {
        for (int i = eventListeners.Count - 1; i >= 0; i--)
        {
            eventListeners[i].OnEventRaised(arg);
        }
    }

}
