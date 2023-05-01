using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float moveSpeed = 10f;
    [SerializeField] float rotateSpeed = 250f; 
    [SerializeField] bool isGround = true;
    [SerializeField] float jumpForce = 2500f;
    Rigidbody rigidBody;
    public bool matTripWireActivated = false;
    public bool ballTripWireActivated = false;
    public bool gameOver = false;
    Light lightIntensity;

    void Start() 
    {
        rigidBody = GetComponent<Rigidbody>();    
        lightIntensity = GameObject.Find("FollowLight").GetComponent<Light>();
    }

    void Update()
    {
        if (!gameOver) {
            float verticalAmount = Input.GetAxisRaw("Vertical");
            float horizontalAmount = Input.GetAxisRaw("Horizontal");
            float horizontalRotation = Input.GetAxisRaw("Mouse X");

            transform.Translate(new Vector3(0, 0, verticalAmount * moveSpeed * Time.deltaTime));
            transform.Translate(new Vector3(horizontalAmount * moveSpeed * Time.deltaTime, 0, 0));

            transform.Rotate(new Vector3(0, horizontalRotation * rotateSpeed * Time.deltaTime, 0));
        }

       if (Input.GetKeyDown("space") && isGround == true && gameOver == false) {
            rigidBody.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isGround = false;
       }

       if (lightIntensity.intensity <= .1f) {
            gameOver = true;
       }
    }

    void OnTriggerEnter(Collider other) 
    {
        if (other.tag == "Ground")
        {
            isGround = true; 
        }
        else if (other.tag == "Endpoint") {
            Invoke("LoadNextLevel", 1f);
        }   

        if (other.tag == "Tripwire_Spikemat") {
            StartCoroutine(TempActivate());
        }

        if (other.tag == "Tripwire_Spikeball") {
            ballTripWireActivated = true;
        }

        if (other.tag == "Spike") {
            gameOver = true;
        }
    }

    void LoadNextLevel()
    {
        SceneManager.LoadScene("Level1");
    }

    IEnumerator TempActivate() {
        matTripWireActivated = true;
        yield return new WaitForSeconds(2);
        matTripWireActivated = false;
    }
}
