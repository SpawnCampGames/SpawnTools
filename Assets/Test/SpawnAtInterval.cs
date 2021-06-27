using System.Collections;
using UnityEngine;

public class SpawnAtInterval : MonoBehaviour
{
    private int objectsToSpawn;

    // Update is called once per frame
    void Update()
    {
        if (objectsToSpawn < 10)
        {
            StartCoroutine(WaitAndSpawn());
        }
        
    }

    void SpawnStuff()
    {
        //spawn one Instantiate();
    }


    IEnumerator WaitAndSpawn()
    {
        SpawnStuff();
        yield return new WaitForSeconds(5f);
    }
}
