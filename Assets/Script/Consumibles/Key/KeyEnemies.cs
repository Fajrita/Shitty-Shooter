using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class KeyEnemies : MonoBehaviour
{
    GameObject[] allEnemies;
    new AudioSource audio;
    BoxCollider col;
    SpriteRenderer rend;

    void Start()
    {
        Contador.key = false;
        col = GetComponent<BoxCollider>();
        rend = GetComponent<SpriteRenderer>();  
        audio = GetComponent<AudioSource>();
        allEnemies = GameObject.FindGameObjectsWithTag("Enemigo");
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            foreach(GameObject go in allEnemies)
            {
                if (go.GetComponent<SpriteRenderer>().enabled == false)
                {
                    go.GetComponent<SpriteRenderer>().enabled = true;
                    go.GetComponent<Navigation>().enabled = true;
                    go.GetComponent<NavMeshAgent>().enabled = true;
                    go.GetComponent<CapsuleCollider>().enabled = true;
                }
            }
            StartCoroutine(ObtainKey());
        }
    }
    IEnumerator ObtainKey()
    {
        audio.Play();
        Contador.key = true;
        rend.enabled = false;
        col.enabled = false;
        yield return new WaitForSeconds(0.2f);
        Destroy(gameObject);

    }
}
