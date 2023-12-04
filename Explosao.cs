using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosao : MonoBehaviour
{
    public Animator animator;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D colisao)
    {
        if (colisao.gameObject.tag == "inimigo")
        {
       
            
        }

        if (colisao.gameObject.tag == "Pisavel")
        {
            
        }
    }

    public void tempoExplosao()
    {

    }
}
