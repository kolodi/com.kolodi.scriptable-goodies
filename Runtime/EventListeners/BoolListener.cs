using UnityEngine;
using System.Collections;

public class BoolListener : MonoBehaviour
{

    [SerializeField] BoolUnityEvent Handler;

    public void OnGenericEvent(object arg)
    {
        if(arg is bool)
        {
            Handler.Invoke((bool)arg);
        }
    }
}
