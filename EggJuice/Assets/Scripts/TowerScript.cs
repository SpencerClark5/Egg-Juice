using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerScript : MonoBehaviour
{
    private class TowerStats
    {
        int TowerHealth;
        int TowerDamage;
        int TowerCost;
        double fireRate; //in seconds
        int ProjectileSpeed;

        public TowerStats(int cost, int health, int dmg,double FR,int PS)
        {
            this.TowerHealth = health;
            this.TowerCost = cost;
            this.TowerDamage = dmg;
            this.fireRate = FR;
            this.ProjectileSpeed = PS;
        }
        public int getHealth()
        {
            return TowerHealth;
        }

        public int getDamage()
        {
            return TowerDamage;
        }
        public int GetPS()
        {
            return ProjectileSpeed;
        }
        public double GetFR()
        {
            return fireRate;
        }
        public void Damage(int damageAmount)
        {
            TowerHealth -= damageAmount;
            if (TowerHealth < 0) TowerHealth = 0;
        }
        
    }

    // Start is called before the first frame update
    private Rigidbody2D TowerRigidBody;
    TowerStats MyTower;
        void Start()
    {
        TowerRigidBody = GetComponent<Rigidbody2D>();
         MyTower =new TowerStats(1,1,1,.5,3);
     //   StartCoroutine(Wait());
        // TowerProjectile TP = Projectile.GetComponent<TowerProjectile>();
        //TowerStats Fence = new TowerStats(2, 100, 10);
    }


    GameObject Target;
     public void OnTriggerEnter2D(Collider2D col)
    {
        //if an enemy comes into the range
        if (col.gameObject.tag == "Enemy")
        {
            GameObject Target = col.gameObject;
            TryAttack(Target);
            
        }
    }

    public GameObject Projectile;
    public Transform Ranged_Tower;
    //spawning a projectile (instantiate)
    //adding force to the projectile towards the target

    public GameObject GetTarget(GameObject GO)
    {
        return GameObject.FindWithTag("Enemy");
    }

    Rigidbody2D ProjectileRB;
    Vector3 TargetMoveDirection;
    public void TryAttack(GameObject GO)
    {
            //spawns a projectile at the center of the tower
            GameObject proj = Instantiate(Projectile, Ranged_Tower.position, Ranged_Tower.rotation);
            //grabs the RB from it
            ProjectileRB = proj.GetComponent<Rigidbody2D>();
            //finds the direction of which the target is moving
            TargetMoveDirection = (GetTarget(GO).transform.position - transform.position).normalized * MyTower.GetPS();
            //gives the target a new velocity in that direction
            ProjectileRB.velocity = new Vector3(TargetMoveDirection.x, TargetMoveDirection.y);
           
        

    }
    // Update is called once per frame
    void Update()
    {

       //check the collider on the tower for an enemy to come in contact

       
    }
}