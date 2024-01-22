using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CambioScena : MonoBehaviour
{
    IEnumerator corrutine;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    public void CargarJuego()
    {
        corrutine = CambioJuego();
        StartCoroutine(corrutine);
        
    }
    public void CargarMenu()
    {

        corrutine = CambioMenu();
        StartCoroutine(corrutine);
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    IEnumerator CambioJuego()
    {
        yield return new WaitForSecondsRealtime(0.2f);
        SceneManager.LoadScene("Juego");
    }

    IEnumerator CambioMenu()
    {
        yield return new WaitForSecondsRealtime(0.2f);
        Time.timeScale = 1f;
        AudioListener.pause = false;
        SceneManager.LoadScene("Inicio");
    }
}
