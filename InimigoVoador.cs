using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class InimigoVoador : MonoBehaviour
{
    public Transform alvo;

    public InimigoVoador(Transform alvo)
    {
        this.alvo = alvo;
    }

    public int vida;

    public float velocidade;

    private GerenciadorJogo Gj;

    public SpriteRenderer imagemCaveira;

    public Rigidbody2D rg;

    public GameObject Moeda;

    public bool morto = false;

    public bool tomouDano = false;

    Vector2 vetor;

    // Start is called before the first frame update
    void Start()
    {
        rg = GetComponent<Rigidbody2D>();
        Gj = GameObject.FindAnyObjectByType<GerenciadorJogo>();
        if (Gj.EstadoDoJogo() == true)
        {
            alvo = GameObject.FindWithTag("Player").transform;
        }
    }

    // Update is called once per frame
    void Update()
    {

        //Vector2 newPos = Vector2.MoveTowards(transform.position, alvo.position, velocidade * Time.deltaTime);
        vetor = alvo.position - transform.position;
        

        if (vetor.x > 0)
        {
            imagemCaveira.flipX = true;
        }
        else if (vetor.x < 0) 
        {
            imagemCaveira.flipX = false;
        }

        Morrer();
        //Debug.Log(rigidbody.velocity);
        //transform.position = Vector2.MoveTowards(transform.position, alvo.position, velocidade*Time.deltaTime);
    }

    private void FixedUpdate()
    {
        rg.velocity = vetor.normalized * velocidade;
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

    private void OnTriggerEnter2D(Collider2D collision)
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
