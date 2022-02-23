using UnityEngine;

namespace SpawnTools
{
    public class Debugs : MonoBehaviour
    {
        // this one allows .Log();
        public static void Log(string output = "") => Debug.Log($"<color=Black>{output}</color>");
        //public static void Log() => Debug.Log($"<color=Black>Null</color>");
        public static void Log(object message) => Debug.Log($"<color=Black>{message}</color>");
        public static void LogWarning(object message) => Debug.LogWarning($"<color=Yellow>{message}</color>");
    }
}
