using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CdDashATq : MonoBehaviour
{
    public float timerStun = 0;
    private Ataques1 scriptAtq;
    private Movimentação1 scriptMov;
    public UnityEvent UnStunPulo;
    public UnityEvent stunPulo;
    private bool tiktok = false;
    const string playerDashAtack = "PlayerDashAtack";
    Animator animator;
    private string currentState;
    private Stun UnStun;
    // Start is called before the first frame update
    void Start()
    {
        scriptAtq = GetComponent<Ataques1>();
        scriptMov = GetComponent<Movimentação1>();
        UnStun = GetComponent<Stun>();
        animator = this.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (scriptAtq.cdatqbool)
        {
            ChangeAnim(playerDashAtack);
            scriptMov.StunMov();
            scriptAtq.StunAtq();
            stunPulo.Invoke();
            inicio();
        }
        if (tiktok)
        {
            timerStun += Time.deltaTime;
            if (timerStun >= 0.5)
            {
                scriptAtq.cdatqbool = false;
                scriptAtq.stunado = false;
                scriptMov.stunado = false;

                UnStunPulo.Invoke();
                tiktok = false;
                timerStun = 0;
            }
        }

    }
    public void inicio()
    {
        tiktok = true;
    }
    void ChangeAnim(string newState)
    {
        if (currentState == newState) return;

        animator.Play(newState);

        currentState = newState;
    }
}
