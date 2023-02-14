using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Especial : MonoBehaviour
{
    public GameObject goBarraEspecial;
    public float barraEspecial;
    private Stun stunScript;
    private Animator animator;
    public GameObject goAtqXpcl;
    private string currentState;
    const string playerEspecial = "PlayerEspecial";
    const string playerIdle = "PlayerIdle";
    public KeyCode tapXpcl;
    private Ataques1 scriptAtq;
    // Start is called before the first frame update
    void Start()
    {
        
        animator = GetComponent<Animator>();
        stunScript = GetComponent<Stun>();
        scriptAtq = GetComponent<Ataques1>();
    }

    // Update is called once per frame
    void Update()
    {
        goBarraEspecial.transform.localScale = new Vector3(barraEspecial / 100, 1, 1);
        if (Input.GetKey(tapXpcl))
        {
            if (barraEspecial == 100)
            {
                ChangeAnim(playerIdle);
                scriptAtq.atackTotal = 0;
                ChangeAnim(playerEspecial);
                stunScript.stunando();
                barraEspecial = 0;
                //stunScript.passaValor(-11) 0 === +0.5;
            }
        }
        if (barraEspecial > 100)
        {
            barraEspecial = 100;
        }
    }
    void ChangeAnim(string newState)
    {
        // if (currentState == newState) return;

        animator.Play(newState);

        currentState = newState;
    }
    public void atqXpcl()
    {
        goAtqXpcl.SetActive(true);
    }
}
