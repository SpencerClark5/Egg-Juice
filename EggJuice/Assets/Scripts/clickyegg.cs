using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class clickyegg : MonoBehaviour
{
    public int currency;
    public Transform Chicken;
    public GameObject EGG;

    // Start is called before the first frame update
    void Start()
    {
        currency = 0;
        GameObject EggObject = Instantiate(EGG, Chicken.position, Chicken.rotation);
    }

    public void SpawnEgg()
    {
        //wait for the condidition for the egg to spawn (probably round based)
        //GameObject EggObject = Instantiate(EGG, Chicken.position, Chicken.rotation);




    }


    public void pickUpEgg()
    {
        Destroy(this.gameObject);
        currency++;
        Debug.Log(currency);
    }


    //when the egg is clicked
    public void OnMouseDown()
    {
        pickUpEgg();
    }

    // Update is called once per frame
    void Update()
    {
      
    }
 
}
