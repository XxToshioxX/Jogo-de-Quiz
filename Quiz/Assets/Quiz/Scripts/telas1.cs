using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class telas : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
    }

    public void Chamainicio()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Inicio");
    }
    public void Voltaprova()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("EscolhaTeste");
    }
    public void voltasistema()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("EscolhaSistema");
    }
    public void Nivel()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("EscolhaNivel");
    }
    public void Id1()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Níve1_Identificação");
    }
    public void Id2()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Nível2_Identificação");
    }
}
