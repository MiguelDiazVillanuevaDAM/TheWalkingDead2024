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

    //Para la utilizacion del Animator del jugador
    private Animator animator;

    //Para controlar cuando coincida con enemigos
    public bool vulnerable;

    //Puntuaci�n del PowerUp
    public int puntuacion;

    // Start is called before the first frame update
    void Start()
    {
        vulnerable = true;
        rb2d = GetComponent<Rigidbody2D>();
        spRd = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
        puntuacion = 0;
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


        //Movimiento de salto
        if (isJumping)
        {
            animator.SetBool("isJumping", true);   
        }
        else
        {
            animator.SetBool("isJumping", false);
        }

        //Si no se mueve tendra una animacion y si se mueve tendra otra, lo hacemos con el isWalking que lo declaramos anteriormente en Animator
        if (movimientoH != 0)
        {
            animator.SetBool("isWalking", true);
        }
        else
        {
            animator.SetBool("isWalking", false);
        }

        //Si se pullsa el bot�n de saltar (Jump) y adem�s ya no estoy saltando
        if (Input.GetButton("Jump") && !isJumping)
        {
            //A�ado una fuerza al RigidBody con un par�metro de entrada que es un vector de 
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

    public void QuitarVida()
    {
        if (vulnerable)
        {
            vulnerable = false;
            Invoke("HacerVulnerable", 1f); //Cuando pase un segundo vuelves a hacerle vulnerable
            spRd.color = Color.red;
        }
    }

    public void IncrementarPuntos(int cantidad)
    {
        puntuacion += cantidad;
        Debug.Log("Has codigo: "+cantidad);
        Debug.Log("Total acumulado: " + puntuacion);
    }

    private void HacerVulnerable()
    {
        vulnerable = true;
        spRd.color = Color.white;
    }
}
