using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpriteKey : MonoBehaviour
{
    public GameObject HUDKey;
    void Start()
    {
        
    }

    void Update()
    {
        if (Contador.key) HUDKey.SetActive(true);
    }
}
