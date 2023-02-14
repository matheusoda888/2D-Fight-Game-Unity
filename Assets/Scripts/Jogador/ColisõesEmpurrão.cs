using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColisõesEmpurrão : MonoBehaviour
{
    public GameObject inimigo;
    public BoxCollider2D inimigobc;
    private Ataques1 scriptAtq;
    private Movimentação1 scriptMov;
    private BoxCollider2D bc;
    private Atributos1 scriptAtri;
    private Rigidbody2D inirb;


    private PulosEPlataformas scriptPulo;
    private Stun stunScript;
    // Start is called before the first frame update
    void Start()
    {
        scriptAtq = inimigo.GetComponent<Ataques1>();
        bc = GetComponent<BoxCollider2D>();
        inimigobc = inimigo.GetComponent<BoxCollider2D>();
        inirb = inimigo.GetComponent<Rigidbody2D>();
        scriptAtri = inimigo.GetComponent<Atributos1>();
        stunScript = inimigo.GetComponent<Stun>();
    }

    // Update is called once per frame
    
    void Update()
    {
        if (Physics2D.IsTouching(bc, inimigobc))
        {
            print("hey");
            if (stunScript.stunado)
            {
                stunScript.passaValor(0);
            }
            else
            {
                stunScript.stunado = true;
                stunScript.inicio();
            }
            if (inimigo.transform.position.x >= this.transform.position.x)
            {

                inirb.AddForce(new Vector2(6, 0), ForceMode2D.Impulse);
            }
            else
            {
                inirb.AddForce(new Vector2(-6, 0), ForceMode2D.Impulse);
            }
            scriptAtri.Vida -= 3;
            scriptAtq.atackTotal = 0;
            this.gameObject.SetActive(false);


        }

    }
}
   /* void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject == inimigo)
        {
            {
                if (stunScript.stunado)
                {
                    stunScript.passaValor(0);
                }
                else
                {
                    stunScript.stunado = true;
                    stunScript.inicio();
                }
                if (inimigo.transform.position.x >= this.transform.position.x)
                {

                    inirb.AddForce(new Vector2(6, 0), ForceMode2D.Impulse);
                }
                else
                {
                    inirb.AddForce(new Vector2(-6, 0), ForceMode2D.Impulse);
                }
                scriptAtri.Vida -= 3;
                scriptAtq.atackTotal = 0;
                this.gameObject.SetActive(false);


            }
        }
    }
}*/
