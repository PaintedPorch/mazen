using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightSource : MonoBehaviour
{
    [SerializeField] GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("LightDimmer", 2f, 3f);
    }

    void Update()
    {
        transform.position = player.transform.position + new Vector3(0, 2.5f, 0);
        transform.rotation = player.transform.rotation;

        if (GetComponent<Light>().intensity <= 0)
        {
            // Game Over, Level Restarts
            Debug.Log("Game Over!");
        }
    }

    void LightDimmer()
    {
        Light light = GetComponent<Light>();
        light.intensity -= .1f;
    }
}
