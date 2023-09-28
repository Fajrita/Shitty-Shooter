using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class ShitPool : MonoBehaviour
{
    public int shitPoolSize = 10; //Tama�o de la array de objetos a reciclar
                                  //aconsejable los posibles sin reusar uno que no est� desactivado
    public GameObject shit; //Referencia temporal para gesti�n del array con objetos prefabs
    private GameObject[] shits; //Array de objetos a reciclar
    public int shitNumber = -1; //N�mero con la posici�n del array que toca activar y gestionar

    
    Vector3 posicion;
    Vector3 impulso;
    public int adjustShootY = 5;
    public int adjustShootZ = 5;

    CharacterController controller;
    HUDShit hudShit;
    ShootController potency;
    Contador contador;
    TextBanana TBanana;
    Movement move;

    void Start()
    {
        TBanana = FindObjectOfType<TextBanana>();
        hudShit = FindObjectOfType<HUDShit>();
        contador = FindObjectOfType<Contador>();
        potency = GetComponent<ShootController>();
        controller = GetComponent<CharacterController>();
        move = GetComponent<Movement>();
        shits = new GameObject[shitPoolSize];

        for (int i = 0; i < shitPoolSize; i++)
        {
            shits[i] = Instantiate(shit, new Vector3(-10, -10f, -10f), Quaternion.identity);
            shit.SetActive(false);
        }

        posicion = new Vector3(0, 5, 0);
    }
    public void ShootBullet()
    {
        shitNumber++;
        shits[shitNumber].transform.position = transform.position + posicion;
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
            contador.banana--;
            TBanana.HudBanana();
            shitNumber = -1;
            if (contador.banana > 0)
            {
                Debug.Log("aqui");
                hudShit.GetComponent<HUDShit>().Reload();
            }
        }
    }
}
