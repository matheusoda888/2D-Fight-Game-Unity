using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class Stun : MonoBehaviour
{
    public float timerStun = 0;
    private Ataques1 scriptAtq;
    private Movimentação1 scriptMov;
    public PulosEPlataformas scriptPulo;
    const string playerStun = "PlayerStun";
    const string playerMorto = "PlayerMorto";
    const string playerMortao = "PlayerMortao";
    public bool morto = false;
    public bool morrendo = false;
    Animator animator;
    private Atributos1 scriptAtri;
    




    
    const string playerIdle = "PlayerIdle";

    public bool stunado = false;
    private bool tiktok=false;
    private string currentState;
    // Start is called before the first frame update
    void Start()
    {
         scriptAtq = GetComponent<Ataques1>();
        scriptMov = GetComponent<Movimentação1>();
        scriptPulo = GetComponent<PulosEPlataformas>();
        animator = this.GetComponent<Animator>();
        scriptAtri = GetComponent<Atributos1>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if (stunado)
        {
            scriptAtq.stunado = true;
            scriptMov.stunado = true;
            scriptPulo.Stunado = true;
            ChangeAnim(playerStun);
        }
        
        if (tiktok)
        {
            timerStun += Time.deltaTime;
            if (timerStun >= 0.5)

            {   stunado = false;
                ChangeAnim(playerIdle);
                scriptAtq.stunado = false;
                scriptMov.stunado = false;
                scriptPulo.Stunado = false;
                
                scriptMov.xVel = 0;
                tiktok = false;
                timerStun = 0;
            }
        }

        if (morto)
        {
            morrendo = false;
            ChangeAnim(playerMortao);
        }
        if (morrendo)
        {
            scriptAtq.stunado = true;
            scriptMov.stunado = true;
            scriptPulo.Stunado = true;
            
            

            ChangeAnim(playerMorto);
        }
       
    }
    public void inicio()
    {
        
        tiktok = true;
    }
    public void stunando()
    {
        
        scriptAtq.stunado = true;
        scriptMov.stunado = true;

        scriptPulo.Stunado = true;
        tiktok = true;
    }
    void ChangeAnim(string newState)
    {
        //if (currentState == newState) return;

        animator.Play(newState);

        currentState = newState;
    }
    public void passaValor(float valor)
    {
        timerStun = valor;
    }
    public void morte()
    {

        morto = true;
    }
    public void venceu()
    {
        scriptAtq.stunado = true;
        scriptMov.stunado = true;
        scriptPulo.Stunado = true;
    }


}
