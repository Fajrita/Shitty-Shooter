using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BananaTriger : MonoBehaviour
{
    public Banana banana;
    public HUDShit hudShit;
    public TextBanana TBanana;
    SpriteRenderer render;
    CapsuleCollider coll;

    private float respawnTime;
    private float respawnTimeCounter = 15;
    // Start is called before the first frame update
    void Start()
    {
        banana = FindObjectOfType<Banana>();
        hudShit = FindObjectOfType<HUDShit>();
        TBanana = FindObjectOfType<TextBanana>();
        render = GetComponent<SpriteRenderer>();
        coll = GetComponent<CapsuleCollider>(); 

        respawnTime = respawnTimeCounter;
    }

    // Update is called once per frame
    void Update()
    {
       
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
    private void OnDisable()
    {
        Debug.Log("disable");
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            banana.countBanana++;
            TBanana.HudBanana();
            render.enabled = false;
            coll.enabled = false;
            //gameObject.SetActive(false);
            
            if (banana.countBanana == 1)
            {
                hudShit.GetComponent<HUDShit>().Reload();
            }
        }
            
    }
}
