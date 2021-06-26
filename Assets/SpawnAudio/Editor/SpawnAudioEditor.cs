using UnityEngine;
using UnityEditor;

namespace SpawnTools
{
    [CustomEditor(typeof(SpawnAudio))]
    public class SpawnAudioEditor : Editor
    {
        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();
            SpawnAudio sa = (SpawnAudio) target;
            
            if (EditorApplication.isPlaying)
                sa.hideFlags = HideFlags.NotEditable;
            else
                sa.hideFlags = HideFlags.None;
            
            
            GUIStyle centeredTextStyle = new GUIStyle("label");
            centeredTextStyle.alignment = TextAnchor.MiddleCenter;
            GUILayout.Space(10);

            
            if (!sa.hasGeneratedSources)
            {
                GUI.color = Color.yellow;
                GUILayout.Label("[ SpawnAudio is not configured ]",centeredTextStyle);
                GUI.color = Color.white;
                GUILayout.Space(10);
                GUILayout.Label("This will destroy any existing AudioSources.", centeredTextStyle);
                GUILayout.Space(5);
                if (GUILayout.Button("Generate AudioSources"))
                {
                    sa.GenerateAudioSources();
                }
                GUILayout.Space(5);
                GUI.backgroundColor = Color.red;
                if (GUILayout.Button("Destroy and Reset"))
                {
                    sa.Reset();
                }
                GUILayout.Space(10);
            }
            else
            {
                GUI.color = Color.green;
                GUILayout.Label("[ SpawnAudio is Ready ]",centeredTextStyle);
                GUI.color = Color.white;
                GUILayout.Space(10);
                GUILayout.Label("Deletes All AudioSources and Resets Script", centeredTextStyle);
                GUILayout.Space(5);
                GUI.backgroundColor = Color.red;
                if (GUILayout.Button("Destroy and Reset"))
                {
                    sa.Reset();
                }
                GUILayout.Space(10);
            }
        }
    }
}
