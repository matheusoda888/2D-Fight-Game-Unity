using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IgnoreCollisions : MonoBehaviour
{
    
    public GameObject chao1;
    public GameObject chao2;
   
    private BoxCollider2D bc;
    
    private BoxCollider2D bc3;
    private BoxCollider2D bc4;
    
    private BoxCollider2D inibc;
    public GameObject inimigo;

    // Start is called before the first frame update
    void Start()
    {
        bc = GetComponent<BoxCollider2D>();
        
        
        
        inibc = inimigo.GetComponent<BoxCollider2D>();

    }

    // Update is called once per frame
    void Update()
    {
        
        //Physics2D.IgnoreCollision(bc, inibc);


    }
    
}
