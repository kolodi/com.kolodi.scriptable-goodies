using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventsStarter : MonoBehaviour
{
    private static EventsStarter _instance;

    [System.Serializable]
    public struct EventStarter
    {
        public AssetEvent e;
        public float delay;
    }

    [SerializeField] List<EventStarter> startingEvents = new List<EventStarter>();

    private void Awake()
    {
        if (_instance != null) return;

        foreach (var es in startingEvents)
        {
            StartCoroutine(DelayedEventStart(es));
        }

        DontDestroyOnLoad(this.gameObject);
        _instance = this;
    }

    IEnumerator DelayedEventStart(EventStarter es)
    {
        yield return new WaitForSeconds(es.delay);
        if (es.e.var != null) es.e.RaiseWithVar();
        else es.e.Raise();
    }
}
