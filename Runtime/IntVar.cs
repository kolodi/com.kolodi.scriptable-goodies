using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Scriptable Goodies/Vars/Int")]
public class IntVar : VarAsset
{
    [SerializeField] int val;

    public override object GetValue()
    {
        return val;
    }

    public override void SetValue(object obj)
    {
        if (obj is int)
            val = (int)obj;
        else
            Debug.Log("Can't set IntVar, the input value is not integer");
    }

    public static implicit operator int (IntVar intVar)
    {
        return (int)intVar.val;
    }
}
