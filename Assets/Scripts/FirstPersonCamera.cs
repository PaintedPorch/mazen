using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstPersonCamera : MonoBehaviour
{
    [SerializeField] GameObject player;
    void LateUpdate()
    {
        transform.position = player.transform.position;
        transform.rotation = player.transform.rotation;
    }
}
