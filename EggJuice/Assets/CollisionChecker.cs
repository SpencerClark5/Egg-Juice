using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionChecker : MonoBehaviour
{
    // pathNode Square is at
    private PathNode pathNode;
    // thises sprite renderer
    [SerializeField] private SpriteRenderer spriteRenderer;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Square detected trigger");
        if (collision.gameObject.tag == "collisionDetecter")
        {
            spriteRenderer.enabled = true;
        }
        if (collision.gameObject.tag == "topLeftCollisionDetecter")
        {
            // do top left things

        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        Debug.Log("Square trigger exited");
        spriteRenderer.enabled = false;
    }
    
    public void setPathNode(PathNode pathNode)
    {
        this.pathNode = pathNode;
    } 
}
