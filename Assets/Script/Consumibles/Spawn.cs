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
        if (i == 1 || i == 2)
        {
            gameObject.GetComponent<SpriteRenderer>().flipX = true;
        }
        tran = spawn[i].transform;
        Debug.Log(tran.transform.rotation.eulerAngles);
        transform.position = tran.position;


    }
}
