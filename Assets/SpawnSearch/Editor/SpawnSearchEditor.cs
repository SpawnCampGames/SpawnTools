using UnityEngine;
using UnityEditor;

namespace SpawnTools
{
    [CustomEditor(typeof(SpawnSearch))]
    public class SpawnSearchEditor : Editor
    {
        public int tagIndex = 0;
        static SpawnSearch spawnSearch;
        private bool canSearchTag;
        public static bool searchedTag;
        public static bool searchedLayer;
        
        public override void OnInspectorGUI()
        {
            base.DrawDefaultInspector();
            spawnSearch = (SpawnSearch) target;
            
            GUIStyle centeredTextStyle = new GUIStyle("label");
            centeredTextStyle.alignment = TextAnchor.MiddleCenter;
            GUI.backgroundColor = Color.gray;

            string[] tagStr = UnityEditorInternal.InternalEditorUtility.tags;
            GUILayout.Space(10);
            GUILayout.BeginHorizontal();
            GUILayout.Label("Tag");

            GUI.backgroundColor = Color.white;
            tagIndex = EditorGUILayout.Popup(tagIndex, tagStr);
            GUI.backgroundColor = Color.gray;
            GUILayout.EndHorizontal();
            EditorUtility.SetDirty(target);

            canSearchTag = tagIndex != 0;

            GUILayout.Space(10);
            
            if (!spawnSearch.isFinished)
            {
                GUILayout.BeginHorizontal();
                if (spawnSearch.canSearchLayer)
                {
                    GUI.color = Color.white;
                    if (GUILayout.Button("Find By Layer"))
                    {
                        searchedLayer = true;
                        spawnSearch.FindLayer();
                        SpawnSearchWindow.ShowWindow();
                        SpawnSearchWindow.isDrawn = true;
                    }
                }
                else
                {
                    if (spawnSearch.layer.value == 0)
                    {
                        GUI.color = Color.yellow;
                        GUILayout.Label($"Chose layer other than Nothing", centeredTextStyle);
                    }
                    else
                    {
                        GUI.color = Color.yellow;
                        GUILayout.Label($"Select (1) Layer", centeredTextStyle);
                    }
                }

                if (canSearchTag)
                {
                    GUI.color = Color.white;
                    if (GUILayout.Button("Find By Tag"))
                    {

                        searchedTag = true;
                        spawnSearch.FindTag(tagStr[tagIndex]);
                        SpawnSearchWindow.ShowWindow();
                        SpawnSearchWindow.isDrawn = true;
                    }
                }
                else
                {
                    GUI.color = Color.yellow;
                    GUILayout.Label($"No Tags Selected", centeredTextStyle);
                }

                GUILayout.EndHorizontal();
            }
            
            GUILayout.BeginHorizontal();
            GUILayout.FlexibleSpace();

            if (spawnSearch.isFinished)
            {
                GUI.color = Color.green;
                GUILayout.Label($"Search Successful.", centeredTextStyle);
                GUILayout.Space(20);

                GUI.color = Color.gray;
                if (GUILayout.Button("OK", GUILayout.Width(100)))
                {
                    CloseWindow();
                }
            }
            
            GUILayout.FlexibleSpace();
            GUILayout.EndHorizontal();
            
        }

        public static void CloseWindow()
        {
            searchedLayer = false;
            searchedTag = false;
            SpawnSearchWindow.isDrawn = false;
            spawnSearch.ClearList();
            spawnSearch.isFinished = false;
            spawnSearch.numberOfOnes = 0;
        }
    }
}