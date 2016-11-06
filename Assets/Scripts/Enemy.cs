using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityStandardAssets.Characters.FirstPerson;

public class Enemy : MonoBehaviour
{

    public List<GameObject> spawnPointList;
    public float minDistanceFromSpawnToPlayer = 30f;
    Player player;
    Animator anim;
    CharacterController character;

    void Start()
    {
        player = FindObjectOfType<Player>();
        character = GetComponent<CharacterController>();
        anim = gameObject.GetComponentInChildren<Animator>();
    }

    void Update()
    {
        anim.SetFloat("Blend", character.velocity.magnitude / 10);
    }

    public void SpawnInRandomLocation()
    {
        print("we startin to do tis");
        Vector3 playerPosition;
        if (player != null)
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

        while (currentLerpTime < lerpTime)
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
        print("stunned");
        StartCoroutine(InternalStun());
    }

    IEnumerator InternalStun()
    {
        FirstPersonController controller = GetComponent<FirstPersonController>();

        if (controller != null)
        {
            controller.DisableMovement();
            yield return new WaitForSeconds(3);
            controller.EnableMovement();
        }
    }
}
