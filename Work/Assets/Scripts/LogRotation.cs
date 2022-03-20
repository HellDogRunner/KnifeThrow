using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LogRotation : MonoBehaviour
{
    public float speed = 150f;
    void FixedUpdate()
    {

            transform.Rotate(0, 0, speed * Time.deltaTime, Space.Self);



    }

    
}
