using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    [SerializeField]
    GameObject[] spawn;
    Transform tran;
    int i;
    void Start()
    {
        i = Random.Range(0, spawn.Length);
        tran = spawn[i].transform;
        transform.position = tran.position;        
    }
}
