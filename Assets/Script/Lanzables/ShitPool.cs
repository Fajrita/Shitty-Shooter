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
    Banana banana;
    TextBanana TBanana;
    Movement move;

    void Start()
    {
        TBanana = FindObjectOfType<TextBanana>();
        hudShit = FindObjectOfType<HUDShit>();
        banana = FindObjectOfType<Banana>();
        potency = GetComponent<ShootController>();
        controller = GetComponent<CharacterController>();
        move = GetComponent<Movement>();
        //impulso = new Vector3(0, potency.timeInt, potency.timeInt);
        //Creamos la array con un tama�o igual al de la variable int primera
        shits = new GameObject[shitPoolSize];
        //De forma secuencia gracias a un bucle for creamos todas las balas, recordar
        //que estas comienzan desactivadas con lo cual no se ejecutar� su script y
        //saldr�n todas disparadas a la vez. Tambi�n fijaos en la posici�n de creaci�n:
        // el valor -10 de la �x� hace que est�n fuera de la escena por seguridad.
        for (int i = 0; i < shitPoolSize; i++)
        {
            shits[i] = Instantiate(shit, new Vector3(-10, -10f, -10f), Quaternion.identity);
            shit.SetActive(false);
        }
        posicion = new Vector3(0, 3, 0);
    }
    private void Update()
    {
        //Debug.Log(controller.velocity);
    }
    public void ShootBullet()
    {
        //Cada vez que disparemos el �puntero� del array aumenta en uno para que
        //en el siguiente disparo se�ale a la siguiente bala del array.
        shitNumber++;
        //Debug.Log(shitNumber);
        //Debug.Log(banana.countBanana);
        //En el caso de que el puntero supere el n�mero de posiciones del array
        //vuelve a 0 para seguir con el proceso.

        //Ponemos la bala, desactivada a�n, en la posici�n del objeto �GunObject�
        shits[shitNumber].transform.position = transform.position + posicion;
        //Debug.Log(potency.timePressed);
        //Debug.Log(potency.timeInt);
        impulso = new Vector3(0, potency.timeInt + adjustShootY, potency.timeInt + adjustShootZ);
        if (move.inputKey.z < 0)
        {
            shits[shitNumber].GetComponent<Rigidbody>().velocity = transform.TransformDirection(impulso);
        }
        else
        {
            shits[shitNumber].GetComponent<Rigidbody>().velocity = controller.velocity + (transform.TransformDirection(impulso));

        }//Debug.Log(shits[shitNumber].GetComponent<Rigidbody>().velocity);
        //�Activamos la bala!
        shits[shitNumber].SetActive(true);

        if (shitNumber == shitPoolSize - 1)
        {
            banana.countBanana--;
            TBanana.HudBanana();
            shitNumber = -1;
            if (banana.countBanana > 0)
            {
                Debug.Log("aqui");
                hudShit.GetComponent<HUDShit>().Reload();
            }
        }

    }
}
