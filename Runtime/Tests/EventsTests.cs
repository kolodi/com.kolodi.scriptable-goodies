using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class EventsTests : MonoBehaviour
{
    [SerializeField] AssetEvent eventWithCallbacks = null;

    public void CallbackTestHandler(object data)
    {
        if (data is EventAssetArgument)
        {
            EventAssetArgument arg = (EventAssetArgument)data;

            StartCoroutine(DelayedAction(() =>
            {
                arg.successCallback?.Invoke("Success data arrived after 1 second");

            }, 1));
            StartCoroutine(DelayedAction(() =>
            {
                arg.failCallback?.Invoke("successfully failed after 2 second :)");
            }));
        }
    }

    IEnumerator DelayedAction(Action action, float delay = 2)
    {
        yield return new WaitForSeconds(delay);
        action.Invoke();
    }

    [ContextMenu("Callback Tests")]
    void CallbackTests()
    {
        EventAssetArgument arg = new EventAssetArgument
        {
            data = "Hello",
            successCallback = data =>
            {
                Debug.Log(data);
            },
            failCallback = error =>
            {
                Debug.Log(error);
            }
        };

        eventWithCallbacks.Raise(arg);
    }
}
