using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OpenDoor : MonoBehaviour
{
    Animator anim;
    new AudioSource audio;
    [SerializeField]
    AudioClip closed;
    [SerializeField]
    AudioClip open;
    void Start()
    {
        audio = GetComponent<AudioSource>();
        anim = GetComponent<Animator>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Debug.Log("door");
           if (!Contador.key)
            {
                audio.clip = closed;
                audio.Play();
                anim.SetTrigger("Try");
            }

            if (Contador.key)
            {
                audio.clip= open;
                audio.Play();
                Cursor.visible = true;
                StartCoroutine(Win());
            }
        }
    }
    IEnumerator Win()
    {
        yield return new WaitForSeconds(0.2f);
        SceneManager.LoadScene("Win");
    }
}
