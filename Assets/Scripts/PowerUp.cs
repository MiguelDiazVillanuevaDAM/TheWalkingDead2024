using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    public int cantidad; //Para poder asignarle la puntuación a cada objeto

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Jugador"))
        {
            collision.gameObject.GetComponent<Jugador>().IncrementarPuntos(cantidad);
            Destroy(gameObject); //Destruimos el propio objeto
        }
    }
}
