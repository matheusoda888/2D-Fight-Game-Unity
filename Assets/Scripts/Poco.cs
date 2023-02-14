using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Poco : MonoBehaviour
{
    public GameObject abismo;
    public GameObject spawn;
    private BoxCollider2D bc;
    private BoxCollider2D abismobc;
    private Atributos1 scriptAtri;
    // Start is called before the first frame update
    void Start()
    {
        bc = GetComponent<BoxCollider2D>();
        abismobc = abismo.GetComponent<BoxCollider2D>();
        scriptAtri = GetComponent<Atributos1>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void FixedUpdate()
    {
        if(Physics2D.IsTouching(bc, abismobc))
        {
            scriptAtri.Vida = scriptAtri.Vida - 10;
            transform.position = new Vector3(spawn.transform.position.x, spawn.transform.position.y, transform.position.z);
        }
    }
}
