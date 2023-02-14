using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Movimentação1 : MonoBehaviour
{

    public KeyCode tapLeft;
    public KeyCode tapRight;

    private Ataques1 scriptAtq;
    //CONTADORES DE MOVIMENTO E ATAQUE
    public int leftTotal = 0;
    public float leftDelay = 0;
    public int rightTotal = 0;
    public float rightDelay = 0;
   
    //CONTADORES DE MOVIMENTO E ATAQUE


    //VEL DASH
    public int xVel = 0;
    //VEL DASH

    private Rigidbody2D rigid;
    private SpriteRenderer imagem;
    private BoxCollider2D bc;
    

    private string currentState;

    Animator animator;

    

    //ESTADOS DE ANIMAÇÃO, UTILIZADOS NA FUNÇÃO CHANGEANIM()
    const string playerIdle = "PlayerIdle";
    
    const string playerJump = "PlayerJump";
    const string playerDash = "PlayerDash";
    const string playerWalk = "PlayerWalk";
    const string playerRun = "PlayerRun";
    const string playerDashAtack = "PlayerDashAtack";


    //ESTADOS DE ANIMAÇÃO, UTILIZADOS NA FUNÇÃO CHANGEANIM()



    public bool espelhado;

    public bool naoMoverAtq = false;

    public bool stunado = false;

   

    public float timerDown = 0;

    

   public KeyCode downa;
    [SerializeField] private LayerMask layermask;
    // Start is called before the first frame update

    void Start()
    {
        
        rigid = this.GetComponent<Rigidbody2D>();
        imagem = this.GetComponent<SpriteRenderer>();
        bc = this.GetComponent<BoxCollider2D>();
        animator = this.GetComponent<Animator>();
        scriptAtq = this.gameObject.GetComponent<Ataques1>();
    }
    // Update is called once per frame
    void Update()
    {
        
        if (Input.GetKey(tapRight) && scriptAtq.atackTotal == 0  && stunado == false)
        {

            transform.localScale = new Vector2(1, 1);
            espelhado = false;
            if (tanochao())
            {
                rigid.velocity = new Vector2(2 + xVel, 0);
                if (xVel != 2) { 
                ChangeAnim(playerWalk);
                
            }

            }
            else
            {
                rigid.velocity = new Vector2(+2, rigid.velocity.y);
            }
        }
        if (Input.GetKeyDown(tapRight) && scriptAtq.atackTotal == 0  && stunado == false)
        {
            rightTotal += 1;
            Debug.Log(rightTotal);
        }
        if (Input.GetKeyUp(tapRight) && scriptAtq.atackTotal==0 &&  stunado == false)
        { xVel = 0;
            if (tanochao())
            {
               
                rigid.velocity = new Vector2(0, 0);
                ChangeAnim(playerIdle);
            }
        }
        if ((rightTotal == 1) && (rightDelay < 0.5))
        {
            rightDelay += Time.deltaTime;
        }
        if ((rightTotal == 1) && (rightDelay >= 0.5))
        {
            rightDelay = 0;
            rightTotal = 0;
        }

       
        if (Input.GetKey(tapLeft) && scriptAtq.atackTotal == 0 &&  stunado == false)
        {
            transform.localScale = new Vector2(-1, 1);
            espelhado = true;
            if (tanochao())
            {
                rigid.velocity = new Vector2(-2 - xVel, 0);
                if (xVel != 2)
                {
                    ChangeAnim(playerWalk);
                }
            }
            else
            {
                rigid.velocity = new Vector2(-2, rigid.velocity.y);
            }
        }
        if (Input.GetKeyDown(tapLeft) && scriptAtq.atackTotal == 0 &&  stunado == false)
        {
            leftTotal += 1;
            Debug.Log(leftTotal);
        }
        if (Input.GetKeyUp(tapLeft) && scriptAtq.atackTotal == 0 &&stunado==false)
        {    xVel = 0;
            if (tanochao())
            {
               
                rigid.velocity = new Vector2(0, 0);
                ChangeAnim(playerIdle);
            }
        }
        if ((leftTotal == 1) && (leftDelay < 0.5))
        {
            leftDelay += Time.deltaTime;
        }
        if ((leftTotal == 1) && (leftDelay >= 0.5))
        {
            leftDelay = 0;
            leftTotal = 0;
        }

        //MOVIEMNTAÇÃO

        //AO APERTAR


        //delay pos combo





        /*if (Input.GetKey(downa))
        {
           down = true;
        }
        if (down == true)
        {
            timerDown += Time.deltaTime;
            if (timerDown >= 0.5f)
            {
                down = false;
                timerDown = 0;

            }
        }*/
       



    }
    void FixedUpdate()
    {

        if (scriptAtq.atackTotal==0)
        {

            if ((leftTotal == 2) && (leftDelay < 0.5))
            {

                
                
                ChangeAnim(playerDash);
                rigid.AddForce(new Vector2(-105, 0), ForceMode2D.Impulse);
                xVel = 2;
                leftTotal = 0;
                // ChangeAnim(playerRun);
                //se nao se sobresair em relação ao walk ou bugar: criar variavel "notDashing";

            }
            if ((rightTotal == 2) && (rightDelay < 0.5))
            {
                
                
                ChangeAnim(playerDash);
                rigid.AddForce(new Vector2(105, 0), ForceMode2D.Impulse);
                xVel = 2;
                rightTotal = 0;
                // ChangeAnim(playerRun);
                //se nao se sobresair em relação ao walk ou bugar: criar variavel "notDashing";
            }
        }

        //dash

        //dash no final do combo
        /* if ((atackTotal == 3) && (atackDelay < 1.6))
         {
             if (atq2 == true)
             {



                 dash();
                 atackDelay = 0;
                 atackTotal = 0;
                 atq1 = false;
                 atq2 = false;

             }
         }*/
        //dash no final do combo

    }
    public void dash()
    {
        
            //decidindo qual lado sera o dash do combo
            if (espelhado == true)
            {
                rigid.AddForce(new Vector2(-3, 0), ForceMode2D.Impulse);

            }

            else
            {
                rigid.AddForce(new Vector2(3, 0), ForceMode2D.Impulse);

            }
        
        //decidindo qual lado sera o dash do combo
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

    public void StunMov()
    {
        stunado = true;

    }
    public void DesStunMov()
    {
        stunado = false;

    }

    //contagem dos atqs no combo (animation events)




    //contagem dos atqs no combo (animation events)
}

