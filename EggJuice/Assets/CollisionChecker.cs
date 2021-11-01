using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionChecker : MonoBehaviour
{
    // pathNode Square is at
    private PathNode pathNode;
    // thises sprite renderer
    [SerializeField] private SpriteRenderer spriteRenderer;
    private Testing testing;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (collision.gameObject.tag == "collisionDetecter")
        {
            //Debug.Log("Square detected trigger");
            testing.addTileToArray(pathNode);
            spriteRenderer.enabled = true;
            //testing.recalculate(pathNode.getCenterWorldPostition());
        }
        if (collision.gameObject.tag == "topLeftCollisionDetecter")
        {
            // do top left things
            testing.recalculate(pathNode.getCenterWorldPostition());
        }
    }

    /*private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "collisionDetecter")
        {
            Debug.Log("Square detected trigger");
            spriteRenderer.enabled = true;
        }
        if (collision.gameObject.tag == "topLeftCollisionDetecter")
        {
            // do top left things

        }
    }*/

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "collisionDetecter")
        {
            //Debug.Log("Square trigger exited");
            spriteRenderer.enabled = false;
            testing.removeTileFromArray(pathNode);
        }
        if (collision.gameObject.tag == "topLeftCollisionDetecter")
        {
            // do top left things
            //testing.removeTileFromArray();
        }
    }
    
    public void setPathNode(PathNode pathNode)
    {
        this.pathNode = pathNode;
    }

    public void setTesting(Testing testing)
    {
        this.testing = testing;
    }
}
