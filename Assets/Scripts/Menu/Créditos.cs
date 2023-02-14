using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Créditos : MonoBehaviour
{
    private string currentState;
    const string posFadeCreditos = "posFadeCreditos";
    private Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Return))
        {
            SceneManager.LoadScene("Menu");
        }

    }
    public void ChangeAnim(string newState)
    {
        // if (currentState == newState) return; 

        animator.Play(newState);

        currentState = newState;
    }
}
