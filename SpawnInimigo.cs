using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnInimigo : MonoBehaviour
{

    public List<GameObject> monstros;

    float contadorTempo;

    public float tempoSpawn;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        QuedaRandomizada();
    }

    void QuedaRandomizada()
    {
        contadorTempo += Time.deltaTime;
        if (contadorTempo > tempoSpawn)
        {
            contadorTempo = 0;
            int sorteiaIndice = Random.Range(0, monstros.Count);
            //RandomizarPosição
            float posX = Random.Range(-10, 10);
            Vector3 novaPos = new Vector3(posX, 4, 0);

            GameObject monstro = Instantiate(monstros[sorteiaIndice], novaPos, Quaternion.identity);

        }
    }
}

