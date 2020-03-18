using UnityEngine;

public class ScriptableEventsMonoHelper : MonoBehaviour
{
    private static ScriptableEventsMonoHelper _instance;

    public CollectionEventsManager systems;
    public EventsListener evnetsListener;

    private void Awake()
    {
        if (_instance != null) return;

        foreach (var s in systems.systems)
        {
            foreach (var l in s.listeners)
            {
                l.eventAsset.RegisterListener(l);
            }
        }

        DontDestroyOnLoad(this.gameObject);
        _instance = this;
    }

    void OnDisbale()
    {
        foreach (var s in systems.systems)
        {
            foreach (var l in s.listeners)
            {
                l.eventAsset.UnregisterListener(l);
            }
        }
    }
}
