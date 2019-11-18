using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordScript : MonoBehaviour
{
    float rotationSpeed = 500;

    void Start()
    {
        
    }

    // Update is called once per frame
    void OnEnable()
    {
        Invoke("UnEnable", 0.35f);
        //transform.rotation = Quaternion.identity;
        

    }

    private void Update()
    {
        transform.Rotate(Vector3.back * (rotationSpeed * Time.deltaTime));
    }

    public void UnEnable()
    {
        //gameObject.transform.rotation = Quaternion.identity;
        gameObject.SetActive(false);
    }
}
