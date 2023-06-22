using System.Collections;
using System.Collections.Generic;
using UnityEngine;

#if UNITY_EDITOR
using UnityEditor;
[CustomEditor(typeof(NewBehaviourScript1), true)]
public class NBSEditor1 : NBSEditor
{
    
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        if(GUILayout.Button("Õóÿê"))
        {
            NewBehaviourScript1 tar = target as NewBehaviourScript1;
            tar.Data = new DataNested() { f = 10 };
        }
        if (GUILayout.Button("Õóÿê-õóÿê"))
        {
            NewBehaviourScript1 tar = target as NewBehaviourScript1;
            tar.Data = new DataNestedNested() { f = 10, vec = new Vector3(61, 565, 15) };
        }
    }
}

#endif

public class NewBehaviourScript1 : NewBehaviourScript
{
    
}


[System.Serializable]
public class DataNested : Data
{
    public float f;
}

[System.Serializable]
public class DataNestedNested : DataNested
{
    public Vector3 vec;
}