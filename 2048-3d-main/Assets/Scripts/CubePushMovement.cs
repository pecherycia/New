using System.Collections;
using UnityEngine;

public class CubePushMovement : MonoBehaviour
{
    private Rigidbody _cubeRigidbody;   
    [SerializeField] private float pushForce;

    private void Start()
    {
        _cubeRigidbody = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if (Input.GetMouseButtonUp(0) && CubeInStartLine())
        {
            PushCube();
            
        }
    }

    private void PushCube()
    {
        _cubeRigidbody.AddForce(Vector3.left * pushForce, ForceMode.Impulse);
    }

    private bool CubeInStartLine()
    {
        Collider[] colliders = Physics.OverlapBox(transform.position, new Vector3(2, 2, 2));

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
