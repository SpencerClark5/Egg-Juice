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
        // Debug.Log("collidedwithsomething");
        if (col.gameObject.tag == "Enemy")
        {
            EnemyScript enemy = col.gameObject.GetComponent<EnemyScript>();
            //grabs the enemy object inside of the enemyScript
            enemy.getStats().Damage(ProjectileDamage);

            //destroys the projectile
            Destroy(this.gameObject);

            //if the enemy dies
            if (enemy.getStats().getHealth() == 0)
            {
                //can call a death animation per enemy
                if (col.gameObject.name == "Raccoon")
                {
                    // spawn egg
                    enemy.setKilledByTower();
                }
                Destroy(col.gameObject);
            }


        }
        if (col.gameObject.tag == "Boundary")
        {
            Destroy(this.gameObject);
        }
    }

    private Rigidbody2D RB;
    //  private Collider COL;
    // Start is called before the first frame update
    void Start()
    {

        RB = GetComponent<Rigidbody2D>();
        //ignores the collision on the projectile layers (6)
        Physics2D.IgnoreLayerCollision(6, 6);
        // COL = GetComponent<Collider>();
        //Physics.IgnoreCollision(COL,COL);
        // TowerScript tower = col.gameObject.GetComponent<TowerScript>();
    }

    // Update is called once per frame
    void Update()
    {

    }
}
