using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Respostas : MonoBehaviour
{
    public Text Resposta;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Resposta.text = PlayerPrefs.GetInt("Score").ToString();
    }
}
