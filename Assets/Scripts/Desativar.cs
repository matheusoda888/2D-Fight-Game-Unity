using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Desativar : MonoBehaviour
{
    public float timerDesativar = 0;
    private Atributos1 j1;
    private Atributos1 j2;
    // Start is called before the first frame update
    void Start()
    {
        j1 = GameObject.Find("J1").GetComponent<Atributos1>();
        j2 = GameObject.Find("J2").GetComponent<Atributos1>();
    }

    // Update is called once per frame
    void Update()
    {
        timerDesativar += Time.deltaTime;
        if (timerDesativar >= 3)
        {
            this.gameObject.SetActive(false);
            j1.raiozado = false;
            j2.raiozado = false;
            timerDesativar = 0;
        }
    }
}
