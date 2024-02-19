using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flip : MonoBehaviour
{
    // Start is called before the first frame update
    private SpriteRenderer sprite;
    private float posicionXAnterior;
    void Start()
    {
        posicionXAnterior=transform.position.x;
        sprite=gameObject.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        sprite.flipX=posicionXAnterior > transform.position.x;
        posicionXAnterior = transform.position.x;
    }
}
