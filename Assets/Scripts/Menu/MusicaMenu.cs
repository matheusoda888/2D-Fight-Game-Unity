using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicaMenu : MonoBehaviour
{
    public static bool tocando = false;
    private AudioSource som;
    // Start is called before the first frame update
    void Start()
    {
        som = GetComponent<AudioSource>();
        if (tocando == false)
        {
            som.Play();
            tocando = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
