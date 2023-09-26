using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class KeyEnemies : MonoBehaviour
{
    GameObject[] allEnemies;

    Banana keyCount;

    // Start is called before the first frame update
    void Start()
    {
        allEnemies = GameObject.FindGameObjectsWithTag("Enemigo");
        keyCount = FindObjectOfType<Banana>();

    }

    // Update is called once per frame
    void Update()
    {
        
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
            keyCount.key = true;
            Debug.Log("key");
            Destroy(gameObject);
        }

    }
}