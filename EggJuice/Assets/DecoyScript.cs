using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DecoyScript : MonoBehaviour
{
    // Start is called before the first frame update
    private Testing testing;
    private bool gettingDestroyed = false;
    void Start()
    {
        testing = GameObject.FindGameObjectWithTag("Testing").GetComponent<Testing>();
        //testing.addChicken(this.gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Enemy")
        {
           // if (!testing.decoys.Contains(collision.gameObject))
            //{
                //testing.addDecoy(this.gameObject);
                collision.GetComponent<AstarAI>().addDecoys(this.gameObject);
            //}
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Enemy")
        {
            AstarAI astarAI = collision.GetComponent<AstarAI>();
            if (!astarAI.getDestroying())
            {
                astarAI.removeDecoy(this.gameObject);
                //testing.destroyDecoy();
                //testing.decoys.Remove(collision.gameObject);
            }
            else
            {
                astarAI.setDestroying(false);
               // Destroy(collision.gameObject);
            }
        }
    }

    public void setGettingDestroyed()
    {
        gettingDestroyed = true;
    }
}
