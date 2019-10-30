using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName ="Scriptable Goodies/Event Asset")]
public class EventAsset : ScriptableObject
{

    public List<VarAsset> vars;
    public object var;
    public T GetFirstVar<T>() where T : VarAsset
    {
        if(vars.Count == 0)
        {
            return default;
        } else
        {
            return (T)vars[0];
        }
    }

    /// <summary>
    /// The list of listeners that this event will notify if it is raised.
    /// </summary>
    private readonly List<EventAssetListener> eventListeners =
        new List<EventAssetListener>();

    [ContextMenu("Raise")]
    public void Raise()
    {
        for (int i = eventListeners.Count - 1; i >= 0; i--)
            eventListeners[i].OnEventRaised(this);
    }

    public void Raise(List<VarAsset> vars)
    {
        if(vars != null)
        {
            int currentCount = this.vars.Count;
            for (int i = 0; i < vars.Count; i++)
            {
                if(i<currentCount)
                {
                    this.vars[i] = vars[i];
                } else
                {
                    this.vars.Add(vars[i]);
                }
            }
        }
        Raise();
    }

    public void Raise(VarAsset var)
    {
        if (vars.Count == 0) vars.Add(var);
        else vars[0] = var;
        Raise();
    }

    public void Raise(object var)
    {
        this.var = var;
        Raise();
    }

    public void RegisterListener(EventAssetListener listener)
    {
        if (!eventListeners.Contains(listener))
            eventListeners.Add(listener);
    }

    public void UnregisterListener(EventAssetListener listener)
    {
        if (eventListeners.Contains(listener))
            eventListeners.Remove(listener);
    }
}
