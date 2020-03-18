using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Scriptable Goodies/Vars/String")]
public class StringVar : VarAsset
{
    [SerializeField] string val;
    public override object GetValue()
    {
        return val;
    }

    public override void SetValue(object obj)
    {
        if (obj is string) val = (string)obj;
    }

    public static implicit operator string(StringVar stringVar)
    {
        return stringVar.val;
    }
}