using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrbitCamera : MonoBehaviour
{

    [SerializeField] GameObject target = null;
    [SerializeField][Range(20, 90)] float defaultPitch = 40;
    

    float yaw = 0;
    float pitch = 0;

    // Start is called before the first frame update
    void Start()
    {
        pitch = defaultPitch;
        
    }

    // Update is called once per frame
    void Update()
    {
        yaw += Input.GetAxis("Mouse X");
        pitch += Input.GetAxis("Mouse Y");


        Quaternion qyaw = Quaternion.AngleAxis(yaw, Vector3.up);

        Quaternion qpitch = Quaternion.AngleAxis(pitch, Vector3.right);

        Quaternion rotation = qyaw * qpitch;

        transform.position = target.transform.position;
        transform.rotation = qpitch;
        transform.position = target.transform.position + (rotation * Vector3.back * 5);
    }
}
