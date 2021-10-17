using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerProjectile : MonoBehaviour
{

    public void OnCollisionEnter2D(Collision2D col)
    {
        //if enemy collides with tower
        if (col.gameObject.tag == "Enemy")
        {
           //Debug.Log("hit!");
            //grabs the script on the tower
            Destroy(this.gameObject);
            // Destroy(col.gameObject);
            Debug.Log("HIT!");
            //TowerScript tower = col.gameObject.GetComponent<TowerScript>();
            // Debug.Log(tower.getDamage());

        }
    }

    private Rigidbody2D RB;
    // Start is called before the first frame update
    void Start()
    {
        RB = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
