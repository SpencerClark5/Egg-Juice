using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImmunityScript : MonoBehaviour
{
    [SerializeField] private int health;
    [SerializeField] private Animator Bobble;
    private bool immune = false;
   
   private IEnumerator Immunity()
    {
      //  Debug.Log("Immunity");
        // make this immune
        immune = true;
        // play some flashing animation
        yield return new WaitForSeconds(0.1f);
     //   Debug.Log("ImmunityGone");
        // make un immune
        immune = false;
        // stop playing flashing animation
    }

    // returns whether or not it should be destoryed
    public bool takeDamage(int damage)
    {
        if (immune == false)
        {
            if (this.gameObject.name == "Decoy(Clone)") {
                Bobble.SetTrigger("Wiggle");
            }




          


            health -= damage;
            if (health <= 0)
            {
                return true;
            }
            StartCoroutine(Immunity());
        }
        return false;
    }

    public bool getImmunity()
    {
        return immune;
    }



}
