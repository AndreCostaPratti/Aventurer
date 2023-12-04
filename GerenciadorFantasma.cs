using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GerenciadorFantasma : MonoBehaviour
{
    public int indiceFantasma;

    public List<GameObject> listaFantasma;

    public float tempoFantasma;

    public float contadorFantasma;

    SpriteRenderer sprite;

    bool coletouChave;

    // Start is called before the first frame update
    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
        DesativarFantasma();
        listaFantasma[indiceFantasma].SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        if(!coletouChave)
            AtivaFantasma();
    }



    void DesativarFantasma()
    {
        for (int i = 0; i < listaFantasma.Count; i++)
        {
            listaFantasma[i].SetActive(false);
        }
    }

    void AtivaFantasma()
    {
        if (contadorFantasma < tempoFantasma)
        {
            contadorFantasma += Time.deltaTime;
        }

        else
        {
            contadorFantasma = 0;
            listaFantasma[indiceFantasma].SetActive(false);

            if (indiceFantasma < listaFantasma.Count - 1)
            {
                indiceFantasma++;
            }

            else
            {
                indiceFantasma = 0;
            }

            listaFantasma[indiceFantasma].SetActive(true);

        }
    }

    public void MatarTodosOsFantasmas() 
    {
        coletouChave = true;
        for (int i = 0; i < listaFantasma.Count; i++)
        {
            Destroy(listaFantasma[i]);
        }
    }

}
