using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private GameObject gameManager;

    public int vidasGlobal;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("GameManager");
        DontDestroyOnLoad(gameManager);
        cambiarEscena("Menu");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void cambiarEscena(string escena)
    {
        SceneManager.LoadScene(escena);
    }

    public void decrementarVidas()
    {
        vidasGlobal--;
    }

    public int getVidas()
    {
        return vidasGlobal;
    }
}
