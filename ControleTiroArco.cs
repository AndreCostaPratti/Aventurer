using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ControleTiroArco : MonoBehaviour
{
    public float velocidade_bala = 0;

    Rigidbody2D rb;

    public SpriteRenderer imagemFlecha;

    private Animator animation;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = Vector2.right * velocidade_bala;
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void DirecaoFlecha(float direcao)
    {
        velocidade_bala *= direcao;
        Apontar();
    }

    private void OnCollisionEnter2D(Collision2D colisao)
    {
        if (colisao.gameObject.tag == "inimigo")
        {
            Destroy(this.gameObject); 
        }

        if (colisao.gameObject.tag == "Pisavel")
        {
            Destroy(this.gameObject);
        }
    }

    void Apontar()
    {
        imagemFlecha = GetComponent<SpriteRenderer>();
        if (velocidade_bala > 0)
        {
            imagemFlecha.flipX = false;
        }
        else if (velocidade_bala < 0)
        {
            imagemFlecha.flipX = true;
        }
    }

}

