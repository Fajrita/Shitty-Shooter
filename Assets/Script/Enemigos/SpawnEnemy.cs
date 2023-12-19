using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SpawnEnemy : MonoBehaviour
{
    float respawnTime;
    [SerializeField]
    float respawnTimeCounter = 10;

    private void Start()
    {
        respawnTime = respawnTimeCounter;
    }
    private void Update()
    {


        if (gameObject.GetComponent<SpriteRenderer>().enabled == false)
        {
            respawnTime -= Time.deltaTime;

        }
        if (respawnTime <= 0 && gameObject.GetComponent<Navigation>().enabled == false)
        {
            gameObject.GetComponent<SpriteRenderer>().enabled = true;
            gameObject.GetComponent<CapsuleCollider>().enabled = true;
            gameObject.GetComponent<Navigation>().enabled = true;
            gameObject.GetComponent<NavMeshAgent>().enabled = true;
            respawnTime = respawnTimeCounter;
        }

    }
}
