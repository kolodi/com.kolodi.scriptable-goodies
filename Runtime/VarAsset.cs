using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class VarAsset : ScriptableObject
{    
    public abstract object GetValue();
    public abstract void SetValue(object obj);

}
