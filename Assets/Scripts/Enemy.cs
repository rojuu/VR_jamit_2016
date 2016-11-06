using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Enemy : MonoBehaviour {

    public List<GameObject> spawnPointList;
    public float minDistanceFromSpawnToPlayer = 30f;
    Player player;

    void Start()
    {
        player = FindObjectOfType<Player>();
    }

	public void SpawnInRandomLocation()
    {
        Vector3 playerPosition;
        if(player != null)
        {
            playerPosition = player.transform.position;
        }
        else
        {
            playerPosition = Vector3.zero;
        }

        Vector3 spawnPoint = playerPosition;
        while (Vector3.Distance(playerPosition, spawnPoint) >= minDistanceFromSpawnToPlayer)
        {
            spawnPoint = spawnPointList[Random.Range(0, spawnPointList.Count - 1)].transform.position;
            player.transform.position = spawnPoint;
        }
    }

    public void Stun()
    {

    }
}
