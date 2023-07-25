using UnityEngine;


public class CubesMergeScript : MonoBehaviour
{
    private float _force;

    private Rigidbody _rb;

    private ScoreBank scoreBank;


    private void Start()
    {
        _rb = GetComponent<Rigidbody>();
        scoreBank = FindObjectOfType<ScoreBank>();
    }

    private void Update()
    {
        Vector3 velocity = _rb.velocity;
        _force = velocity.magnitude;
    }

    private void OnCollisionEnter(Collision collision)
    {
        float touchedCubeForce = collision.impulse.magnitude;

        Cube touchedCubeComponent = collision.gameObject.GetComponent<Cube>();
        Cube thisCubeComponent = gameObject.GetComponent<Cube>();

        if (ForceisEnoghForMerge(touchedCubeForce) && (Po2ValueIsEqual(thisCubeComponent, touchedCubeComponent)))
        {
            CubesMerge();

            Destroy(collision.gameObject);
        }

    }

    private bool ForceisEnoghForMerge(float touchedCubeForce)
    {

        if (_force > 15 && touchedCubeForce > 15)
        {
            return true;
        }

        return false;
    }

    private bool Po2ValueIsEqual(Cube thisCubeComponent, Cube touchedCubeComponent)
    {

        if (thisCubeComponent != null && touchedCubeComponent != null)
        {

            if (thisCubeComponent.Po2Value == touchedCubeComponent.Po2Value)
            {
                return true;
            }

        }
        return false;
    }


    private void CubesMerge()
    {

        Cube cubeComponent = gameObject.GetComponent<Cube>();
        cubeComponent.SetMergedCubeValues();
        SendPointForMerge(cubeComponent);


    }

    private void SendPointForMerge(Cube cubeComponent)
    {

        scoreBank.AddScoreForMergedCube(cubeComponent.Po2Value / 2);
        
    }


}
