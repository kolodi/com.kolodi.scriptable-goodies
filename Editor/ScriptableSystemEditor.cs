using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using Malee.Editor;

[CustomEditor(typeof(ScriptableSystem), true)]
public class ScriptableSystemEditor : Editor
{
    private ReorderableList listenerElements;

    private void OnEnable()
    {
        listenerElements = new ReorderableList(serializedObject.FindProperty("listeners"));
    }

    public override void OnInspectorGUI()
    {
        serializedObject.Update();
        listenerElements.DoLayoutList();
        DrawPropertiesExcluding(serializedObject, "listeners");
        serializedObject.ApplyModifiedProperties();
    }
}
