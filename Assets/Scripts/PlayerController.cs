using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    float moveSpeed = 10f;
    void Update()
    {
        float verticalAmount = Input.GetAxisRaw("Vertical");
        float horizontalAmount = Input.GetAxisRaw("Horizontal");

       transform.Translate(new Vector3(0, 0, verticalAmount * moveSpeed * Time.deltaTime));
       transform.Translate(new Vector3(horizontalAmount * moveSpeed * Time.deltaTime, 0, 0));
    }
}
