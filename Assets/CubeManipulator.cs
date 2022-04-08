using UnityEngine;

public class CubeManipulator : MonoBehaviour
{
    // variables
    public GameObject cubeToManipulate;
    public GameObject cubeToManipulate2;
    public GameObject cubeToManipulate3;
    public Material newMaterial;
    public Vector3 newScale;

    // unnecessary juice
    public GameObject poof;

    private void Start()
    {

    }

    void Begin()
    {
        // remove the children
        foreach (Transform child in cubeToManipulate.transform)
            Destroy(child.gameObject);

        //rescale the parent
        cubeToManipulate.transform.localScale = newScale;

        //change color of parent
        var r = cubeToManipulate.GetComponent<MeshRenderer>();
        r.material = newMaterial;
        Instantiate(poof, cubeToManipulate.transform.position, Quaternion.identity);
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Begin();
        }
    }

    private void FixedUpdate()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        
    }
}