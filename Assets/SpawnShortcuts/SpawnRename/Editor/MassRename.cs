using UnityEngine;
using UnityEditor;

public class MassRename : EditorWindow
{
    private string stringToRename = "";
    private static Object[] objs;

    [MenuItem("GameObject/SpawnTools/Mass Rename %#r")]
    static void Init()
    {
        if (Selection.objects.Length <= 0) return;

        MassRename window = ScriptableObject.CreateInstance<MassRename>();

        var rect = GetWindow<SceneView>().position;
        float x = rect.width;
        float y = rect.height;

        //position window and offset it by half its own dimensions
        float w = 150f;
        float h = 100f;

        objs = Selection.objects;

        window.position = new Rect(x * .5f - (w * .5f), y * .5f + (h * .25f), w, h); //??
        window.ShowPopup();

        Debug.Log("popped off");
        Selection.objects = null;
    }

    void OnGUI()
    {
        //lookin into editor styles

        GUIStyle myTextStyle = new GUIStyle(GUI.skin.textField);
        myTextStyle.margin = new RectOffset(5, 5, 5, 5);

        GUIStyle myButtonStyle = new GUIStyle(GUI.skin.button);
        myButtonStyle.margin = new RectOffset(20, 20, 10, 10);

        GUILayout.Space(5);
        EditorGUILayout.LabelField("Mass Rename", EditorStyles.wordWrappedLabel);

        GUILayout.Space(10);
        stringToRename = GUILayout.TextField(stringToRename, 25, myTextStyle);
        if (GUILayout.Button("Rename", myButtonStyle))
        {
            SpawnTools.SpawnShortcuts.MassRename(stringToRename, objs);
            this.Close();
        }

        Repaint();
    }
}