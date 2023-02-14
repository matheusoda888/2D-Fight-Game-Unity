using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Ataques1 : MonoBehaviour
{

    
    public KeyCode tapAtack;
    public KeyCode tapPush;

    
    public int atackTotal = 0;
    public float atackDelay = 0;
    //CONTADORES DE MOVIMENTO E ATAQUE


    //VEL DASH
    private SpriteRenderer imagem;
    private Rigidbody2D rigid;
    
    private BoxCollider2D bc;

    private string currentState;

    Animator animator;

    

   
    const string playerAtack = "PlayerAtack";
    const string playerIdle = "PlayerIdle";
    const string playerDash = "PlayerDash";
    const string playerAtack2 = "PlayerAtack2";
    const string playerAtack3 = "PlayerAtack3";
    const string playerJumpAtack = "PlayerJumpAtack";
    const string playerJump = "PlayerJump";
    const string playerDashAtack = "PlayerDashAtack";
    const string playerPush = "PlayerPush";
    //ESTADOS DE ANIMAÇÃO, UTILIZADOS NA FUNÇÃO CHANGEANIM()



    public GameObject goAtq1;
    public GameObject goAtq2;
    public GameObject goAtq3;
    public GameObject goAtqDash;
    public GameObject goAtqJump;
    public GameObject goAtqPush;
   
    public int dashing;
    public bool stunado = false;
    
    public bool cdatqbool = false;

    private bool stunMov;
    private Stun stunScript;

    private bool ds;
    public bool ja;



    [SerializeField] private LayerMask layermask;
    // Start is called before the first frame update

    void Start()
    {

        rigid = this.GetComponent<Rigidbody2D>();
        imagem = this.GetComponent<SpriteRenderer>();
        bc = this.GetComponent<BoxCollider2D>();
        animator = this.GetComponent<Animator>();
        stunMov = GetComponent<Movimentação1>().stunado;
        stunScript = GetComponent<Stun>();
        
    }
    // Update is called once per frame
    void Update()
    {
        dashing = GetComponent<Movimentação1>().xVel;
        //MOVIMENTAÇÃO
        






        //MOVIEMNTAÇÃO

        //AO APERTAR
        if (Input.GetKey(tapAtack) && stunado == false)
        {

            if (tanochao())
            {
                if (Input.GetKeyDown(tapAtack))
                {
                    atackTotal += 1;
                }
            }
            else if(!tanochao()&&ja==false)
            {
                ChangeAnim(playerJumpAtack);
                ja = true;

            }
        }
        if (Input.GetKey(tapPush)&&tanochao() && atackTotal == 0)
        {
            ChangeAnim(playerPush);
            stunScript.stunando();
        }
        else if (Input.GetKey(tapPush) && !tanochao()&&ja==false&&atackTotal==0)
        {
            
            ChangeAnim(playerPush);
            stunScript.stunando();
            ja = true;
        }

         
        



        //ataque 1 "dentro do tempo"
        if ((atackTotal == 1))
        {
            if (tanochao() && dashing == 2)
            {
                ChangeAnim(playerDashAtack);
                atackDelay += Time.deltaTime;
                stunScript.stunando();

            }
            else if (tanochao()&&dashing!=2)
            {
                ChangeAnim(playerAtack);
                atackDelay += Time.deltaTime;
            }
        }
        //ataque 1 "dentro do tempo"

        //ataque 1 "fora do tempo"(impossivel?)
        if ((atackTotal == 1) && (atackDelay >= 0.6))
        {
            atackDelay = 0;
            ChangeAnim(playerIdle);
            atackTotal = 0;
        }
        //ataque 1 "fora do tempo"(impossivel?)



        //ataque 2 DENTRO do tempo
        if ((atackTotal == 2) && (atackDelay < 1)&&(atackDelay>0.25))
        {
            //count do combo anim event

            if (tanochao())
            {

                ChangeAnim(playerAtack2);
                atackDelay += Time.deltaTime;
                Debug.Log("combo2");

            }

        }
        //ataque 2 DENTRO do tempo





        //segundo ataque fora do tempo    
        if ((atackTotal == 2) && (atackDelay >= 1)|| (atackTotal == 2) && (atackDelay <0.15))
        {

            atackDelay = 0;
            atackTotal = 0;
            


        }
        //segundo ataque fora do tempo








        //terceiro ataque DENTRO do tempo
        if ((atackTotal == 3) && (atackDelay < 1.4)&&(atackDelay>0.45))
        {
            if (tanochao())
            {
                Debug.Log("combo3");
                atackDelay += Time.deltaTime;

                ChangeAnim(playerAtack3);

                atackTotal = 0;
                atackDelay = 0;
            }


        }
        //terceiro ataque DENTRO do tempo



        //terceiro ataque fora do tempo
        if ((atackTotal >= 3) && (atackDelay > 1.6)|| (atackTotal >= 3) && (atackDelay < 0.35))
        {
            atackTotal = 0;
            atackDelay = 0;
            

        }

        //terceiro ataque fora do tempo



        //ativando delay pos combo para parar animação
       
        //ativando delay pos combo para parar animação




        //delay pos combo
        if (atackTotal > 3)
        {
            atackTotal = 0;
            atackDelay = 0;
        }

        //delay pos combo
        if (ja == true)
        {
            if (tanochao())
            {
                ja = false;
            }
        }

        



    }
    void FixedUpdate()
    {

        //dash

        

       

    }

    //tanochao?
    public bool tanochao()
    {
        RaycastHit2D raycast = Physics2D.BoxCast(bc.bounds.center, bc.bounds.size, 0f, Vector2.down, .1f, layermask);
        if (rigid.velocity.y == 0)
        {


            return raycast.collider != null;

        }
        else
        {
            return false;
        }
    }
    //tanochao?


    //função mudar animção atravez de strings
    void ChangeAnim(string newState)
    {
       // if (currentState == newState) return;

        animator.Play(newState);

        currentState = newState;
    }

    //função mudar animção atravez de strings
    
    
    public void atq1()
    {
        goAtq1.SetActive(true);
    }
    
    public void atq2()
    {
        goAtq2.SetActive(true);
    }
    
    public void atq3()
    {
        goAtq3.SetActive(true);
    }
    
    public void atqDash()
    {
        goAtqDash.SetActive(true);
    }
    public void atqPush()
    {
        goAtqPush.SetActive(true);
    }
    public void atqJump()
    {
        goAtqJump.SetActive(true);
    }
    public void StunAtq()
    {
        stunado = true;
    }
    public void DesStunAtq()
    {
        stunado =false;
    }
    public void playerIdlee()
    {
        ChangeAnim(playerIdle);
    }
    
    //contagem dos atqs no combo (animation events)





    //contagem dos atqs no combo (animation events)
}
