using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Loja : MonoBehaviour
{
    public Text valorChance;

    public Text valorMunicao;

    private Banco meuBanco;

    // Start is called before the first frame update
    void Start()
    {
        meuBanco = GameObject.FindGameObjectWithTag("GameController").GetComponent<Banco>();
    }

    // Update is called once per frame
    void Update()
    {
        int chanceNivel = PlayerPrefs.GetInt("nivelChance") + 1;
        int custo = (chanceNivel * 5);
        valorChance.text = "Chance LV: " + chanceNivel.ToString() + " $: " + custo.ToString();

        int municaoNivel = PlayerPrefs.GetInt("nivelMunicao") + 1;
        int custoM = (municaoNivel * 5);
        valorMunicao.text = "Munição LV: " + municaoNivel.ToString() + " $: " + custoM.ToString();
    }

    public void ComprarChance()
    {
        int chances_compradas = PlayerPrefs.GetInt("nivelChance") + 1;
        int custo = (chances_compradas * 5);
        
        if(meuBanco.Pagar(custo) == true)
        {
            PlayerPrefs.SetInt("nivelChance", chances_compradas);
        }
        
        else 
        {
            
        }
    }

    public void ComprarMunicao()
    {
        int municoes_compradas = PlayerPrefs.GetInt("nivelMunicao") + 1;
        int custoM = (municoes_compradas * 5);

        if (meuBanco.Pagar(custoM) == true)
        {
            PlayerPrefs.SetInt("nivelMunicao", municoes_compradas);
        }

        else
        {

        }
    }
}
