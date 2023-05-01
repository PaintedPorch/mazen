using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFollow : MonoBehaviour
{
    GameObject player;
    Vector3 distanceToPlayer;
    float speed = .005f;

    void Start()
    {
        player = GameObject.Find("Player");
    }

    void FixedUpdate()
    {
        distanceToPlayer = player.transform.position - transform.position;
        transform.Translate(distanceToPlayer * speed);
        transform.rotation = player.transform.rotation;
    }
}
