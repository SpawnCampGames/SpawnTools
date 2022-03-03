using UnityEngine;
using UnityEditor;
using UnityEngine.SceneManagement;

namespace SpawnTools
{
    public class SpawnShortcuts : ScriptableObject
    {
        [MenuItem("GameObject/Spawn Empty", false, 0)]
        static public void NewEmpty()
        {
            EditorApplication.ExecuteMenuItem("Window/General/Hierarchy");
            var go = new GameObject("GameObject");
            go.transform.position = Vector3.zero;
            Selection.activeGameObject = go;
            EditorApplication.hierarchyChanged += Rename;
        }

        static void Rename()
        {
            EditorApplication.hierarchyChanged -= Rename;
            EditorWindow.focusedWindow.SendEvent(new Event { keyCode = KeyCode.F2, type = EventType.KeyDown });
        }

        [MenuItem("GameObject/SpawnTools/Reset Transform #r")]
        static public void ResetTransform()
        {
            var go = Selection.activeGameObject;
            if (go != null)
            {
                Undo.RegisterCompleteObjectUndo(go.transform, "Reset Transform");

                go.transform.position = Vector3.zero;
                go.transform.rotation = Quaternion.identity;
                go.transform.localScale = Vector3.one;
            }
        }

        [MenuItem("GameObject/SpawnTools/Reset Position #p")]
        static public void ResetPosition()
        {

            var go = Selection.activeGameObject;
            if (go != null)
            {
                Undo.RegisterCompleteObjectUndo(go.transform, "Reset Position");
                go.transform.position = Vector3.zero;
            }
        }

        [MenuItem("GameObject/SpawnTools/Escape Parent #e")]
        static public void EscapeParent()
        {
            var go = Selection.activeGameObject;
            if (go != null)
            {
                //Undo.RegisterCompleteObjectUndo(go.transform, "Escape From Parent");
                go.transform.parent = null;
                go.transform.position = Vector3.zero;
            }
        }

        static public void MassRename(string name, Object[] objs)
        {
            Object[] selectedObjects = objs;
            var i = 0;
            foreach(GameObject selectedObject in selectedObjects)
            {
                //Undo.RegisterCompleteObjectUndo(selectedObject.transform, "Rename GameObject");
                selectedObject.name = name + i.ToString();
                i++;
            }
        }
    }
}
