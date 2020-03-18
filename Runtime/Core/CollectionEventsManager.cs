using Malee;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName ="Scriptable Goodies/Scriptable Events Manager", fileName ="Scriptable Events Manager")]
public class CollectionEventsManager : ScriptableObject
{

    public List<ScriptableSystem> systems = new List<ScriptableSystem>();
    
}
