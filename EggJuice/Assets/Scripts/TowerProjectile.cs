using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerProjectile : MonoBehaviour
{
    public int ProjectileDamage = 0;
    public void setDamage(int dmg)
    {
        ProjectileDamage = dmg;
    }
    public int getDamage()
    {
        return ProjectileDamage;
    }

    public void OnCollisionEnter2D(Collision2D col)
    {
        //if enemy collides with tower
        if (col.gameObject.tag == "Enemy")
        {
         EnemyScript enemy = col.gameObject.GetComponent<EnemyScript>();
            //how would i access a class object inside of a game object
            enemy.Enemy.Damage(ProjectileDamage);

          // Debug.Log("hit!");
            //grabs the script on the tower
            Destroy(this.gameObject);
            // Debug.Log(tower.getDamage());


            // when the projectile spawns, give it damage equal to the tower damage


        }
    }

    private Rigidbody2D RB;
  //  private Collider COL;
    // Start is called before the first frame update
    void Start()
    {
        RB = GetComponent<Rigidbody2D>();
       // COL = GetComponent<Collider>();
        //Physics.IgnoreCollision(COL,COL);
       // TowerScript tower = col.gameObject.GetComponent<TowerScript>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
