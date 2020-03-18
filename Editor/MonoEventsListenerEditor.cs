using UnityEditor;
using Malee.Editor;

[CustomEditor(typeof(EventsListener))]
public class MonoEventsListenerEditor : Editor
{
    private ReorderableList listenerElements;

    private void OnEnable()
    {
        listenerElements = new ReorderableList(serializedObject.FindProperty("listeners"));
    }

    public override void OnInspectorGUI()
    {
        //base.OnInspectorGUI();

        serializedObject.Update();
        listenerElements.DoLayoutList();
        serializedObject.ApplyModifiedProperties();
    }
}

