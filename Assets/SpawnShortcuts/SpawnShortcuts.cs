using UnityEngine;
using UnityEditor;
using UnityEngine.SceneManagement;

namespace SpawnTools
{
    public static class SpawnShortcuts
    {

        [MenuItem("GameObject/3D Object/Rigidbody", false)]
        public static void NewRigidbody()
        {
            EditorApplication.ExecuteMenuItem("Window/General/Hierarchy");
            var go = GameObject.CreatePrimitive(PrimitiveType.Cube);
            go.name = "Rigidbody";
            go.transform.position = Vector3.zero + new Vector3(0,.5f,0);
            go.AddComponent<Rigidbody>();
            Selection.activeGameObject = go;
            EditorApplication.hierarchyChanged += Rename;
        }


        [MenuItem("GameObject/Spawn Empty", false, 0)]
        public static void NewEmpty()
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
        public static void ResetTransform()
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
        public static void ResetPosition()
        {

            var go = Selection.activeGameObject;
            if (go != null)
            {
                Undo.RegisterCompleteObjectUndo(go.transform, "Reset Position");
                go.transform.position = Vector3.zero;
            }
        }

        [MenuItem("GameObject/SpawnTools/Escape Parent #e")]
        public static void EscapeParent()
        {
            var go = Selection.activeGameObject;
            if (go != null)
            {
                //Undo.RegisterCompleteObjectUndo(go.transform, "Escape From Parent");
                go.transform.parent = null;
                go.transform.position = Vector3.zero;
            }
        }

        public static void MassRename(string name, Object[] objs)
        {
            Object[] selectedObjects = objs;
            var i = 0;
            foreach(GameObject selectedObject in selectedObjects)
            {
                selectedObject.name = name + i.ToString();
                i++;
            }
        }
    }
}
