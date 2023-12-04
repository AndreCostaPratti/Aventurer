using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InimigoChao : MonoBehaviour
{
    public float velocidade = 0.1f;

    public int vida;

    public int moeda = 0;

    public bool morto = false;

    public bool tomouDano = false;

    public Transform alvo;

    public GameObject Moeda;

    public Rigidbody2D rigidbody;

    private GerenciadorJogo Gj;

    public SpriteRenderer imagemGoblin;

    private Animator animacao;

    Vector2 vetor;

    // Start is called before the first frame update
    void Start()
    {
        Gj = GameObject.FindAnyObjectByType<GerenciadorJogo>();
        animacao = GetComponent<Animator>();
        if (Gj.EstadoDoJogo() == true)
        {
            alvo = GameObject.FindWithTag("Player").transform;
            imagemGoblin = GetComponent<SpriteRenderer>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        vetor = alvo.position - transform.position;
        Andando();
        Morrer();
    }

    private void FixedUpdate()
    {
        rigidbody.velocity = vetor.normalized * velocidade;
    }

    public void Andando()
    {
        Vector2 vetor = alvo.position - transform.position;
       
        if (vetor.x > 0)
        {
            imagemGoblin.flipX = false;
        }
        else if (vetor.x < 0)
        {
            imagemGoblin.flipX = true;
        }
    }

    void OnCollisionStay2D(Collision2D colisao)
    {
        if (colisao.gameObject.tag == "Player")
        {
            animacao.SetTrigger("atk");
        }

        else
        {
            animacao.SetTrigger("andando");
        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Bala")
        {
            vida--;
        }

        if (collision.gameObject.tag == "BalaBazuca")
        {
            vida = 0;
        }

        if (collision.gameObject.tag == "Atk")
        {
            vida--;
        }
    }


    IEnumerator DanoCooldown()
    {
        tomouDano = true;
        yield return new WaitForSeconds(1f);
        tomouDano = false;
    }

    void Morrer()
    {
        if (vida <= 0)
        {
            morto = true;
            Destroy(this.gameObject);
            Instantiate(Moeda, transform.position, Quaternion.identity);
        }
        else
        {
            DanoCooldown();
        }
    }
}
