using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class EnemyScript : MonoBehaviour
{
    private class EnemyStats
    {
        Vector3 speed;
        int EnemyHealth;
        int EnemyDamage;

        public EnemyStats(Vector3 speed, int health, int dmg)
        {
            this.EnemyHealth = health;
            this.speed = speed;
            this.EnemyDamage = dmg;
        }
        public int getHealth()
        {
            return EnemyHealth;
        }
        public int getDamage()
        {
            return EnemyDamage;
        }
        public void Damage(int damageAmount)
        {
            EnemyHealth -= damageAmount;
            if (EnemyHealth < 0) EnemyHealth = 0;
        }


    }

    public void OnCollisionEnter2D(Collision2D col){
        //if enemy collides with tower
        if (col.gameObject.name == "Tower")
        {

           Debug.Log("ouch");
            //grabs the script on the tower
            Destroy(this.gameObject);

             //TowerScript tower = col.gameObject.GetComponent<TowerScript>();
            // Debug.Log(tower.getDamage());

        }
    }
    // Start is called before the first frame update
    private Rigidbody2D RB;
    void Start()
    {

        RB = GetComponent<Rigidbody2D>();
        RB.velocity = new Vector2(1, 0);
        EnemyStats Enemy = new EnemyStats(RB.velocity, 1, 1);
        
       
        //get the object that this script is on and determine health from that
    }


    // Update is called once per frame
    void Update()
    {

        //RB.velocity = new Vector2(1, 0);




        // Vector3 movement = new Vector3(1, 0,0);
        // transform.position = transform.position + movement * Time.deltaTime;


        //if an enemy comes in contact with something that does damage

        //if a projectile comes in contact with the enemy

        //if hitscan damages the enemy
    }
}
