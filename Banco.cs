using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Banco : MonoBehaviour
{
    private int valorBanco;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GuardarNobanco(int novoValor)
    {
        valorBanco = PlayerPrefs.GetInt("minhasMoedas");
        valorBanco = valorBanco + novoValor;
        PlayerPrefs.SetInt("minhasMoedas", valorBanco);
    }

    public int informarValorNoBanco()
    {
        valorBanco = PlayerPrefs.GetInt("minhasMoedas");
        return valorBanco;
    }

    public void RetirarDoBanco(int novoValor)
    {
        valorBanco = PlayerPrefs.GetInt("minhasMoedas");
        valorBanco = valorBanco - novoValor;
        PlayerPrefs.SetInt("minhasMoedas", valorBanco);
    }

    public bool Pagar(int custo)
    {
        int dinheiroBanco = informarValorNoBanco();
        if(dinheiroBanco >= custo)
        {
            RetirarDoBanco(custo);
            return true;
        }

        else
        {
            return false;
        }
    }
}
