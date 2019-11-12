using UnityEngine;

public class CameraFollowScript : MonoBehaviour
{

    public GameObject followObject;

    void Start()
    {

    }

    void Update()
    {
        if (followObject)
        {
            transform.position = Vector3.Lerp(transform.position, new Vector3(followObject.transform.position.x, followObject.transform.position.y, transform.position.z), .1f);
        }
    }
}
