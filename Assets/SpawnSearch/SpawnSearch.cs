using System;
using System.Collections.Generic;
using UnityEngine;

namespace SpawnTools
{
    [ExecuteInEditMode]
    public class SpawnSearch : MonoBehaviour
    {
        [Space(10)]
        public LayerMask layer;
        private int layerValue;
        private string layerBinary;
        [HideInInspector] public int numberOfOnes = 0;

        public static List<GameObject> goList = new List<GameObject>();
        private GameObject[] goArray;

        [HideInInspector] public bool canSearchLayer = true;
        [HideInInspector] public bool isFinished = false;
        
        public static int count;
        public static string layerName;
        public static string tagName;

        private int layerResult;
        
        public void OnValidate()
        {
            // Xheck to make sure the LayerMask only has 1 layer selected
            layerValue = layer.value;
            layerBinary = Convert.ToString(layerValue, 2);
            numberOfOnes = 0;
            foreach (var character in layerBinary)
            {
                if (character == '1')
                    numberOfOnes++;
            }
            canSearchLayer = numberOfOnes <= 1;

            if (layerValue == 0)
            {
                canSearchLayer = false;
            }
        }

        // Expensive
        public void FindLayer()
        {
            goArray = FindObjectsOfType<GameObject>();
            foreach (var go in goArray)
            {
                if (go.layer == ToLayer(layerValue))
                    goList.Add(go);
            }

            SetInfo();
        }

        // Expensive
        public void FindTag(string tag)
        {
            tagName = tag;
            
            goArray = FindObjectsOfType<GameObject>();
            foreach (var go in goArray)
            {
                if (go.CompareTag(tag))
                {
                    goList.Add(go);
                }
            }

            SetInfo();
        }

        public int ToLayer(int bitmask)
        {
            int result = bitmask > 0 ? 0 : 31;
            while (bitmask > 1)
            {
                bitmask = bitmask >> 1;
                result++;
            }

            layerResult = result;
            return result;
        }

        void SetInfo()
        {
            count = goList.Count;
            layerName = LayerMask.LayerToName(layerResult);
            isFinished = true;
        }

        public void ClearList()
        {
            goList.Clear();
        }
    }
}

