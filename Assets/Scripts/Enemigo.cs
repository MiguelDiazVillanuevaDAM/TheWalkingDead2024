using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemigo : MonoBehaviour
{
    public float velocidad; //Velocidad de movimiento
    public Vector3 posicionFin; //Posicion a la que queremos q se desplace
    private Vector3 posicionInicio; //Posicion actual
    private bool moviendoAFin; //Para saber si vamos a la posicion final o ya estamos devuelta

    // Start is called before the first frame update
    void Start()
    {
        posicionInicio=transform.position; // nos da la posicion en la que estamos
        moviendoAFin=true;
    }

    // Update is called once per frame
    void Update()
    {
        MoverEnemigo();
    }

    private void MoverEnemigo()
    {
        //Si moviendoAFIN es true la posicion Destino es la fin, y si no sera la posicionInicio (vas y si ya llegaste vuelves)
        Vector3 posicionDestino = (moviendoAFin) ? posicionFin : posicionInicio;
        transform.position = Vector3.MoveTowards(transform.position, posicionDestino,velocidad*Time.deltaTime);

        if (transform.position == posicionFin) { moviendoAFin = false; }
        if (transform.position == posicionInicio) { moviendoAFin = true; }
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Jugador"))
        {
            collision.gameObject.GetComponent<Jugador>().QuitarVida();
        }
    }
}
