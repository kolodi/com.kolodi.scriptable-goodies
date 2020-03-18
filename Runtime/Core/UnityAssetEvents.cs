using UnityEngine;
using UnityEngine.Events;

[System.Serializable]
public class IntUnityEvent : UnityEvent<int>
{
    
}

[System.Serializable]
public class LongUnityEvent : UnityEvent<long>
{

}

[System.Serializable]
public class FloatUnityEvent : UnityEvent<float>
{

}

[System.Serializable]
public class StringUnityEvent : UnityEvent<string>
{

}

[System.Serializable]
public class BoolUnityEvent : UnityEvent<bool>
{

}
[System.Serializable]
public class ObjectUnityEvent : UnityEvent<object>
{

}

[System.Serializable]
public class Vector3UnityEvent : UnityEvent<Vector3>
{

}

[System.Serializable]
public class EventAssetsArgsUnityEvent : UnityEvent<EventAssetArgument>
{ 

}
