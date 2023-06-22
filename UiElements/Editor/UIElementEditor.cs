using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using Sirenix.OdinInspector.Editor;
using UnityEditor;
using UnityEngine;

namespace GefestCapital
{
    [CustomEditor(typeof(UIElement), true)]
    public class UIElementEditor : OdinEditor
    {
        SerializedProperty data;
        SerializedProperty generateDataOnStart;
        SerializedProperty generateDataOnStartEditor;

        private bool showData = true;

        private void OnEnable()
        {
            data = serializedObject.FindProperty("Data");
            generateDataOnStart = serializedObject.FindProperty("m_generateDataOnStart");
            generateDataOnStartEditor = serializedObject.FindProperty("m_generateDataOnStartInEditor");
        }

        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();
            UIElement tar = target as UIElement;
            // EditorGUILayout.PropertyField(generateDataOnStart);
            // EditorGUILayout.PropertyField(generateDataOnStartEditor);
            showData = EditorGUILayout.Foldout(showData, tar.Data.GetType().Name);
            if (showData)
            {
                if (tar.Data != null)
                {
                    DrawData(tar.Data.GetType().FullName);
                }
            }
            //
            // if (GUILayout.Button("Set ID"))
            // {
            //     tar.SetId();
            //     EditorUtility.SetDirty(tar);
            // }
            //
            // if (GUILayout.Button("Set Prefab Name"))
            // {
            //     tar.SetPrefabName();
            //     EditorUtility.SetDirty(tar);
            // }
            //
            // if (GUILayout.Button("Clear Data"))
            // {
            //     tar.ClearData();
            //     EditorUtility.SetDirty(tar);
            // }
            //
            // if (GUILayout.Button("Save Element"))
            // {
            //     MethodInfo methodInfo =
            //         typeof(UIElement).GetMethod("SaveElement", BindingFlags.Public | BindingFlags.Instance);
            //     if (methodInfo != null)
            //     {
            //         methodInfo.Invoke(tar, null);
            //     }
            //     else
            //     {
            //         Debug.LogError("Method SaveElement does not exist on target object");
            //     }
            // }
            //
            serializedObject.ApplyModifiedProperties();
        }

        void DrawData(string typeName)
        {
            var v3 = target.GetType().Assembly;
            var type = v3.GetType(typeName);
            var fields = type.GetFields();
            EditorGUI.indentLevel++;
            for (int i = 0; i < fields.Length; i++)
            {
                var prop = data.FindPropertyRelative(fields[i].Name);
                if (prop != null) EditorGUILayout.PropertyField(prop);
                else
                {
                    var dataVal = data.GetValue<object>();
                    DrawReflectionField(fields[i], dataVal);
                }
            }

            EditorGUI.indentLevel--;
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
            else if (field.FieldType == typeof(string))
            {
                val = EditorGUILayout.TextField(field.Name, (String)val);
            }


            if (GUI.changed)
                field.SetValue(fieldObject, val);
        }
    }
}