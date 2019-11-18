using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordScript : MonoBehaviour
{
    //Private float for rotation speed, changing it would change the timing on the sword, therefore it is private
    float rotationSpeed = 500;

    //When the sword is enabled
    void OnEnable()
    {
        //Invoke UnEnable wwith 0.35 seconds
        Invoke("UnEnable", 0.35f);
    }

    //On Update
    private void Update()
    {
        //Rotate the sword with the rotation z value, using rotationSpeed
        transform.Rotate(Vector3.back * (rotationSpeed * Time.deltaTime));
    }

    //Function for unEnabling the sword, used for the invoke
    public void UnEnable()
    {
        gameObject.SetActive(false); //Set object active to false
    }
}
