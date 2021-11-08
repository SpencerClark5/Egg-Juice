using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class clickyegg : MonoBehaviour
{
    private int currency=0;
    [SerializeField] private GameObject Chicken;
    [SerializeField] private GameObject EGG;
    

    // Start is called before the first frame update
    void Start()
    {
        GameObject EggObject = Instantiate(EGG, this.transform.position, this.transform.rotation);
        GameObject.Find("CurrencyText").GetComponent<UnityEngine.UI.Text>().text = "Currency: " + currency;
    }

    public void SpawnEgg()
    {
        //wait for the condidition for the egg to spawn (probably round based)
        //GameObject EggObject = Instantiate(EGG, Chicken.position, Chicken.rotation);




    }


    public void pickUpEgg()
    {
        
        
      //  Debug.Log(CurrencyText.text);
       // GameObject.Find("CurrencyText").GetComponent<UnityEngine.UI.Text>().text = CurrencyText.text;
       Destroy(this.gameObject);
       Debug.Log("Destroyed");
    }


    //when the egg is clicked
    public void OnMouseDown()
    {
        pickUpEgg();
        
       
    }

    /*
    void OnDestroy()
    {
      //  currency++;
        GameObject.Find("CurrencyText").GetComponent<UnityEngine.UI.Text>().text = "Currency: " + currency;
            //"Currency: " + currency;
    }
    */
    // Update is called once per frame
    void Update()
    {
      
    }
 
}
