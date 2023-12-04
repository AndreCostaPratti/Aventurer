using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GerenciadorJogo : MonoBehaviour
{
    public bool GameLigado = false;

    public float TelaVitoriaMenuAtiva = 0;

    public GameObject TelaGameOver;

    public GameObject TelaVitoria;

    public GameObject TelaVitoriaMenu;

    public GameObject Creditos;

    public GameObject TelaLoja;

    public GameObject TelaPause;

    private Banco meuBanco;

    // Start is called before the first frame update
    void Start()
    {
        meuBanco = GetComponent<Banco>();
        GameLigado=false;
        Time.timeScale= 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public bool EstadoDoJogo()
    {
        return GameLigado;
    }

    public void Pause()
    {
        TelaPause.SetActive(true);
        GameLigado = false;
        Time.timeScale = 0;
    }

    public void Voltar()
    {
        TelaPause.SetActive(false);
        GameLigado = true;
        Time.timeScale = 1;
    }

    public void LigarJogo()
    {
        GameLigado = true;
        Time.timeScale= 1;
        GameObject.FindGameObjectWithTag("Player").GetComponent<Personagem>().Inicializar();
        GameObject.FindGameObjectWithTag("Player").GetComponent<Personagem>().InicializarM();
        GameObject.FindGameObjectWithTag("TrilhaSonora").GetComponent<AudioSource>().Play();
    }

    public void Vitoria()
    {
        TelaVitoria.SetActive(true);
        GameLigado = false;
        GameObject.FindGameObjectWithTag("TrilhaSonora").GetComponent<AudioSource>().Stop();
        //StartCoroutine("AtivarTelaVitoria");
        Time.timeScale = 0;
    }

    IEnumerator AtivarTelaVitoria() 
    {
        TelaVitoriaMenu.SetActive(true);
        yield return new WaitForSeconds(2f);
        TelaVitoriaMenu.SetActive(false);
    }

    public void TelaVitoriaAtivar()
    {
        TelaVitoriaMenuAtiva += Time.deltaTime;
        if (TelaVitoriaMenuAtiva > 0.2f)
        {
            TelaVitoriaMenu.SetActive(true);
        }
    }

    public void PersonagemMorreu()
    {
        TelaGameOver.SetActive(true);
        GameLigado = false;
        GameObject.FindGameObjectWithTag("TrilhaSonora").GetComponent<AudioSource>().Stop();
        Time.timeScale = 0;
    }

    public void Reiniciar()
    { 
        SceneManager.LoadScene(0);
    }

    public void Loja()
    {
        TelaLoja.SetActive(true);
        GameObject.FindGameObjectWithTag("TrilhaSonora").GetComponent<AudioSource>().Stop();
    }

    public void Credito()
    {
        Creditos.SetActive(true);
        GameObject.FindGameObjectWithTag("TrilhaSonora").GetComponent<AudioSource>().Stop();
    }

    public void SairJogo() 
    {
        Debug.Log("Sair do Jogo");
        Application.Quit();
    }
    public void ReceberMoedaMorreu(int n_moedas)
    {
        meuBanco.GuardarNobanco(n_moedas);
    }

    public void SomBotao()
    {
        GameObject.FindGameObjectWithTag("SomBotao").GetComponent<AudioSource>().Play();
    }
}
