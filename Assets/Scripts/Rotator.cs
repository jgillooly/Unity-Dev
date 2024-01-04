using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour
{
    [SerializeField][Range(-360,360)] float rotate;
    float speed = 5;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.rotation *= Quaternion.AngleAxis(rotate * Time.deltaTime, Vector3.up);
        if (Input.GetKey(KeyCode.LeftShift))
        {
            transform.position += transform.forward * speed * Time.deltaTime;
        }
    }
}
