using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

namespace SpawnTools
{
    public class SpawnSearchWindow : EditorWindow
    {
        public static bool isDrawn = true;
        Vector2 scrollPosition = Vector2.zero;
        private Texture2D tex;

        static List<GameObject> gameObjectsInLayer = new List<GameObject>();

        private void OnEnable()
        {
            gameObjectsInLayer = SpawnSearch.goList;

            // Try to get the sprite
            var textures = Resources.FindObjectsOfTypeAll<Texture2D>();
            foreach (var texture in textures)
            {
                if (texture.name == "SpawnSearch")
                {
                     tex = texture;
                }
            }
        }

        public static void ShowWindow()
        {
            var window = GetWindow<SpawnSearchWindow>("SpawnSearch Results");
            var position = window.position;
            position.center = new Rect(0f, 0f, Screen.currentResolution.width, Screen.currentResolution.height).center;
            window.position = position;
            window.Show();
        }

        void OnInspectorUpdate()
        {
            Repaint();
        }

        private void OnGUI()
        {
            scrollPosition = GUILayout.BeginScrollView(scrollPosition, false, false, GUILayout.Width(position.width),
                GUILayout.Height(position.height));

            GUILayout.Space(30);
            GUIStyle centeredTextStyle = new GUIStyle("label");
            centeredTextStyle.alignment = TextAnchor.MiddleCenter;

            GUILayout.BeginHorizontal();
            GUILayout.FlexibleSpace();
            
            GUILayout.Box(tex);
            
            GUILayout.FlexibleSpace();
            GUILayout.EndHorizontal();
            GUILayout.Space(20);
            
            

            if (SpawnSearchEditor.searchedLayer)
            {
                if (SpawnSearch.count > 0)
                {
                    GUILayout.Label(
                        $"{SpawnSearch.count} GameObjects found using ' {SpawnSearch.layerName} ' as their Layer.",
                        centeredTextStyle);
                    GUILayout.Space(10);

                    GUILayout.Label("List of GameObjects :", EditorStyles.boldLabel);
                    GUILayout.Space(5);
                    // print out objects

                    foreach (var go in gameObjectsInLayer)
                    {
                        EditorGUILayout.ObjectField(go, typeof(GameObject), true);
                    }
                }
                else
                {
                    GUILayout.Label($"No GameObjects found using ' {SpawnSearch.layerName} ' as a Layer.",
                        centeredTextStyle);
                    GUILayout.Space(10);
                }
            }

            if (SpawnSearchEditor.searchedTag)
            {
                if (SpawnSearch.count > 0)
                {
                    GUILayout.Label($"{SpawnSearch.count} GameObjects found tagged as ' {SpawnSearch.tagName} '.",
                        centeredTextStyle);
                    GUILayout.Space(10);

                    GUILayout.Label("List of GameObjects :", EditorStyles.boldLabel);
                    GUILayout.Space(5);
                    // print out objects

                    foreach (var go in gameObjectsInLayer)
                    {
                        EditorGUILayout.ObjectField(go, typeof(GameObject), true);
                    }
                }
                else
                {
                    GUILayout.Label($"No GameObjects found tagged as ' {SpawnSearch.tagName} '.", centeredTextStyle);
                    GUILayout.Space(10);
                }
            }
            
            GUILayout.Space(30);
            GUILayout.BeginHorizontal();
            GUILayout.FlexibleSpace();
            
            GUI.color = Color.gray;
            GUI.backgroundColor = Color.gray;
            if (GUILayout.Button("Close Window" ,GUILayout.Width(100)))
            {
                // Closes Through Editor To Clear Lists and Reset Logic
                SpawnSearchEditor.CloseWindow();
            }
            
            GUILayout.FlexibleSpace();
            GUILayout.EndHorizontal();
            
            if (!isDrawn)
                Close();

            GUILayout.EndScrollView();
        }

        private void OnDestroy()
        {
            // Closes Through Editor To Clear Lists and Reset Logic
            SpawnSearchEditor.CloseWindow();
        }
    }
}
