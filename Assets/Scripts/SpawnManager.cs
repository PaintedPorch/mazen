using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    PlayerController playerController;
    [SerializeField] GameObject spikeBall;
    [SerializeField] GameObject[] spawnManagers;
    public int spawnedSpikeBallCount = 0;
    // Start is called before the first frame update
    void Start()
    {
        playerController = GameObject.Find("Player").GetComponent<PlayerController>();
    }
    void Update() 
    {
        if (playerController.ballTripWireActivated && spawnedSpikeBallCount == 0)
        {
            GameObject spikeBallInstantiate = Instantiate(spikeBall, spawnManagers[0].transform.position, transform.rotation);
            spikeBallInstantiate.name = "Spikeball";
            spawnedSpikeBallCount++;
           // StartCoroutine(SpawnCountDown());
        }
    }

    IEnumerator SpawnCountDown() 
    {
        yield return new WaitForSeconds(3);
    }       
}
