using System;
using UnityEngine;

[Serializable]
public class EventAssetArgument : EventArgs
{
    public object data;
    public Action<object> successCallback;
    public Action<object> failCallback;
    public Action<object> updateCallback;

    public EventAssetArgument (object data = null, Action<object> successCallback = null, Action<object> failCallback = null, Action<object> updateCallback = null)
    {
        this.data = data;
        this.successCallback = successCallback;
        this.failCallback = failCallback;
        this.updateCallback = updateCallback;
    }

    /// <summary>
    /// Create a new argument from original,
    /// copy all callbacks but use new data
    /// </summary>
    /// <param name="original">Original argument to copy callbacks from</param>
    /// <param name="data">new data</param>
    public EventAssetArgument(EventAssetArgument original, object data = null)
    {
        this.data = data ?? original.data;
        this.successCallback = original.successCallback;
        this.failCallback = original.failCallback;
        this.updateCallback = original.updateCallback;
    }

    public T GetData<T>()
    {
        if (data is T) return (T)data;
        return default;
    }


    public override string ToString()
    {
        return $"{data.ToString()} | success callback: {successCallback != null} | fail callback: {failCallback != null}";
    }
}
