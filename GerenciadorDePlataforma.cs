using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GerenciadorDePlataforma : MonoBehaviour
{
    public int indicePlataforma;

    public List<GameObject> listaPlataforma;

    public float tempoPlataforma;

    public float contadorPlataforma;

    // Start is called before the first frame update
    void Start()
    {
        DesativarPlataformas();
        listaPlataforma[indicePlataforma].SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        AtivaPlataforma();
    }

    void DesativarPlataformas()
    {
        for (int i = 0; i < listaPlataforma.Count; i++)
        {
            listaPlataforma[i].SetActive(false);
        }
    }

    void AtivaPlataforma()
    {
        if (contadorPlataforma < tempoPlataforma)
        {
            contadorPlataforma += Time.deltaTime;
        }
        else
        {
            contadorPlataforma = 0;
            listaPlataforma[indicePlataforma].SetActive(false);

            if (indicePlataforma < listaPlataforma.Count - 1)
            {
                indicePlataforma++;
            }
            else
            {
                indicePlataforma = 0;
            }

            listaPlataforma[indicePlataforma].SetActive(true);

        }
    }
}
