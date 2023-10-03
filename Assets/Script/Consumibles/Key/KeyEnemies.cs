using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class KeyEnemies : MonoBehaviour
{
    GameObject[] allEnemies;

    void Start()
    {
        allEnemies = GameObject.FindGameObjectsWithTag("Enemigo");
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            foreach(GameObject go in allEnemies)
            {
                if (!go.activeSelf)
                {
                    go.SetActive(true);
                }
            }
            Contador.key = true;
            Debug.Log("key");
            Destroy(gameObject);
        }
    }
}
