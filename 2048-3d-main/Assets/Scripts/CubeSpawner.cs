using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeSpawner : MonoBehaviour
{
    [SerializeField] private GameObject _ñubePrefab;
    public float spawnCheckRadius = 1f;

    private void Start()
    {
       
        SpawnCube();
    }

    private void Update()
    {
        if (Input.GetMouseButtonUp(0))
        {
            StartCoroutine(InvokeFunctionAfterDelay(0.5f));
        }
    }

    IEnumerator InvokeFunctionAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);

        if (LocationForSpawnIsFree())
        {
            SpawnCube();
        }
    }

    private void SpawnCube()
    {
        
        GameObject cubePrefab = Instantiate(_ñubePrefab, transform.position, Quaternion.identity);

        Cube cubeComponent = cubePrefab.GetComponent<Cube>();

        cubeComponent.SetSpawnedCubeValues();
    }
        

    private bool LocationForSpawnIsFree()
    {
        Collider[] colliders = Physics.OverlapBox(transform.position, new Vector3(spawnCheckRadius, spawnCheckRadius, spawnCheckRadius));

        foreach (Collider collider in colliders)
        {
            if (collider.CompareTag("Cube"))
            {
                return false;
            }
        }
        return true;
    }
}
