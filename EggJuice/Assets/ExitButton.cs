using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ExitButton : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void OnMouseDown()
    {
        Debug.Log("BUTON");
        SceneManager.LoadScene("Main Game Screen");

    }
    

    // Update is called once per frame
    void Update()
    {
        
    }
}
