using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OpenDoor : MonoBehaviour
{
     Contador contador;
    void Start()
    {
        contador = FindObjectOfType<Contador>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Debug.Log("door");
           if (!contador.key)
            {

            }

            if (contador.key)
            {
                Loadscene();
            }
        }
    }
    void Loadscene()
    {
        SceneManager.LoadScene("Game Over");
    }
}
