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
    public float timePressed = 0f;
    public float timeCounter = 5;
    public int timeInt = 0;
    public int multipler = 5;
    float ancho = 1;
    float anchorX = -460;
    public Image c;
    Color cC;

    float alto = 80;
    bool lanzado;

 Banana cBanana;
  HUDShit hudShit;
    private void Start()
    {
        cBanana =FindObjectOfType<Banana>();
        hudShit = FindObjectOfType<HUDShit>();
        cC = new Color(0, 0.005f, 0, 0);
    }

    void Update()
    {
       
        if (Input.GetKeyDown("g") && cBanana.countBanana > 0 && lanzado == false) { 
            
        timePressed = Time.time;
            lanzado = true;
         
        }
        if (Input.GetKey("g") && cBanana.countBanana > 0 && lanzado == true)
        {
            ancho+= 2.4f;
            anchorX += 1.2f;
            barra.sizeDelta = new Vector2(ancho, alto);
            barra.anchoredPosition = new Vector2 (anchorX, 100);
            c.color -= cC;
            if ((Time.time - timePressed) >= timeCounter)
            {
                lanzado=false;
                Debug.Log("max");
                ancho = 0;
                anchorX = -460;
                barra.sizeDelta = new Vector2(ancho, alto);
                barra.anchoredPosition = new Vector2(anchorX, 100);
                c.color = Color.yellow;

                timePressed = Time.time - timePressed;

                timePressed *= multipler;
                timeInt = Convert.ToInt32((float)timePressed);

                hudShit.ShitLoss();
                shitPool.GetComponent<ShitPool>().ShootBullet();

            }
        }

        if (Input.GetKeyUp("g") && cBanana.countBanana > 0 && lanzado == true)
        {
            lanzado = false;
            ancho = 0;
            anchorX = -460;
            barra.sizeDelta = new Vector2(ancho, alto);
            barra.anchoredPosition = new Vector2(anchorX, 100);
            c.color = Color.yellow;
            timePressed = Time.time - timePressed;
            timePressed *= multipler;
            timeInt = Convert.ToInt32((float)timePressed);
            hudShit.ShitLoss();
            shitPool.GetComponent<ShitPool>().ShootBullet();
        }
    }
}
