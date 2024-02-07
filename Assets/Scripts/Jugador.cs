using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jugador : MonoBehaviour
{
    //Movimiento del jugador
    [Range(1, 10)] public float velocidad;
    Rigidbody2D rb2d;
    SpriteRenderer spRd;

    //Salto del jugador
    //Para averiguar si esta saltando. De esta forma no permitiremos que se salte varias veces en el aire
    bool isJumping = false;
    [Range(1, 500)] public float potenciaSalto; //Potencia de salto


    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        spRd = GetComponent<SpriteRenderer>();

    }

    // Update is called once per frame
    void Update()
    {
        //Averiguo si estoy parado (0), moviendome hacia la derecha (1) o moviendome hacia la izquierda (-1)
        float movimientoH = Input.GetAxisRaw("Horizontal");

        //Eje x:
        //movimientoH: Para indicar la direccion del movimiento
        //Eje y:
        //Obtengo la que tenia antes mediante rb2d.velocity.y
        //rb2d.velocity: Le indica al Rigidbody2d la velocidad que queremos que tenga
        rb2d.velocity = new Vector2(movimientoH*velocidad, rb2d.velocity.y);

        //Comprobamos el valor de movimientoH , si te mueves a la derecha el personaje mira a la derecha y viceversa
        if (movimientoH > 0)
        {
            spRd.flipX = false;
        }
        else if (movimientoH < 0)
        {
            spRd.flipX = true;
        }

        //Si se pullsa el botón de saltar (Jumop) y además ya no estoy saltando
        if (Input.GetButton("Jump") && !isJumping)
        {
            //Añado una fuerza al RigidBody con un parámetro de entrada que es un vector de 
            //2 dimensiones en el cual la x se queda en 0 y la y pasa a 1
            //Multiplico el eje y por la potencia de salto ya que x=0
            rb2d.AddForce(Vector2.up * potenciaSalto);
            //Indico que estoy saltando
            isJumping = true;
        }


    }

   private void OnCollisionEnter2D(Collision2D otherObject)
    {
        if (otherObject.gameObject.CompareTag("SueloPrincipal"))
        {
            isJumping = false;

            //Reducimos la velocidad en el eje y a 0 (le quitamos la fuerza de salto)
            rb2d.velocity = new Vector2(rb2d.velocity.x, 0);
        }
    }
}
