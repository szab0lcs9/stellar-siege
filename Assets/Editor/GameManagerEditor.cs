using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(GameManager))]
public class GameManagerEditor : UnityEditor.Editor
{
    public override void OnInspectorGUI()
    {
        GameManager gameManager = (GameManager)target;

        DrawDefaultInspector();

        if (GUILayout.Button("Save Game"))
            gameManager.Save();
        if (GUILayout.Button("Load Game"))
            gameManager.Load();
    }
}
