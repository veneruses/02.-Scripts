using System.Collections;
using System.Collections.Generic;
using UnityEngine;

#if UNITY_EDITOR
using UnityEditor;
[CustomEditor(typeof(NewBehaviourScript), true)]
public class NBSEditor : Editor
{
    SerializedProperty data;
    private void OnEnable()
    {
        data = serializedObject.FindProperty("Data");
    }

    public override void OnInspectorGUI()
    {
        NewBehaviourScript tar = target as NewBehaviourScript;
        DrawData(tar.Data.GetType().FullName);
    }

    void DrawData(string typeName)
    {
        var type = System.Type.GetType(typeName);
        var fields = type.GetFields();
        for (int i = 0; i < fields.Length; i++)
        {
            var prop = data.FindPropertyRelative(fields[i].Name);
            if(prop != null) EditorGUILayout.PropertyField(prop);
            else
            {
                var dataVal = data.GetValue<object>();
                //dataVal.GetType().GetField()
                DrawReflectionField(fields[i], dataVal);
            }
        }
        //foreach (SerializedProperty prop in data)
        //{
        //    EditorGUILayout.PropertyField(prop);
        //}
    }

    void DrawReflectionField(System.Reflection.FieldInfo field, object fieldObject)
    {
        object val = field.GetValue(fieldObject);
        if (field.FieldType == typeof(float))
        {
            val = EditorGUILayout.FloatField(field.Name, (float)val);
        }
        else if (field.FieldType == typeof(int))
        {
            val = EditorGUILayout.IntField(field.Name, (int)val);
        }
        else if (field.FieldType == typeof(Vector3))
        {
            val = EditorGUILayout.Vector3Field(field.Name, (Vector3)val);
        }

        if (GUI.changed)
            field.SetValue(fieldObject, val);
    }
}

#endif

//public abstract class NewBehaviourScript : MonoBehaviour
//{

//}
public class NewBehaviourScript : MonoBehaviour //where T : Data
{
    public Data Data;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

[System.Serializable]
public class Data
{
    public int a;
    public string str;
}
