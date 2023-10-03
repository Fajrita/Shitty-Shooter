using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OpenDoor : MonoBehaviour
{
    Animator anim;
    void Start()
    {
        anim = GetComponent<Animator>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Debug.Log("door");
           if (!Contador.key)
            {
                anim.SetTrigger("Try");
            }

            if (Contador.key)
            {
                Loadscene();
            }
        }
    }
    void Loadscene()
    {
        SceneManager.LoadScene("Win");
    }
}
