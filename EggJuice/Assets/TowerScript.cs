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

        public TowerStats(int cost, int health, int dmg)
        {
            this.TowerHealth = health;
            this.TowerCost = cost;
            this.TowerDamage = dmg;
        }
        public int getHealth()
        {
            return TowerHealth;
        }

        public int getDamage()
        {
            return TowerDamage;
        }

        public void Damage(int damageAmount)
        {
            TowerHealth -= damageAmount;
            if (TowerHealth < 0) TowerHealth = 0;
        }
    }
        // Start is called before the first frame update
        void Start()
    {
            TowerStats Fence = new TowerStats(2, 100, 10);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
