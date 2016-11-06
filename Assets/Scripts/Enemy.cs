﻿using UnityEngine;
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
        print("we startin to do tis");
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
        while (Vector3.Distance(playerPosition, spawnPoint) <= minDistanceFromSpawnToPlayer)
        {
            spawnPoint = spawnPointList[Random.Range(0, spawnPointList.Count - 1)].transform.position;
        }

        StartCoroutine(LerpToSpawn(spawnPoint));
    }

    IEnumerator LerpToSpawn(Vector3 spawnPos)
    {
        float lerpTime = 0.3f;
        float currentLerpTime = 0;

        Vector3 startPos = transform.position;
        
        while(currentLerpTime < lerpTime)
        {
            currentLerpTime += Time.deltaTime;
            float t = currentLerpTime / lerpTime;
            t = Mathf.Cos(t * Mathf.PI * 0.5f);
            transform.position = Vector3.Lerp(spawnPos, startPos, t);
            yield return null;
        }
        
    }

    public void Stun()
    {

    }
}
