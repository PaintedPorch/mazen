using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstPersonCamera : MonoBehaviour
{
    [SerializeField] GameObject player;
    void LateUpdate()
    {
        transform.position = player.transform.position + new Vector3(0, 1, 0);
        transform.rotation = player.transform.rotation;
    }
}
