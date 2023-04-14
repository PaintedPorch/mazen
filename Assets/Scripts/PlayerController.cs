using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float moveSpeed = 10f;
    [SerializeField] float rotateSpeed = 250f;
    void Update()
    {
        float verticalAmount = Input.GetAxisRaw("Vertical");
        float horizontalAmount = Input.GetAxisRaw("Horizontal");
        float horizontalRotation = Input.GetAxisRaw("Mouse X");

       transform.Translate(new Vector3(0, 0, verticalAmount * moveSpeed * Time.deltaTime));
       transform.Translate(new Vector3(horizontalAmount * moveSpeed * Time.deltaTime, 0, 0));

       transform.Rotate(new Vector3(0, horizontalRotation * rotateSpeed * Time.deltaTime, 0));
    }
}
