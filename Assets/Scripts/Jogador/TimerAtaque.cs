using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimerAtaque : MonoBehaviour
{
    public float tempoMax;
    public float timer;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= tempoMax)
        {
            timer = 0;
            this.gameObject.SetActive(false);
        }
    }
}
