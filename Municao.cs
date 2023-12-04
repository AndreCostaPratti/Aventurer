using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Municao : MonoBehaviour
{
    private Personagem InfoJogador;
    private Text Municoes;

    // Start is called before the first frame update
    void Start()
    {
        InfoJogador = GameObject.FindGameObjectWithTag("Player").GetComponent<Personagem>();
        Municoes = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        Municoes.text = InfoJogador.informaMunicao().ToString();
    }
}
