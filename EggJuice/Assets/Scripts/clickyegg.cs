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
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        //when an egg is clicked
        if (Input.GetMouseButtonUp(0))
        {
            Collider2D targetObject = Physics2D.OverlapPoint(mousePosition);
            Debug.Log("Click!");
            //play animation
            //+1 currency
            currency += 1;
            //destroy egg

        }




    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
