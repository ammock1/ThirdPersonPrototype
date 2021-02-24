using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Rigidbody rb;
    private float rotationInput;
    private float verticalInput;
    private bool shouldJump;
    [SerializeField] private float speedConstant;
    [SerializeField] private float rotSpeedConstant;
    [SerializeField] private float jumpSpeed;
    [SerializeField] private Transform groundCheckTransform = null;
    [SerializeField] private LayerMask playerMask;
    private float speed;
    private float rotSpeed;
    private Vector3 tmpV3;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            shouldJump = true;
        }
        rotationInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");
    }

    // Called once per physics update
    private void FixedUpdate()
    {
        speed = speedConstant * Time.deltaTime;
        rotSpeed = rotSpeedConstant * Time.deltaTime;
        
        tmpV3 = transform.forward * speed * verticalInput;
        tmpV3.y = rb.velocity.y;
       
        rb.velocity = tmpV3;
        rb.angularVelocity = new Vector3(rb.angularVelocity.x, rotationInput * rotSpeed, rb.angularVelocity.z);
        
        //check that player pressed jump button
        if (shouldJump)
        {
            //if grounded, jump. In all cases, set shouldJump to false (don't want the character to jump when it gets back on the ground!)
            if(Physics.OverlapSphere(groundCheckTransform.position, 0.1f, playerMask).Length != 0)
            {
                rb.AddForce(new Vector3(rb.velocity.x, jumpSpeed, rb.velocity.z), ForceMode.VelocityChange);
            }
            shouldJump = false;
        }
    }
}
