using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FantasminhaCamarada : MonoBehaviour
{
    GerenciadorFantasma gf;
    public GameObject CHAVE;

    // Start is called before the first frame update
    void Start()
    {
        gf = FindObjectOfType<GerenciadorFantasma>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void MORRER()
    {
        gf.MatarTodosOsFantasmas();
        Destroy(gameObject);
        Instantiate(CHAVE,transform.position, Quaternion.identity);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Bala")
        {
            MORRER();
        }
        if (collision.tag == "BalaBazuca")
        {
            MORRER();
        }
        if (collision.tag == "Atk")
        {
            MORRER();
        }
    }
}
