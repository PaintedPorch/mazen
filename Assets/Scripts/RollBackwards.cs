using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RollBackwards : MonoBehaviour
{
    Rigidbody ballRb;
    float moveSpeed = .02f;
    PlayerController playerController;
    void Start()
    {
        playerController = GameObject.Find("Player").GetComponent<PlayerController>();
        ballRb = gameObject.GetComponent<Rigidbody>();
    }

    void Update() 
    {
        if (playerController.ballTripWireActivated) 
        {
            ballRb.AddForce(new Vector3(-moveSpeed, 0, 0), ForceMode.Impulse);
            ballRb.AddTorque(new Vector3(0, 0, moveSpeed));
        }
    }

    void OnTriggerEnter(Collider other) 
    {
        if (other.tag == "Tripwire_Spikeball")
        {
            playerController.ballTripWireActivated = true;
        }
        if (other.tag == "BallBarrier") {
            Destroy(gameObject);
        }
    }
}
