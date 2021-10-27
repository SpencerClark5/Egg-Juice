using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionChecker : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Square detected trigger");
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        Debug.Log("Square trigger exited");
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
