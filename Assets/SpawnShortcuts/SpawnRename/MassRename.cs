using UnityEngine;
using UnityEditor;

public class MassRename : EditorWindow
{
    private string stringToRename = "";


    [MenuItem("GameObject/SpawnTools/Mass Rename %#r")]
    static void Init()
    {
        MassRename window = ScriptableObject.CreateInstance<MassRename>();
        window.position = new Rect(Screen.width / 2, Screen.height / 2, 250, 150); // this is wrong

        Debug.Log(Screen.width / 2); 
        Debug.Log(Screen.height / 2);

        window.ShowPopup();
    }

    void OnGUI()
    {
        EditorGUILayout.LabelField("Mass Rename", EditorStyles.wordWrappedLabel);
        GUILayout.Space(40);

        stringToRename = GUILayout.TextField(stringToRename, 25);
        if (GUILayout.Button("Rename"))
        {
            SpawnTools.SpawnShortcuts.MassRename(stringToRename);
            this.Close();
        }

        Repaint();
    }
}