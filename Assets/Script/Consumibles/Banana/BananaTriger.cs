using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BananaTriger : MonoBehaviour
{
    
    HUDShit hudShit;
    TextBanana TBanana;
    SpriteRenderer render;
    CapsuleCollider coll;

    private float respawnTime;
    private float respawnTimeCounter = 15;

    void Start()
    {
        Contador.banana = 0;

        hudShit = FindObjectOfType<HUDShit>();
        TBanana = FindObjectOfType<TextBanana>();
        render = GetComponent<SpriteRenderer>();
        coll = GetComponent<CapsuleCollider>(); 

        respawnTime = respawnTimeCounter;
    }
    private void FixedUpdate()
    {
        if (coll.enabled == false)
        {
            respawnTime -= Time.deltaTime;
        }
        if (respawnTime <= 0)
        {
            render.enabled = true;
            coll.enabled =true;
            respawnTime = respawnTimeCounter;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Enter");
        if (other.gameObject.tag == "Player")
        {
            gameObject.GetComponent<AudioSource>().Play();
            Contador.banana++;
            TBanana.HudBanana();
            render.enabled = false;
            coll.enabled = false;
            
            
            if (Contador.banana == 1)
            {
                hudShit.GetComponent<HUDShit>().Reload();
            }
        }
            
    }
}
