using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapMove : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //これは加算
        transform.Rotate(0, 1, 0);
        //これは代入
        //transform.rotation = Quaternion.Euler(0.0f, 0.0f, 0.0f);
    }
}
