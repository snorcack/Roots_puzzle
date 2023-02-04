using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

using UnityEditor.UIElements;
using UnityEngine.UIElements;

[CustomEditor(typeof(LevelGenerator))]
public class LevelGeneratorCustomInspector : Editor
{
    [SerializeField]
    int level;

    public override void  OnInspectorGUI()
    {
        int sizeMultiplier = EditorGUILayout.IntField("Level to edit", level);
        LevelGenerator generatorRef = (LevelGenerator)target;

        if (GUILayout.Button("Generate"))
        {
            generatorRef.GenerateLevel(); // how do i call this?
        }

        if (GUILayout.Button("Save"))
        {
            generatorRef.SaveLevel(); // how do i call this?
        }

        if (GUILayout.Button("Clear"))
        {
            generatorRef.ClearLevel(); // how do i call this?
        }

        if (GUILayout.Button("Load"))
        {
            generatorRef.LoadLevel(); // how do i call this?
        }

        if (GUILayout.Button("Refresh"))
        {
            generatorRef.RefreshTiles(); // how do i call this?
        }



        DrawDefaultInspector();
    }
}