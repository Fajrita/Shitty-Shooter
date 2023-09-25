using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Death : MonoBehaviour
{
    public LayerMask layer;
    public Image image;
    Color color;
    Movement movement;
    bool choque;
    GameObject surface;
   

    private void Start()
    {
      
        
        color = image.color;
        color.a = 0f;
        movement = FindObjectOfType<Movement>();
        surface = GameObject.FindGameObjectWithTag("Nav");


    }


    private void Update()
    {
        if (Enemigo())
        {
            Debug.Log("choque");
           
            Destroy(surface);
            movement.enabled = false;
            choque = true;
         

        }
        if (choque)
        {
            color.a += 0.01f;
            image.color = color;
            //Debug.Log(color.a);
        }
        if (color.a >= 1)
        {
            Loadscene();
        }
    }
  

    bool Enemigo()
    {
        RaycastHit Datos;
        // Cogemos la altura del personaje
        float tamaño = GetComponent<Renderer>().bounds.size.x;
        // posicion inicial, radio de la pelota, dirección, datos, distancia
       
        if (Physics.SphereCast(transform.position, tamaño/4, Vector3.left, out Datos, tamaño / 2 + 0.1f, layer))
        {
            return Physics.SphereCast(transform.position, tamaño/4, Vector3.left, out Datos, tamaño / 2 + 0.1f, layer);
        }
        if (Physics.SphereCast(transform.position, tamaño / 4, Vector3.right, out Datos, tamaño / 2 + 0.1f, layer))
        {
            return Physics.SphereCast(transform.position, tamaño / 4, Vector3.right, out Datos, tamaño / 2 + 0.1f, layer);
        }
        if (Physics.SphereCast(transform.position, tamaño / 4, Vector3.forward, out Datos, tamaño / 2 + 0.1f, layer))
        {
            return Physics.SphereCast(transform.position, tamaño / 4, Vector3.forward, out Datos, tamaño / 2 + 0.1f, layer);
        }
        if (Physics.SphereCast(transform.position, tamaño / 4, Vector3.back, out Datos, tamaño / 2 + 0.1f, layer))
        {
            return Physics.SphereCast(transform.position, tamaño / 4, Vector3.back, out Datos, tamaño / 2 + 0.1f, layer);
        }
        else
        {
            return false;
        }

    }

    void Loadscene()
    {
        SceneManager.LoadScene("Game Over");
    }
}
