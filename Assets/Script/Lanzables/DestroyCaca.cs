using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class DestroyCaca : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Escenario") || collision.gameObject.CompareTag("Enemigo"))
        {
            gameObject.SetActive(false);
        }
    }
}
