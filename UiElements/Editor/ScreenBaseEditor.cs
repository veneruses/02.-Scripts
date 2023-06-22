using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using GefestCapital;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(ScreenBaseElement), true)]
public class ScreenBaseEditor : UIElementEditor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        // ScreenBaseElement tar = target as ScreenBaseElement;
        //
        // if (GUILayout.Button("Save Child Elements"))
        // {
        //     MethodInfo methodInfo = typeof(ScreenBaseElement).GetMethod("SaveChildElements", BindingFlags.NonPublic | BindingFlags.Instance);
        //     if (methodInfo != null)
        //     {
        //         methodInfo.Invoke(tar, null);
        //     }
        //     else
        //     {
        //         Debug.LogError("Method SaveChildElements does not exist on target object");
        //     }
        // }
        //
        // if (GUILayout.Button("Load Elements"))
        // {
        //     MethodInfo methodInfo = typeof(ScreenBaseElement).GetMethod("LoadElements", BindingFlags.NonPublic | BindingFlags.Instance);
        //     if (methodInfo != null)
        //     {
        //         methodInfo.Invoke(tar, null);
        //     }
        // }
        //
        // if (GUILayout.Button("Load and instantiate Elements"))
        // {
        //     MethodInfo methodInfo = typeof(ScreenBaseElement).GetMethod("LoadAndInstantiateElements", BindingFlags.NonPublic | BindingFlags.Instance);
        //     if (methodInfo != null)
        //     {
        //         methodInfo.Invoke(tar, null);
        //     }
        // }
    }
    
}
