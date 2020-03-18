using Malee.Editor;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(AssetEvent))]
public class EventAssetEditor : Editor
{
    private ReorderableList listenerElements;

    private void OnEnable()
    {
        listenerElements = new ReorderableList(serializedObject.FindProperty("chainedEvents"));
    }

    public override void OnInspectorGUI()
    {
        AssetEvent obj = (AssetEvent)target;

        serializedObject.Update();

        obj.var = (VarAsset)EditorGUILayout.ObjectField("Default Var", obj.var, typeof(VarAsset), true);

        listenerElements.DoLayoutList();

        if (obj.var != null && GUILayout.Button("RaiseWithVar"))
        {
            obj.RaiseWithVar();
        }

        if (GUILayout.Button("RaiseWithNoParameter"))
        {
            obj.Raise();
        }

        serializedObject.ApplyModifiedProperties();

        #region Debug


        GUILayout.Label("Listeners: ");

        for (int i = 0; i < obj.EventListeners.Count; i++)
        {
            var listener = obj.EventListeners[i];
            GUILayout.Label($"{i}");

            if (listener.argResponse != null)
            {
                GUILayout.Space(10f);
                GUILayout.Label("Arg Responce Handlers: ");
                for (int indx = 0; indx < listener.argResponse.GetPersistentEventCount(); indx++)
                {
                    GUILayout.Space(5f);
                    EditorGUI.BeginDisabledGroup(true);
                    EditorGUILayout.ObjectField("Script:", listener.argResponse.GetPersistentTarget(indx), typeof(Object), false);
                    EditorGUI.EndDisabledGroup();
                    GUILayout.Label($"Method: {listener.argResponse.GetPersistentMethodName(indx)}");
                }
            }

            if (listener.objectResponce != null)
            {
                GUILayout.Space(10f);
                GUILayout.Label("Object Responce Handlers: ");
                for (int indx = 0; indx < listener.objectResponce.GetPersistentEventCount(); indx++)
                {
                    GUILayout.Space(5f);
                    EditorGUI.BeginDisabledGroup(true);
                    EditorGUILayout.ObjectField("Script:", listener.objectResponce.GetPersistentTarget(indx), typeof(Object), false);
                    EditorGUI.EndDisabledGroup();
                    GUILayout.Label($"Method: {listener.objectResponce.GetPersistentMethodName(indx)}");
                }
            }
        }

        #endregion

    }
}
