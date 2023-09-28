using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;


public class ShootController : MonoBehaviour
{
    public GameObject shitPool;
    public RectTransform barra;
    Contador contador;
    HUDShit hudShit;

    public float timePressed = 0f;
    [SerializeField]
    float timeCounter = 5;
    public int timeInt = 0;
    public int multipler = 5;
    float ancho = 1;
    float anchorX = -460;
    public Image c;
    Color cC;

    float alto = 80;
    bool lanzado;
    private void Start()
    {
        contador = FindObjectOfType<Contador>();
        hudShit = FindObjectOfType<HUDShit>();
        cC = new Color(0, 0.005f, 0, 0);
    }

 

    void Update()
    {
        Debug.Log(timePressed);

        if (Input.GetKeyDown("g") && contador.banana > 0 && lanzado == false) {

            timePressed = 0;
            lanzado = true;
         
        }
        if (Input.GetKey("g") && contador.banana > 0 && lanzado == true)
        {
            timePressed += Time.deltaTime;
            ancho += 2.4f;
            anchorX += 1.2f;
            barra.sizeDelta = new Vector2(ancho, alto);
            barra.anchoredPosition = new Vector2 (anchorX, 100);
            c.color -= cC;
            if (timePressed >= timeCounter)
            {
                lanzado=false;
                Debug.Log("max");
                ancho = 0;
                anchorX = -460;
                barra.sizeDelta = new Vector2(ancho, alto);
                barra.anchoredPosition = new Vector2(anchorX, 100);
                c.color = Color.yellow;

                //timePressed = Time.deltaTime - timePressed;

                timePressed *= multipler;
                timeInt = Convert.ToInt32((float)timePressed);

                hudShit.ShitLoss();
                shitPool.GetComponent<ShitPool>().ShootBullet();

            }
        }

        if (Input.GetKeyUp("g") && contador.banana > 0 && lanzado == true)
        {
            lanzado = false;
            ancho = 0;
            anchorX = -460;
            barra.sizeDelta = new Vector2(ancho, alto);
            barra.anchoredPosition = new Vector2(anchorX, 100);
            c.color = Color.yellow;
            //timePressed = Time.deltaTime - timePressed;
            timePressed *= multipler;
            timeInt = Convert.ToInt32((float)timePressed);
            hudShit.ShitLoss();
            shitPool.GetComponent<ShitPool>().ShootBullet();
        }
    }
}
