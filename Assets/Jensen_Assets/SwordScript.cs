using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordScript : MonoBehaviour
{
    public float rotationSpeed = 5;

    void Start()
    {
        
    }

    // Update is called once per frame
    void OnEnable()
    {
        while (transform.rotation.z != -180)
        {
            transform.Rotate(Vector3.back * (rotationSpeed * Time.deltaTime));
        }
        
    }
}
