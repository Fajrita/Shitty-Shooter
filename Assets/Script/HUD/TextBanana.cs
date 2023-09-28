using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using static System.Net.Mime.MediaTypeNames;
using System;

public class TextBanana : MonoBehaviour
{
    Contador contador;
    int intBanana;
    string stringBanana;
    TextMeshProUGUI text;
    void Start()
    {
        contador = FindObjectOfType<Contador>();
        text = GetComponent<TextMeshProUGUI>();
        text.text = "0";
    }

    // Update is called once per frame
    void Update()
    {

        
    }
    public void HudBanana()
    {
        intBanana = contador.banana;
        stringBanana = Convert.ToString(intBanana);
        text.text = stringBanana;

    }
}
