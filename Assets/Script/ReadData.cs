using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReadData : MonoBehaviour
{
    float Check;
    AverageDeviation AverageDeviation;
    [SerializeField] GameObject Camera;

    void awake()
    {
        AverageDeviation = Camera.GetComponent<AverageDeviation>();
    }


    void Update()
    {
        Check = AverageDeviation.Ave_AveDeviation;
        


        if(Check != 0)
        {

        }
    }
}
