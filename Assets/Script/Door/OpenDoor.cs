using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OpenDoor : MonoBehaviour
{
     Banana cKey;
    // Start is called before the first frame update
    void Start()
    {
        cKey = FindObjectOfType<Banana>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Debug.Log("door");
           if (!cKey.key)
            {

            }

            if (cKey.key)
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
