using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnZombies : MonoBehaviour
{
    public GameObject player;
    public GameObject zombieObject;
    public int interval;
    public float radius;

    void Start()
    {
        StartCoroutine(ZombieSpawn());
    }
    private Vector3 GetRandomPosition()
    {
        var playerPosition = player.transform.position;
        var newPosition = playerPosition + new Vector3(Random.Range(-radius, radius), 0, Random.Range(-radius, radius));

        var down = new Vector3(0,-1, 0);
        if (Physics.Raycast (newPosition, down, out RaycastHit hit)) {
            var distanceToGround = hit.distance;
            var newY = newPosition.y - distanceToGround;
            newPosition = new Vector3(newPosition.x, newY, newPosition.z);
        }
        return newPosition;
    }
    IEnumerator ZombieSpawn() {
        while(true) {
            GameObject zombie = Instantiate(zombieObject, GetRandomPosition(), Quaternion.identity);
            zombie.GetComponent<ZombieChase>().player = player;
            Debug.Log("zombie spawned");
            yield return new WaitForSeconds(interval);
        }
    }
}
