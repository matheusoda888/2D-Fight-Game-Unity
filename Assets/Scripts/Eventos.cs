using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Eventos : MonoBehaviour
   
{
    public GameObject raio;
    public GameObject fogo;
    public AudioSource fogoPreSom;
    public AudioSource raioPreSom;

    public int randEvent = 0;

    //timer para acontecer o evento
    public float timerEvento = 0;


    //quanto tempo pra cada evento
    private int delayEvento = 5;

    //"delay" de execução do evento
    [SerializeField]
    private float timerToExec = 0;
    private bool timertoexecBool = false;

    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timerEvento += Time.deltaTime;
        if (timerEvento >= delayEvento&&randEvent==0)
        {
            randEvent = Random.Range(1, 11);

            if (randEvent > 5)
            {
                //tocapreraio
                raioPreSom.Play();
                timertoexecBool = true;
                
                
            }
            else if (randEvent <= 5)
            {
                fogoPreSom.Play();
                timertoexecBool = true;
                
                
            }
        }
        if (timertoexecBool)
        {
            timerToExec += Time.deltaTime;
            if (timerToExec >= 2&&randEvent>5)
            {
                eventoRaio();
                //tocaraio
                timerEvento = 0;
                timerToExec = 0;
                randEvent = 0;
                timertoexecBool = false;
                raioPreSom.Stop();

            }
            else if (timerToExec >= 2&&randEvent<=5)
            {
                eventoFogo();
                //tocafogo
                timerEvento = 0;
                timerToExec = 0;
                randEvent = 0;
                timertoexecBool = false;
                fogoPreSom.Stop();
            }
        }
    }
    void eventoRaio()
    {
        raio.SetActive(true);

    }
    void eventoFogo()
    {
        fogo.SetActive(true);
    }

}
