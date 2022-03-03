using UnityEngine;

namespace SpawnTools
{
    public class Dbug : MonoBehaviour
    {
        public static void Log(string s = "") => Debug.Log($"<color=Black>{s}</color>");
        public static void Log(object o) => Debug.Log($"<color=Black>{o}</color>");
        public static void Position(Vector3 vec3) => Debug.Log($"x: {vec3.x} , y: {vec3.y} , z: {vec3.z}");
        public static void Warning(object o) => Debug.LogWarning($"<color=Yellow>{o}</color>");
    }
}
