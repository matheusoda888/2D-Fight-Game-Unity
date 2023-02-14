using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ColisõesAtaques : MonoBehaviour
{
    public GameObject inimigo;
    public BoxCollider2D inimigobc;
    private Ataques1 scriptAtq;
    private Movimentação1 scriptMov;
    private BoxCollider2D bc;
    private Atributos1 scriptAtri;
    private Especial scriptEsp;
    public GameObject eu;
    private PulosEPlataformas scriptPulo;
    private Stun stunScript;
    public AudioSource soundEffect;
    
    // Start is called before the first frame update
    void Start()
    {
        bc = GetComponent<BoxCollider2D>();
        inimigobc = inimigo.GetComponent<BoxCollider2D>();
        scriptAtq = inimigo.GetComponent<Ataques1>();
        scriptAtri = inimigo.GetComponent<Atributos1>();
        stunScript = inimigo.GetComponent<Stun>();
        scriptEsp = eu.GetComponent<Especial>();
        
            }

    // Update is called once per frame
    void Update()
    {
        
    }
    void FixedUpdate()
    {
        if (Physics2D.IsTouching(bc, inimigobc))
        {
            
            
            scriptAtri.Vida -= 8;
            scriptEsp.barraEspecial += 20;
            this.gameObject.SetActive(false);
            scriptAtq.atackTotal = 0;
            if (stunScript.stunado)
            {
                stunScript.passaValor(0);
            }
            else
            {
                stunScript.stunado = true;
                stunScript.inicio();
            }
            soundEffect.Play();
        }
        
    }
    

}
