using System.Collections;
using UnityEngine;

public class CubeHorizontalMovement : MonoBehaviour
{
    private Rigidbody _cubeRigidbody;
    

    private void Start()
    {
        _cubeRigidbody = GetComponent<Rigidbody>();
       
    }

    private void Update()
    {
       
        if (CubeInSpawnPostion() && Input.GetMouseButton(0))
        {
            MoveCubeHorizontally();
        }
       
    }

    private void MoveCubeHorizontally()
    {
        float mouseX = Input.GetAxis("Mouse X");
        float zPosition = Mathf.Clamp(transform.position.z + mouseX / 5, -4f, 4f);
        transform.position = new Vector3(transform.position.x, transform.position.y, zPosition);
    }
    
    private bool CubeInSpawnPostion()
    {
        Collider[] colliders = Physics.OverlapBox(transform.position, new Vector3(1, 1, 1));

        foreach (Collider collider in colliders)
        {
            if (collider.CompareTag("StartLine"))
            {
                return true;
            }
        }

        return false;
    }
}
