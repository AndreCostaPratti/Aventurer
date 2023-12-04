using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ControleBala : MonoBehaviour
{
    public float velocidade_bala = 0;

    Rigidbody2D rb;

    public SpriteRenderer imagemBala;

    //private Animator animation;

    private GameObject Explosao;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = Vector2.right * velocidade_bala;
        Explosao = Resources.Load("Explodir") as GameObject;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void DirecaoBala(float direcao)
    {
        velocidade_bala *= direcao;
        Apontar();
    }

    private void OnCollisionEnter2D(Collision2D colisao)
    {
        if (colisao.gameObject.tag == "inimigo")
        {
            //Destroy(colisao.gameObject);
            Destroy(this.gameObject);

            GameObject nExplosao = Instantiate(Explosao, transform.position, Quaternion.identity);
            Destroy(nExplosao, 1f);
        }

        if (colisao.gameObject.tag == "Fantasma")
        {
            
            Destroy(this.gameObject);

            GameObject nExplosao = Instantiate(Explosao, transform.position, Quaternion.identity);
            Destroy(nExplosao, 1f);
        }

        if (colisao.gameObject.tag == "Bazuca")
        {
            
            Destroy(this.gameObject);

            GameObject nExplosao = Instantiate(Explosao, transform.position, Quaternion.identity);
            Destroy(nExplosao, 1f);
        }

        if (colisao.gameObject.tag == "Adaga")
        {

            Destroy(this.gameObject);

            GameObject nExplosao = Instantiate(Explosao, transform.position, Quaternion.identity);
            Destroy(nExplosao, 1f);
        }

        if (colisao.gameObject.tag == "Arco")
        {

            Destroy(this.gameObject);

            GameObject nExplosao = Instantiate(Explosao, transform.position, Quaternion.identity);
            Destroy(nExplosao, 1f);
        }

        if (colisao.gameObject.tag == "Moeda")
        {

            Destroy(this.gameObject);

            GameObject nExplosao = Instantiate(Explosao, transform.position, Quaternion.identity);
            Destroy(nExplosao, 1f);
        }

        if (colisao.gameObject.tag == "Pisavel")
        {
            Destroy(this.gameObject);;

            GameObject nExplosao = Instantiate(Explosao, transform.position, Quaternion.identity);
            Destroy(nExplosao, 1f);
        }
    }

    void Apontar()
    {
        imagemBala = GetComponent<SpriteRenderer>();
        if (velocidade_bala > 0)
        {
            imagemBala.flipX = false;
        }
        else if (velocidade_bala < 0)
        {
            imagemBala.flipX = true;
        }
    }


}
