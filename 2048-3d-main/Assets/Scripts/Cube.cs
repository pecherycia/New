using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class Cube : MonoBehaviour
{

    public int Po2Value { get; private set; }
     

    public void SetSpawnedCubeValues()
    {
        float randomValue = Random.value;
        if (randomValue <= 0.75f)
        {
            Po2Value = 2;
        }
        else
        {
            Po2Value = 4;
        }

      
        SetPo2CubeValueText();

    }


    public void SetMergedCubeValues( )
    {
        Po2Value = Po2Value * 2;

        SetPo2CubeValueText();
    }

    private void SetPo2CubeValueText()
    {
       
        TextMeshPro[] textElements = gameObject.GetComponentsInChildren<TextMeshPro>();

        foreach (TextMeshPro textElement in textElements)
        {
            textElement.text = Po2Value.ToString();
        }
    }
    

}

