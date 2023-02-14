using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MoverCursor : MonoBehaviour
{
    public Transform t1;
    public Transform t2;
    public Transform t3;
    private int selecao = 1;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (selecao == 1) {
            transform.position = new Vector2(t1.position.x, t1.position.y);
        }
        else if (selecao == 2)
        {
            transform.position = new Vector2(t2.position.x, t2.position.y);
        }
        else if (selecao == 3)
        {
            transform.position = new Vector2(t3.position.x, t3.position.y);
        }
        if (Input.GetKey(KeyCode.Return))
        {
            switch (selecao)
            {
                case 1:
                    SceneManager.LoadScene("PreGame");
                    break;
                case 2:
                    SceneManager.LoadScene("Créditos");
                    break;
                case 3:
                    Application.Quit();
                    break;
            }
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            selecao += 1;
        }
        else if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            selecao -= 1;
        }
        if (selecao < 1)
        {
            selecao = 1;
        }
        else if (selecao > 3)
        {
            selecao = 3;
        }
    }
}
