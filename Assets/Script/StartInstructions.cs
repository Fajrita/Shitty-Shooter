using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartInstructions : MonoBehaviour
{
    public Movement pMov;
    public ShootController pshoot;
    public GameObject startPanel;
    void Start()
    {
        pMov.enabled = false;
        Cursor.visible = false;
        AudioListener.pause = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("z"))
        {
            StartCoroutine(Exit());
        }
    }

    IEnumerator Exit()
    {

        startPanel.SetActive(false);
        yield return new WaitForSeconds(0.5f);
        pMov.enabled = true;
        pshoot.enabled = true;
    }
}
