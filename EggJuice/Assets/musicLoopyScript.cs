using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class musicLoopyScript : MonoBehaviour
{
    [SerializeField] AudioSource source;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(musicLoop());
    }
    private IEnumerator musicLoop()
    {
        source.Play();
        yield return new WaitForSeconds(8.1f);
        StartCoroutine(musicLoop());
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
