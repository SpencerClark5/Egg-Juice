using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class soundManager : MonoBehaviour
{
    private AudioSource soundboy;
    // Start is called before the first frame update
    void Start()
    {
        soundboy = GameObject.FindGameObjectWithTag("DeathSound").GetComponent<AudioSource>();
    }
    
    private void OnDestory()
    {
        soundboy.Play();
        Debug.Log("ondestroyu:" + soundboy);
    }
}
