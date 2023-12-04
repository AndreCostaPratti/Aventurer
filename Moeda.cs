using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Moeda : MonoBehaviour
{
    private Personagem infoJogador;
    private Text MeuTexto;

    // Start is called before the first frame update
    void Start()
    {
        infoJogador = GameObject.FindGameObjectWithTag("Player").GetComponent<Personagem>();
        MeuTexto = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        MeuTexto.text = infoJogador.moeda.ToString();
    }
}
