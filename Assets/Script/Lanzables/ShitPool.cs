using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class ShitPool : MonoBehaviour
{
    public int shitPoolSize = 10;
    public GameObject shit;
    private GameObject[] shits;
    public int shitNumber = -1;
   
    Vector3 posicion;
    Vector3 impulso;
    public int adjustShootY = 5;
    public int adjustShootZ = 5;

    CharacterController controller;
    HUDShit hudShit;
    ShootController potency;
    TextBanana TBanana;
    Movement move;
    Transform shooter;
    new AudioSource audio;

    void Start()
    {
        shooter = gameObject.transform.Find("Shooter");
        audio = GetComponent<AudioSource>();
        TBanana = FindObjectOfType<TextBanana>();
        hudShit = FindObjectOfType<HUDShit>();
        potency = GetComponent<ShootController>();
        controller = GetComponent<CharacterController>();
        move = GetComponent<Movement>();
        shits = new GameObject[shitPoolSize];

        for (int i = 0; i < shitPoolSize; i++)
        {
            shits[i] = Instantiate(shit, new Vector3(-10, -10f, -10f), Quaternion.identity);
            shit.SetActive(false);
        }

        posicion = new Vector3(0, 5, 4) ;
    }
    public void ShootBullet()
    {
        audio.Play();
        shitNumber++;
        shits[shitNumber].transform.position = shooter.position;
        impulso = new Vector3(0, potency.timeInt + adjustShootY, potency.timeInt + adjustShootZ);

        if (move.inputKey.z < 0)
        {
            shits[shitNumber].GetComponent<Rigidbody>().velocity = transform.TransformDirection(impulso);
        }
        else
        {
            shits[shitNumber].GetComponent<Rigidbody>().velocity = controller.velocity + (transform.TransformDirection(impulso));
        }

        shits[shitNumber].SetActive(true);

        if (shitNumber == shitPoolSize - 1)
        {
            Contador.banana--;
            TBanana.HudBanana();
            shitNumber = -1;
            if (Contador.banana > 0)
            {
                hudShit.GetComponent<HUDShit>().Reload();
            }
        }
    }
}
