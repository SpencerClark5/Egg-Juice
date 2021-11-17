using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerScript : MonoBehaviour
{
    [SerializeField] private int Cost;
    [SerializeField] private int Health;
    [SerializeField] private int DMG;
    [SerializeField] private int FireRate;
    [SerializeField] private int ProjectileSpeed;
    private class TowerStats
    {
        int TowerHealth;
        int TowerDamage;
        int TowerCost;
        double fireRate; //in seconds
        int ProjectileSpeed;

        public TowerStats(int cost, int health, int dmg, double FR, int PS)
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
    private List<GameObject> targets = new List<GameObject>();
    void Start()
    {
        TowerRigidBody = GetComponent<Rigidbody2D>();
        MyTower = new TowerStats(Cost, Health, DMG, FireRate,ProjectileSpeed);
        //   StartCoroutine(Wait());
        // TowerProjectile TP = Projectile.GetComponent<TowerProjectile>();
        //TowerStats Fence = new TowerStats(2, 100, 10);
    }


    GameObject Target;
    public void OnTriggerEnter2D(Collider2D col)
    {
        if (this.gameObject.name == "Ranged_Tower")
        {


            //if an enemy comes into the range
            if (col.gameObject.tag == "Enemy")
            {
                //Target = col.gameObject;
                Debug.Log("col.gameObject: " + col.gameObject);
                targets.Add(col.gameObject);
                if (targets.Count > 0)
                {
                    TryAttack(targets[0]);
                }
        } }
    }

    public void OnTriggerExit2D(Collider2D col)
    {
        if (this.gameObject.name == "Ranged_Tower")
        {

            if (col.gameObject.tag == "Enemy")
            {
                //Target = null;
                if (targets.Count > 0)
                {
                    targets.Remove(col.gameObject);
                }
                //Debug.Log("Target is now null");
                //otherwise target nothing
            }
        }
    }

    public GameObject Projectile;
    public Transform Ranged_Tower;

    public GameObject GetTarget(GameObject GO)
    {
        return GameObject.FindWithTag("Enemy");
    }


    public void TryAttack(GameObject GO)
    {
        StartCoroutine(WaitForAttack((float)MyTower.GetFR()));
        

        Rigidbody2D ProjectileRB;
        Vector3 TargetMoveDirection;
        IEnumerator WaitForAttack(float Speed)
        {
            while (targets.Count > 0) {

                //spawns a projectile at the center of the tower
                GameObject proj = Instantiate(Projectile, Ranged_Tower.position, Ranged_Tower.rotation);
                //grabs the RB from it
                ProjectileRB = proj.GetComponent<Rigidbody2D>();
                //grabs the script from the projectile
                TowerProjectile projectileScript = proj.GetComponent<TowerProjectile>();
                //sets the damage of the projectile equal to the tower damage
                projectileScript.setDamage(MyTower.getDamage());
                //finds the direction of which the target is moving
                TargetMoveDirection = (targets[0].transform.position - transform.position).normalized * MyTower.GetPS();
                //gives the target a new velocity in that direction
                ProjectileRB.velocity = new Vector3(TargetMoveDirection.x, TargetMoveDirection.y);
                yield return new WaitForSecondsRealtime(Speed);

            }

        }
        // Update is called once per frame
        void Update()
        {




        }
    } 
}
