using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DirectionScript : MonoBehaviour
{
    [SerializeField] private GameObject assetObject;
    [SerializeField] private Rigidbody2D rb;
    private double previousPos;
    // Start is called before the first frame update
    void Start()
    {
        previousPos = this.gameObject.transform.position.x;
    }
 
    // Update is called once per frame
    void Update()
    {
        if (this.gameObject.tag != "GameManager")
        {
            
            if (previousPos < gameObject.transform.position.x && gameObject.transform.position.x - previousPos > 0.05)
            {
                // turn left
                previousPos = gameObject.transform.position.x;
                
                assetObject.GetComponent<SpriteRenderer>().flipX = false;
            }
            else if (previousPos > gameObject.transform.position.x && previousPos - gameObject.transform.position.x > 0.05)
            {
                // turn right
                previousPos = gameObject.transform.position.x;
                
                assetObject.GetComponent<SpriteRenderer>().flipX = true;
            }
        }
    }
}
