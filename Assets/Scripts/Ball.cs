using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Ball : MonoBehaviour
{
    [Header("Movement")]
    [SerializeField][Range(1,20)][Tooltip("Force to move the object :)")] float force;


    public Rigidbody rb;


    private void Awake()
    {
        //print("Awake");
        //rb = GetComponent<Rigidbody>();
    }

    // Start is called before the first frame update
    void Start()
    {
        //print("Start");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(transform.forward * -force, ForceMode.VelocityChange);
        }
    }
}
