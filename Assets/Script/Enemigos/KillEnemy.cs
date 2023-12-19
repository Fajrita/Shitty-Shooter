using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class KillEnemy : MonoBehaviour
{
    Vector3 position;
    IEnumerator corrutine;
    private void Start()
    {
        position = transform.position;

    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Lanzable"))
        {
            corrutine = Muerte();
            StartCoroutine(corrutine);
            
            transform.position = position;
        }
    }

    IEnumerator Muerte()
    {
        gameObject.GetComponent<AudioSource>().Play();
        gameObject.GetComponent<SpriteRenderer>().enabled = false;
        gameObject.GetComponent<Navigation>().enabled = false;
        gameObject.GetComponent<NavMeshAgent>().enabled = false;
        gameObject.GetComponent<CapsuleCollider>().enabled = false;
        yield return new WaitForSeconds(0.5f);
        
        //gameObject.GetComponent<SpriteRenderer>().enabled = true;
        //gameObject.GetComponent<CapsuleCollider>().enabled = true;
        //gameObject.SetActive(false);
    }
}
