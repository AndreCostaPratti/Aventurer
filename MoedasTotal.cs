using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoedasTotal : MonoBehaviour
{
    private Banco meuBanco;
    private Text MeuTexto;

    // Start is called before the first frame update
    void Start()
    {
        meuBanco = GameObject.FindGameObjectWithTag("GameController").GetComponent<Banco>();
        MeuTexto = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        MeuTexto.text = meuBanco.informarValorNoBanco().ToString();
    }
}
