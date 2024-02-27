using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class ControlMenu : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void onBotonJugar()
    {
        SceneManager.LoadScene("Plataforma1");
    }
    public void onBotonCreditos()
    {
        SceneManager.LoadScene("Creditos");
    }
    public void onBotonSalir()
    {
        Application.Quit();
    }
    public void onBotonMenu()
    {
        SceneManager.LoadScene("Menu");
    }
}
