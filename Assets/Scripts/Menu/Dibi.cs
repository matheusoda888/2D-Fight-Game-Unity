using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dibi : MonoBehaviour
{
    private string currentState;
    const string posFade = "posFade";
    const string posEfeito = "posEfeito";
    public GameObject efeito;
    public GameObject menu;
    public GameObject som;
    private Animator animator;
    public int sla = 0;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        if (sla == 1)
        {
            DontDestroyOnLoad(som);
        }
    }
    

    // Update is called once per frame
    void Update()
    {
        
    }
    public void ativaLogo()
    {
        efeito.SetActive(true);
    }
    public void ChangeAnim(string newState)
    {
        // if (currentState == newState) return; 

        animator.Play(newState);

        currentState = newState;
    }
    public void ativaMenu()
    {
        menu.SetActive(true);
    }

    
}
