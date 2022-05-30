using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeartPickup : MonoBehaviour
{
    void OnTriggerEnter(Collider collider) {
        if(collider.gameObject.tag == "Player") {
            collider.gameObject.GetComponent<DamageHandler>().AddPickUpHealth();
            collider.gameObject.GetComponent<AudioSource>().Play();
            Destroy(gameObject);
        }
    }
}
