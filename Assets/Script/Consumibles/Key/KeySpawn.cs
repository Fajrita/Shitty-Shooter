using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeySpawn : MonoBehaviour
{
    [SerializeField]
    GameObject[] key;

    Transform tran;
    int i;
    void Start()
    {
        i = Random.Range(0, key.Length);
        tran = key[i].transform;
        transform.position = tran.position;
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
