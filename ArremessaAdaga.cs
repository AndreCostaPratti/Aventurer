using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ArremessaAdaga : MonoBehaviour
{
    public float velocidade_adaga = 0;

    Rigidbody2D rb;

    public SpriteRenderer imagemAdaga;

    //private Animator animation;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = Vector2.right * velocidade_adaga;

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void DirecaoAdaga(float direcao)
    {
        velocidade_adaga *= direcao;
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
        imagemAdaga = GetComponent<SpriteRenderer>();
        if (velocidade_adaga > 0)
        {
            imagemAdaga.flipX = false;
        }
        else if (velocidade_adaga < 0)
        {
            imagemAdaga.flipX = true;
        }
    }
}
