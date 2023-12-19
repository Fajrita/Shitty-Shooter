using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pausa : MonoBehaviour
{
    [SerializeField]
    GameObject pauseHud;
    void Start()
    {
        Time.timeScale = 1f;
    }

    void Update()
    {
        if (Input.GetKeyDown("p"))
        {
            TogglePause();
        }
    }
    void TogglePause()
    {
        if (Time.timeScale > 0f)
        {
            Cursor.visible = true;
            Time.timeScale = 0f;
            pauseHud.SetActive(true);
            AudioListener.pause = true;
        }
        else if (Time.timeScale == 0f)
        {
            Cursor.visible = false;
            Time.timeScale = 1f;
            pauseHud.SetActive(false);
            AudioListener.pause = false;
        }
    }
}
