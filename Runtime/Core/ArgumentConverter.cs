using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ArgumentConverter : ScriptableObject
{
    public object Convert(object data)
    {

        if(data is EventAssetArgument)
        {
            return DoConvert(((EventAssetArgument)data).data);
        } else
        {
            return DoConvert(data);
        }
    }



    protected abstract object DoConvert(object data);

}
