using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName ="Scriptable Goodies/Converters/String To Direction Converter", fileName = "String To Direction Converter")]
public class StringToDirectionConverter : ArgumentConverter
{
    protected override object DoConvert(object data)
    {
        string directionWord = (string)data;
        switch (directionWord.ToLower())
        {
            case "up":
                return Vector3.up;
            case "down":
                return Vector3.down;
            case "left":
                return Vector3.left;
            case "right":
                return Vector3.right;
            case "forward":
                return Vector3.forward;
            case "backward":
                return Vector3.back;
            default:
                return Vector3.zero;
        }
    }
}
