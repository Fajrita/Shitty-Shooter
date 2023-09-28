using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HUDShit : MonoBehaviour
{
    public GameObject hUDShit; //Referencia temporal para gesti�n del array con objetos prefabs
    private GameObject[] hUDShits; //Array de objetos a reciclar
    public int shitNumber = -1;
    ShitPool shitPool;
    public float espaciado = -100;
    float NewEspaciado = 0;
    RectTransform rt;
   
    void Start()
    {
        rt = hUDShit.GetComponent<RectTransform>();
        shitPool = FindObjectOfType<ShitPool>();
        hUDShits = new GameObject[shitPool.shitPoolSize];
        for (int i = 0; i < shitPool.shitPoolSize; i++)
        {
            rt.anchoredPosition = new Vector2(-500 - NewEspaciado, -79);
            hUDShits[i] = Instantiate(hUDShit, transform, false);     
            hUDShit.SetActive(false);
            NewEspaciado += espaciado;
        }
    }
    public void Reload()
    {
        for (int i = 0; i < shitPool.shitPoolSize; i++)
        {
            hUDShits[i].SetActive(true);
        }
    }
    public void ShitLoss()
    {
        for (int i = 0; i < shitPool.shitNumber +2; i++)
        {
            hUDShits[i].SetActive(false);
        }
    }
}
