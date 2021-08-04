using System.Collections.Generic;
using UnityEngine;

namespace SpawnTools
{
    [ExecuteInEditMode]
    public class SpawnScene : MonoBehaviour
    {
        [Space(5)]
        [Header("Lights")]
        [Range(0,3)]
        public int numberOfLights = 0;
        public List<Color> lightColors = new List<Color>();
        
        [Space(5)]
        [Header("Floor")]
        [Space(5)] public float floorWidth = 10;
        public float floorLength = 10;
        
        public void Spawn()
        {
            //Set Parent Position to Zero
            transform.position = Vector3.zero;
            
            //Floor
            GenerateFloor();
            
            //Floor
            GenerateCube();
            
            //Lights
            GenerateLights();
            
            //Destroy Component
            DestroyImmediate(this);
        }
        
        void GenerateFloor()
        {
            GameObject floor = GameObject.CreatePrimitive(PrimitiveType.Plane);
            floor.transform.localScale = new Vector3(floorWidth, 0f, floorLength);
            floor.name = "Floor";
            floor.transform.parent = this.transform;
        }
        
        void GenerateCube()
        {
            GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
            cube.transform.position = new Vector3(0, .5f, 0);
            cube.name = "Default Cube";
            cube.transform.parent = this.transform;
        }
        
        void GenerateLights()
        {
            GameObject lightParent = new GameObject();
            lightParent.name = "Lights";
            lightParent.transform.parent = this.transform;
            
            for (int i = 0; i < lightColors.Count; i++)
            {
                //create holder for light
                
                GameObject light = new GameObject();
                light.name = $"Light{i+1}";
                light.transform.parent = lightParent.transform;
                
                //create light
                var lightToEdit = light.AddComponent<Light>();
                lightToEdit.type = LightType.Directional;
                lightToEdit.intensity = 1;
                lightToEdit.shadows = LightShadows.Soft;
                lightToEdit.color = lightColors[i];

                light.transform.rotation = Quaternion.Euler(45,45,0);
            }
        }
        
        private void OnValidate()
        {
            if (lightColors.Count < numberOfLights)
            {
                for (int i = lightColors.Count; i < numberOfLights; i++)
                {
                    Color tempColor;
                    tempColor = Color.white;
                    lightColors.Add(tempColor);
                }
            }
            else if (lightColors.Count > numberOfLights)
            {
                for (int i = lightColors.Count; i > numberOfLights; i--)
                {
                    lightColors.Remove(lightColors[i - 1]);
                }
            }
        }
    }
}
