using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Chances : MonoBehaviour
{
    private Personagem InfoJogador;
    private Text Chance;

    // Start is called before the first frame update
    void Start()
    {
        InfoJogador = GameObject.FindGameObjectWithTag("Player").GetComponent<Personagem>();
        Chance = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        Chance.text = InfoJogador.informaChance().ToString();
    }
}
