using UnityEngine;

public class CameraFollowScript : MonoBehaviour
{

    public GameObject followObject;
    public float lerpValue = 0.1f;

    void Start()
    {

    }

    void Update()
    {
        if (followObject)
        {
            transform.position = Vector3.Lerp(transform.position, new Vector3(followObject.transform.position.x, followObject.transform.position.y, transform.position.z), lerpValue);
        }
    }
}
