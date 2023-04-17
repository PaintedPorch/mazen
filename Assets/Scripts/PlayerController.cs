using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float moveSpeed = 10f;
    [SerializeField] float rotateSpeed = 250f; 
    [SerializeField] bool isGround = false;
    [SerializeField] float jumpForce = 2500f;
    Rigidbody rigidBody;

    void Start() 
    {
        rigidBody = GetComponent<Rigidbody>();    
    }

    void Update()
    {
        float verticalAmount = Input.GetAxisRaw("Vertical");
        float horizontalAmount = Input.GetAxisRaw("Horizontal");
        float horizontalRotation = Input.GetAxisRaw("Mouse X");

       transform.Translate(new Vector3(0, 0, verticalAmount * moveSpeed * Time.deltaTime));
       transform.Translate(new Vector3(horizontalAmount * moveSpeed * Time.deltaTime, 0, 0));

       transform.Rotate(new Vector3(0, horizontalRotation * rotateSpeed * Time.deltaTime, 0));

       if (Input.GetKeyDown("space") && isGround == true) {
            rigidBody.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
       }
    }

    void OnTriggerEnter(Collider other) 
    {
        if (other.tag == "Ground")
        {
            isGround = true; 
        }
    }
}
