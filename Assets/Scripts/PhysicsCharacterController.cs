using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhysicsCharacterController : MonoBehaviour
{
    [Header("Movement")]
    public Rigidbody rb;
    Vector3 force = Vector3.zero;

    public float Speed = 5;
    public float JumpForce;

    public Transform view;

    [Header("Collision")]
    [SerializeField] float rayLength = 1;
    [SerializeField] LayerMask groundLayerMask;

    // Start is called before the first frame update
    void Start()
    {
        //Cursor.lockState = CursorLockMode.Locked;
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 direction = Vector3.zero;

        direction.x = Input.GetAxis("Horizontal");
        direction.z = Input.GetAxis("Vertical");

        Quaternion yrotation = Quaternion.AngleAxis(view.rotation.eulerAngles.y, Vector3.up);
        force = yrotation * direction * Speed;
        Debug.DrawRay(transform.position, Vector3.down * rayLength, Color.red);
        if (Input.GetButtonDown("Jump") && CheckGround())
        {
            rb.AddForce(Vector3.up * JumpForce, ForceMode.Impulse);
            print(force.x.ToString() + "," + force.z.ToString());
            print(direction.x);
            print(direction.z);
        }
    }

    private void FixedUpdate()
    {
        rb.AddForce(force, ForceMode.Force);
    }

    private bool CheckGround()
    {
        
        return Physics.Raycast(transform.position, -Vector3.down, rayLength, groundLayerMask);
    }
}
