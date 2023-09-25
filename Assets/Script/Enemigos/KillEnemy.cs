using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillEnemy : MonoBehaviour
{
    Vector3 position;
    private void Start()
    {
        position = transform.position;
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Lanzable"))
        {
            gameObject.SetActive(false);
            transform.position = position;
            //Destroy(gameObject, 0.5f);

        }
    }
}
