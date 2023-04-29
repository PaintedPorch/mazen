using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RollBackwards : MonoBehaviour
{
    Rigidbody ballRb;
    float moveSpeed = .02f;
    PlayerController playerController;
    GameObject spikeBall;
    SpawnManager spawnManager;
    void Start()
    {
        playerController = GameObject.Find("Player").GetComponent<PlayerController>();
        spawnManager = GameObject.Find("SpawnManagers").GetComponent<SpawnManager>();
        spikeBall = GameObject.Find("Spikeball");
        ballRb = spikeBall.GetComponent<Rigidbody>();
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
        if (other.tag == "Barrier") {
            Destroy(gameObject);
            playerController.ballTripWireActivated = false;
            spawnManager.spawnedSpikeBallCount = 0;
        }
    }
}
