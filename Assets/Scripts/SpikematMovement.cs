using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikematMovement : MonoBehaviour
{
   PlayerController playerController;

   private void Start() {
        playerController = GameObject.Find("Player").GetComponent<PlayerController>();
   }

   private void Update() {
        if (playerController.matTripWireActivated) {
            StartCoroutine(MoveUpAndDown());
        }
   }

   IEnumerator MoveUpAndDown() {
        yield return new WaitForSeconds(2);
        gameObject.transform.position = transform.position + new Vector3(0, .0012f, 0);
        yield return new WaitForSeconds(2);
        gameObject.transform.position = transform.position - new Vector3(0, .0012f, 0);
   }
}
