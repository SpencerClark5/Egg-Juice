using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImmunityScript : MonoBehaviour
{
    [SerializeField] private int health;
    private bool immune = false;

    IEnumerator Immunity()
    {
        Debug.Log("Immunity");
        // make this immune
        immune = true;
        // play some flashing animation
        yield return new WaitForSeconds(0.1f);
        Debug.Log("ImmunityGone");
        // make un immune
        immune = false;
        // stop playing flashing animation
    }

    // returns whether or not it should be destoryed
    public bool takeDamage(int damage)
    {
        if (immune == false)
        {
            health -= damage;
            if (health <= 0)
            {
                return true;
            }
            StartCoroutine(Immunity());
        }
        return false;
    }
}
