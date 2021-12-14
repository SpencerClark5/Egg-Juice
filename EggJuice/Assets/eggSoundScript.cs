using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class eggSoundScript : MonoBehaviour
{
    private AudioSource source;
    // Start is called before the first frame update
    void Start()
    {
        source = GameObject.FindGameObjectWithTag("EggDeathSound").GetComponent<AudioSource>();
    }

    private void OnDestroy()
    {
       // source.Play();
    }
}
