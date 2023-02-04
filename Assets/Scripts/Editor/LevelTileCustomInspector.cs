using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

using UnityEditor.UIElements;
using UnityEngine.UIElements;

[CanEditMultipleObjects]
[CustomEditor(typeof(LevelTile), true)]
public class LevelTileCustomInspector : Editor
{
    public override void  OnInspectorGUI()
    {

        LevelTile tileRef = (LevelTile)target;

        if (GUILayout.Button("End"))
        {
            tileRef.ChangeDisplay(0); // how do i call this?
        }
        DrawDefaultInspector();
    }
}