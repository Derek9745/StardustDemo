using UnityEngine;
using UnityEditor;
using System.Collections;

class LevelEditor: EditorWindow
{
    [MenuItem("Window/Level Editor")]
    public static void ShowWindow()
    {
        GetWindow(typeof(LevelEditor));
    }

    private void OnGUI()
    {




    }

}