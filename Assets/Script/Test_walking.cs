using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test_walking : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("test",1.00f,1.00f);
    }

    void test()
    {
        transform.position.Set(transform.position.x, transform.position.y, transform.position.z - 1);
        Debug.Log(transform.position.z);
    }
}
