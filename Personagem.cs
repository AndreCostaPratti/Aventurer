
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Unity.VisualScripting;

public class Personagem : MonoBehaviour
{
    [Header("[IMAGEM!]")]
    public SpriteRenderer imagemPersonagem;

    [Header("[STATUS!]")]
    public int vida = 10;

    private int chances = 1;

    int vidaMax;

    [Header("[PREFABS!]")]
    public GameObject Bala;

    public GameObject Flecha;

    public GameObject Adaga;

    [Header("[FÍSICA!]")]

    public Rigidbody2D corpo;

    public bool podeMover = true;

    public float tempo;

    public float velocidade;

    public int qtd_Pulo = 0;

    private float meuTempoPulo = 0;

    public bool pode_pular = true;

    public float puloMax = 1;

    public bool pode_dano = true;

    private float meuTempoDano;

    private float meuTempoTiro = 0;

    private bool pode_atirar = true;

    private bool pode_atkAdaga = true;

    public float forcaDoSalto = 9000000000f;

    public float tempoDePuloMaximo = 0.5f;

    private float tempoDePuloAtual = 0;

    [Header("[ATAQUE!]")]

    public bool botaoAtivado = false;

    public bool bazucaColetada = false;

    public bool adagaColetada = false;

    public bool arcoColetado = false;

    private int municaoBazuca = 0;

    private int municaoArco = 0;

    private int usosAdaga = 0;

    private int chaveColetada = 0;

    public int danoDoAtaque = 5;

    public float meuTempoAdaga = 0;

    public float meuTempoTiroArco = 0;

    private Image BarraHp;

    private Animator animacao;

    private GerenciadorJogo Gj;

    [Header("[ITEM!]")]
    public bool pegouchave;

    private Text MunicaoArco;

    private Text MunicaoAdaga;

    private Text Chave;

    public int moeda = 0;

    bool andarEsquerda = false;
    bool andarDireita = false;

    void Start()
    {
        vidaMax = vida;

        corpo = GetComponent<Rigidbody2D>();
        animacao = GetComponent<Animator>();

        BarraHp = GameObject.FindGameObjectWithTag("hp_barra").GetComponent<Image>();
        Gj = GameObject.FindGameObjectWithTag("GameController").GetComponent<GerenciadorJogo>();

        MunicaoArco = GameObject.FindGameObjectWithTag("municaoTextoArco").GetComponent<Text>();
        MunicaoAdaga = GameObject.FindGameObjectWithTag("municaoTextoAdaga").GetComponent<Text>();

        Chave = GameObject.FindGameObjectWithTag("TextoChave").GetComponent<Text>();
    }

    void Update()
    {
        Apontar();
        Dano();
        Atirar();

        MunicaoArco.text = municaoArco.ToString();
        MunicaoAdaga.text = usosAdaga.ToString();
        Chave.text = chaveColetada.ToString();

        if (municaoArco <= 0)
        {
            arcoColetado = false;
        }
        if (municaoBazuca <= 0)
        {
            bazucaColetada = false;
        }
        if (usosAdaga <= 0)
        {
            adagaColetada = false;
        }
    }

    public int informaChance()
    {
        return chances;
    }

    public int informaMunicao()
    {
        return municaoBazuca;
    }

    public void Inicializar()
    {
        int chances_compradas = PlayerPrefs.GetInt("nivelChance");
        chances = chances + chances_compradas;
    }

    public void InicializarM()
    {
        int municoes_compradas = PlayerPrefs.GetInt("nivelMunicao");
        municaoBazuca = municaoBazuca + municoes_compradas;
    }

    void Apontar()
    {
        if (corpo.velocity.x > 0)
        {
            imagemPersonagem.flipX = false;
            animacao.SetBool("Andando", false);
        }
        if (corpo.velocity.x < 0)
        {
            imagemPersonagem.flipX = true;
            animacao.SetBool("Andando", false);
        }
    }

    void AcaoPulo()
    {
        if (tempoDePuloAtual < tempoDePuloMaximo)
        {
            corpo.AddForce(transform.up * forcaDoSalto);
            tempoDePuloAtual += Time.deltaTime;
        }
    }

    private void OnTriggerEnter2D(Collider2D gatilho)
    {
        if (gatilho.gameObject.tag == "Pisavel")
        {
            puloMax = 1;
            qtd_Pulo = 1;
            pode_pular = true;
            meuTempoPulo = 0;

            //TemporizadorPulo();
        }

        if (gatilho.gameObject.tag == "inimigo")
        {
            puloMax = 1;
            qtd_Pulo = 1;
            pode_pular = true;
            meuTempoPulo = 0;

            //TemporizadorPulo();
        }

        if (gatilho.gameObject.tag == "Moeda")
        {
            GameObject.FindGameObjectWithTag("SomMoeda").GetComponent<AudioSource>().Play();
            moeda++;
            Destroy(gatilho.gameObject);
        }

        if (gatilho.gameObject.tag == ("Bazuca"))
        {
            animacao.SetBool("Bazuca", true);

            if (!bazucaColetada)
            {
                int municoes_compradas = PlayerPrefs.GetInt("nivelMunicao");
                municaoBazuca = 3 + municoes_compradas;
                bazucaColetada = true;

                Destroy(gatilho.gameObject);
            }
        }

        if (gatilho.gameObject.tag == ("Adaga"))
        {
            animacao.SetBool("Adaga", true);

            if (!adagaColetada)
            {
                usosAdaga = 10;
                adagaColetada = true;

                Destroy(gatilho.gameObject);
            }
        }

        if (gatilho.gameObject.tag == ("Arco"))
        {
            animacao.SetBool("Arco", true);

            if (!arcoColetado)
            {
                municaoArco = 8;
                arcoColetado = true;

                Destroy(gatilho.gameObject);
            }
        }

        if (gatilho.tag == "Chave")
        {
            chaveColetada = 1;
            GameObject.FindGameObjectWithTag("SomChave").GetComponent<AudioSource>().Play();
            pegouchave = true;
            Destroy(gatilho.gameObject);
        }

        if (gatilho.tag == "Bau")
        {
            if (pegouchave)
            {
                GameObject.FindGameObjectWithTag("SomFlauta").GetComponent<AudioSource>().Play();
                Gj.Vitoria();
            }
        }

    }

    void TemporizadorPulo()
    {
        meuTempoPulo += Time.deltaTime;
        if (meuTempoPulo > 10.0f)
        {
            pode_pular = true;
            meuTempoPulo = 0;
        }
    }

    void Dano()
    {
        if (pode_dano == false)
        {
            TemporizadorDano();
        }
    }

    private void FixedUpdate()
    {
        Mover();
    }

    void Mover()
    {
        if (podeMover == true)
        {
            if (andarDireita)
            {
                corpo.AddForce(Vector2.right * velocidade);
            }
            if (andarEsquerda)
            {
                corpo.AddForce(Vector2.left * velocidade);
            }
        }
    }

    void OnCollisionStay2D(Collision2D colisao)
    {
        if (colisao.gameObject.tag == "inimigo")
        {
            if (pode_dano == true)
            {
                PerderHp();
                vida--;
                GameObject.FindGameObjectWithTag("SomDano").GetComponent<AudioSource>().Play();
                pode_dano = false;

                imagemPersonagem.color = UnityEngine.Color.red;

                if (vida <= 0)
                {
                    Respawn();
                    if (chances <= 0)
                    {
                        Morrer();
                    }
                }
            }
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "inimigo")
        {
            if (pode_dano == true)
            {
                PerderHp();
                vida--;
                GameObject.FindGameObjectWithTag("SomDano").GetComponent<AudioSource>().Play();
                pode_dano = false;

                imagemPersonagem.color = UnityEngine.Color.red;

                if (vida <= 0)
                {
                    Respawn();
                    if (chances <= 0)
                    {
                        Morrer();
                    }
                }
            }
        }
    }
    
    void TemporizadorDano()
    {
        meuTempoDano += Time.deltaTime;
        if (meuTempoDano > 0.5f)
        {
            pode_dano = true;
            meuTempoDano = 0;

            imagemPersonagem.color = UnityEngine.Color.white;
        }
    }

    void PerderHp()
    {
        BarraHp.fillAmount = (float)vida / (float)vidaMax;
    }

    public void Atirar()
    {
        if (pode_atirar == true)
        {
            pode_atirar = false;
            Disparo();

        }

        else
        {
            TemporizadorTiro();
        }

    }
    #region  bazuka
    public void Disparo()
    {
        if (municaoBazuca > 0)
        {
            if (bazucaColetada && pode_atirar == true)
            {
                if (imagemPersonagem.flipX == false)
                {
                    municaoBazuca--;
                    Vector3 pontoDisparo = new Vector3(transform.position.x + 1f, transform.position.y, transform.position.z);
                    GameObject BalaDisparada = Instantiate(Bala, pontoDisparo, Quaternion.identity);
                    BalaDisparada.GetComponent<ControleBala>().DirecaoBala(1);
                    Destroy(BalaDisparada, 3f);

                    animacao.SetTrigger("AtkBazuca");

                    pode_atirar = false;
                }

                if (imagemPersonagem.flipX == true)
                {
                    municaoBazuca--;
                    Vector3 pontoDisparo = new Vector3(transform.position.x - 1f, transform.position.y, transform.position.z);
                    GameObject BalaDisparada = Instantiate(Bala, pontoDisparo, Quaternion.identity);
                    BalaDisparada.GetComponent<ControleBala>().DirecaoBala(-1);
                    Destroy(BalaDisparada, 3f);

                    animacao.SetTrigger("AtkBazuca");

                    pode_atirar = false;
                }

                else
                {
                    TemporizadorTiro();
                }
            }
        }

        if (municaoBazuca <= 0)
        {
            animacao.SetBool("Bazuca", false);
            animacao.SetTrigger("PosInicial");
        }
    }
    #endregion
    #region Adaga
    public void DisparoAdaga()
    {
        if (usosAdaga > 0)
        {
            if (adagaColetada && pode_atirar == true)
            {
                if (imagemPersonagem.flipX == false)
                {
                    usosAdaga--;
                    MunicaoAdaga.text = usosAdaga.ToString();
                    Vector3 pontoDisparo = new Vector3(transform.position.x + 1f, transform.position.y, transform.position.z);
                    GameObject BalaDisparada = Instantiate(Adaga, pontoDisparo, Quaternion.identity);
                    BalaDisparada.GetComponent<ControleTiroArco>().DirecaoFlecha(1);
                    Destroy(BalaDisparada, 3f);

                    animacao.SetTrigger("AtkAdaga");

                    pode_atirar = false;
                }

                if (imagemPersonagem.flipX == true)
                {
                    usosAdaga--;
                    MunicaoAdaga.text = usosAdaga.ToString();
                    Vector3 pontoDisparo = new Vector3(transform.position.x - 1f, transform.position.y, transform.position.z);
                    GameObject BalaDisparada = Instantiate(Adaga, pontoDisparo, Quaternion.identity);
                    BalaDisparada.GetComponent<ControleTiroArco>().DirecaoFlecha(-1);
                    Destroy(BalaDisparada, 3f);

                    animacao.SetTrigger("AtkAdaga");

                    pode_atirar = false;
                }

                else
                {
                    TemporizadorAtkAdaga();
                }
            }
        }

        if (usosAdaga <= 0)
        {
            animacao.SetBool("Adaga", false);
            animacao.SetTrigger("PosInicial");
        }
    }
    public void AtirarAdaga()
    {
        if (pode_atkAdaga == true)
        {
            pode_atkAdaga = false;
            DisparoAdaga();
        }

        else
        {
            TemporizadorAtkAdaga();
        }

    }

    void TemporizadorAtkAdaga()
    {
        meuTempoAdaga += Time.deltaTime;
        if (meuTempoAdaga > 0.2f)
        {
            pode_atkAdaga = true;
            meuTempoAdaga = 0;
        }
    }
    #endregion
    #region arco
    public void DisparoArco()
    {
        if (municaoArco > 0)
        {
            if (arcoColetado && pode_atirar == true)
            {
                if (imagemPersonagem.flipX == false)
                {
                    municaoArco--;
                    MunicaoArco.text = municaoArco.ToString();
                    Vector3 pontoDisparo = new Vector3(transform.position.x + 1f, transform.position.y, transform.position.z);
                    GameObject FlechaDisparada = Instantiate(Flecha, pontoDisparo, Quaternion.identity);
                    FlechaDisparada.GetComponent<ControleTiroArco>().DirecaoFlecha(1);
                    Destroy(FlechaDisparada, 3f);

                    animacao.SetTrigger("AtkArco");

                    pode_atirar = false;
                }

                if (imagemPersonagem.flipX == true)
                {
                    municaoArco--;
                    MunicaoArco.text = municaoArco.ToString();
                    Vector3 pontoDisparo = new Vector3(transform.position.x - 1f, transform.position.y, transform.position.z);
                    GameObject FlechaDisparada = Instantiate(Flecha, pontoDisparo, Quaternion.identity);
                    FlechaDisparada.GetComponent<ControleTiroArco>().DirecaoFlecha(-1);
                    Destroy(FlechaDisparada, 3f);

                    animacao.SetTrigger("AtkArco");

                    pode_atirar = false;
                }

                else
                {
                    TemporizadorTiroArco();
                }
            }
        }

        if (municaoArco <= 0)
        {
            animacao.SetBool("Arco", false);
            animacao.SetTrigger("PosInicial");
        }
    }
    public void AtirarArco()
    {
        if (pode_atirar == true)
        {
            pode_atirar = false;
            DisparoArco();
        }

        else
        {
            TemporizadorTiroArco();
        }

    }
    #endregion


    void TemporizadorTiro()
    {
        meuTempoTiro += Time.deltaTime;
        if (meuTempoTiro > 0.2f)
        {
            pode_atirar = true;
            meuTempoTiro = 0;
        }
    }

    void TemporizadorTiroArco()
    {
        meuTempoTiroArco += Time.deltaTime;
        if (meuTempoTiroArco > 0.2f)
        {
            pode_atirar = true;
            meuTempoTiroArco = 0;
        }
    }

    public void MoverE()
    {
        if (podeMover == true)
        {
            andarEsquerda = true;
            if (velocidade != 0)
            {
                animacao.SetBool("Andando", true);
            }
        }
    }

    public void MoverD()
    {
        if (podeMover == true)
        {
            andarDireita = true;
            if (velocidade != 0)
            {
                animacao.SetBool("Andando", true);
            }
        }
    }

    public void MoverP()
    {
        if (podeMover && pode_pular == true)
        {
            if (qtd_Pulo >= puloMax)
            {
                pode_pular = false;
            }

            if (qtd_Pulo <= puloMax)
            {

                AcaoPulo();
            }
        }

        if (pode_pular == false)
        {
            TemporizadorPulo();
        }
    }

    public void IdleE()
    {
        andarEsquerda = false;
    }

    public void IdleD() 
    {
        andarDireita = false;
    }

    void Morrer()
    {
        Gj.ReceberMoedaMorreu(moeda);
        Gj.PersonagemMorreu();
    }

    void Respawn() 
    {
        chances--;
        vida = 10;
        float posX = Random.Range(-10, 10);
        Vector3 novaPos = new Vector3(posX, -2, 0);
        transform.position = novaPos;
    }
}
