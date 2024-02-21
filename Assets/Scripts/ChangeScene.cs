using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ChangeScene : MonoBehaviour
{
    public string nextScene; //Cual es la siguiente escena a la que tiene q ir
    private GameManager gameManager;
    // Start is called before the first frame update
    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Jugador"))
        {
            gameManager.cambiarEscena(nextScene);
            Destroy(gameObject);
        }
    }
}
