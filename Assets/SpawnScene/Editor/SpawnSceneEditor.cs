using SpawnTools;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(SpawnScene))]
public class SpawnSceneEditor : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        
        SpawnScene sc = (SpawnScene) target;

        GUIStyle centeredTextStyle = new GUIStyle("label");
        centeredTextStyle.alignment = TextAnchor.MiddleCenter;

        if (sc.numberOfLights <= 0)
        {
            GUILayout.Space(10);
            GUILayout.Label("Must add at least one light before generating.",centeredTextStyle);
            GUI.backgroundColor = Color.gray;
            GUILayout.Space(5);
            if (GUILayout.Button("Generate"))
            {
               Debug.Log("Can't generate without a light source");
            }
        }
        else
        {
            if (sc.floorWidth <= 0 || sc.floorLength <= 0)
            {
                GUILayout.Space(10);
                GUILayout.Label("Floor dimensions can't be less than Zero.",centeredTextStyle);
                GUI.backgroundColor = Color.gray;
                GUILayout.Space(5);
                if (GUILayout.Button("Generate"))
                {
                    Debug.Log("Make sure the floor dimensions are greater than zero.");
                }
            }
            else
            {
                GUILayout.Space(10);
                GUILayout.Label($"Generate with ( {sc.numberOfLights} ) Lights.",centeredTextStyle);
                GUI.backgroundColor = Color.green;
                GUILayout.Space(5);
                if (GUILayout.Button("Generate"))
                {
                    sc.Spawn();
                }
            }
        }

        
        
    }

    
    
}
