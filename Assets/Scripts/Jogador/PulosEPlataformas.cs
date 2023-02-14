using System.Collections;
using System.Collections.Generic;
using UnityEngine;
   


public class PulosEPlataformas : MonoBehaviour
{   //eu
    Animator animator;
    private Rigidbody2D rigido;
    private BoxCollider2D boxcollider;

    private bool noar;
    //triggers

    
    

    //collider triggers
    
    //teclas
    public KeyCode down;
    public KeyCode jump;

    //chões

    public GameObject chao1;
    public GameObject chao2;
    




    //colliderdoschões
    private BoxCollider2D xao1;
    private BoxCollider2D xao2;
    private Movimentação1 scriptMove;
    //bool ignore collision (cross script)
    public bool ignore = false;

    public bool Stunado = false;
    //timer do ignore input
    public float timerIg = 0;

    public bool ds;
    const string playerIdle = "PlayerIdle";
    const string playerJump = "PlayerJump";
    private string currentState;

    [SerializeField] private LayerMask layermask;
    // Use this for initialization
    public float velocidade = 2f;
    void Start()
    {
        
        rigido = this.GetComponent<Rigidbody2D>();
        boxcollider = this.GetComponent<BoxCollider2D>();
        animator = this.GetComponent<Animator>();
        xao1 = chao1.GetComponent<BoxCollider2D>();
        xao2 = chao2.GetComponent<BoxCollider2D>();

        scriptMove = GetComponent<Movimentação1>();



    }

    // Update is called once per frame




    void Update()
    {
        ds = tanochao();
        
        //bool de ignore input
        if(ignore == true)
        {
            

            timerIg += Time.deltaTime;
            if (timerIg >= 0.5)
            {   timerIg = 0;
                ignore = false;
                Physics2D.IgnoreCollision(boxcollider, xao1, false);
                Physics2D.IgnoreCollision(boxcollider, xao2, false);
                



            }
        }
        if (noar == true)
        {
            if (tanochao())
            {
                if (scriptMove.xVel == 2)
                {
                    ChangeAnim("PlayerDash");
                }
                else
                {
                    ChangeAnim(playerIdle);
                }
                noar = false;
            }
        }
    }



    void FixedUpdate()
    {
        

        if (Input.GetKey(jump) && Stunado == false )
        {
            if (tanochao())
            {
                ChangeAnim(playerJump);
                float velodicadejump = 13f;
                rigido.AddForce(new Vector2(0, velodicadejump), ForceMode2D.Impulse);
                GetComponent<Ataques1>().atackTotal = 0;
                noar = true;
            }
        }

        //pular, euqnato ta no chao, e sem ignorar input

        //descer enquanto ta no chao
        if (Input.GetKey(down)&&tanochao()&&!Stunado)
        {
            ChangeAnim(playerJump);
            GetComponent<Ataques1>().atackTotal = 0;
            Physics2D.IgnoreCollision(boxcollider, xao1, true);
            Physics2D.IgnoreCollision(boxcollider, xao2, true);
            ignore = true;
            noar = true;
            



        }
        //jogador colide com teto do segundo andar

        
        //jogador esta no segundo andar
        //if(this.transform.position.y>-1.7 && this.transform.position.y <=-1.5)
        //{
            
        //}
       





        //  controle de layers extremamente importante

    }
    public bool tanochao()
    {
        RaycastHit2D raycast = Physics2D.BoxCast(boxcollider.bounds.center, boxcollider.bounds.size, 0f, Vector2.down, .1f, layermask);
        if (rigido.velocity.y == 0)
        {


            return raycast.collider != null;

        }
        else
        {
            return false;
        }
    }
    public void stunJump()
    {
        Stunado = true;
    }
    public void DesstunJump()
    {
        Stunado =false;
    }
    void ChangeAnim(string newState)
    {
        //if (currentState == newState) return;

        animator.Play(newState);

        currentState = newState;
    }
    public void plyaerjumpl()
    {
        ChangeAnim(playerJump);
    }

    


}
