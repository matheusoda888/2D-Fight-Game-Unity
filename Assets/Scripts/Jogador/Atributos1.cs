using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Atributos1 : MonoBehaviour

{

   
    
    public float Vida = 100;
    public GameObject barraDeVida;
    
    private BoxCollider2D bc;
    private Animator animator;

    public GameObject fogo;
    private BoxCollider2D fogobc;


    public GameObject raio;
    private BoxCollider2D raiobc;

    private Stun scriptStun;

    public GameObject inimigo;
    private Stun iniStun;

    public GameObject telaPreta;

    public bool burning = false;

    public bool raiozado = false;

    public bool morreu;
    
    void Start()
    {
        bc = GetComponent<BoxCollider2D>();
        fogobc = fogo.GetComponent<BoxCollider2D>();
        raiobc = raio.GetComponent<BoxCollider2D>();
        animator = this.GetComponent<Animator>();
        scriptStun = GetComponent<Stun>();
        iniStun = inimigo.GetComponent<Stun>();
        
    }

    
    void Update()
    {
        barraDeVida.transform.localScale = new Vector3(Vida / 100, 1, 1);
        if (burning == true)
        {
            Vida -= Time.deltaTime*8;


        }
        if (Vida <= 0)
        {
            iniStun.venceu();
            Vida = 0;
            if (!morreu)
            {
                scriptStun.morrendo = true;
                morreu = true;
            }
            telaPreta.SetActive(true);
        }
        
    }
    void FixedUpdate()
    {
        if (Physics2D.IsTouching(fogobc, bc))
        {
            burning = true;
        }
        else
        {
            burning = false;
        }
        if (Physics2D.IsTouching(raiobc, bc)&&raiozado==false)
        {
            Vida -= 20;
            
            raiozado = true;
        }
        
    }

   
}
