using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class EnemyScript : MonoBehaviour
{
    private Testing testing;
    [SerializeField] int HP;
    [SerializeField] int DMG;
    [SerializeField] AstarAI astarAI;
    private bool canAttack = true;
    [SerializeField] private float atkSpeed;
    // true if moving to the right, false if moving to the left

    public class EnemyStats
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
            if (EnemyHealth <= 0)
            {
                EnemyHealth = 0;
            }
        }
    }

    //damage script
    public void OnCollisionEnter2D(Collision2D col)
    {
        if (canAttack)
        {
            if (col.gameObject.tag == "Chicken")
            {

                if (col.gameObject.GetComponent<ImmunityScript>().takeDamage(DMG))
                {
                    Debug.Log("chickenOuch");
                    testing.destroyChicken();
                    testing.chickens.Remove(col.gameObject);
                    testing.eggsAndChickens.Remove(col.gameObject);
                    Destroy(col.gameObject);
                }

            }
            if (col.gameObject.tag == "Decoy")
            {
                if (col.gameObject.GetComponent<ImmunityScript>().takeDamage(DMG))
                {
                    Debug.Log("DecoyOuch");
                    col.gameObject.GetComponent<DecoyScript>().setGettingDestroyed();
                    astarAI.removeDecoy(col.gameObject);
                    astarAI.setDestroying(true);
                    //testing.destroyDecoy();
                    //testing.decoys.Remove(col.gameObject);
                    Destroy(col.gameObject);
                }

            }
            if (col.gameObject.tag == "Egg")
            {
                if (col.gameObject.GetComponent<ImmunityScript>().takeDamage(DMG))
                {
                    col.gameObject.GetComponent<clickyegg>().setKilledByEnemy();
                    testing.destroyEgg();
                    testing.eggs.Remove(col.gameObject);
                    testing.eggsAndChickens.Remove(col.gameObject);
                    Destroy(col.gameObject);
                }
            }
        }
        StartCoroutine(attack());
        /*
        //if a bullet collides with enemy
        if (col.gameObject.tag == "Projectiles")
        {
            Debug.Log("hit with projectile");
            TowerProjectile projectileScript = col.gameObject.GetComponent<TowerProjectile>();
            Debug.Log(projectileScript.getDamage());
        
        }*/
    }
    IEnumerator attack()
    {
        // play attack animation
        Debug.Log("attack");
        canAttack = false;
        yield return new WaitForSeconds(atkSpeed);
        canAttack = true;
    }


    /*
        public void OnTriggerEnter2D(Collider2D col)
        {
            Debug.Log("entered");

        //what i came in contact with
      TowerScript tower = col.gameObject.GetComponent<TowerScript>();

        //telling the tower script to attack this game object
        tower.TryAttack(this.gameObject);
            /*
            //if an enemy comes into the range
            if (col.gameObject.tag == "Enemy")
            {
                GameObject target = col.gameObject;
                Debug.Log("Grabbed");
            }
            
        }
            */

    // Start is called before the first frame update
    private EnemyStats Enemy;
    private Rigidbody2D RB;
    //   private GameObject GO;
    void Start()
    {
        //    GO = GetComponent<GameObject>();
        RB = GetComponent<Rigidbody2D>();
        //RB.velocity = new Vector2(1, 0);

        // get speed
        Enemy = new EnemyStats(RB.velocity, HP, DMG);
        testing = GameObject.FindGameObjectWithTag("Testing").GetComponent<Testing>();

        //get the object that this script is on and determine health from that
    }

    public EnemyStats getStats()
    {
        return Enemy;
    }

    // Update is called once per frame
    void Update()
    {


    }
}
