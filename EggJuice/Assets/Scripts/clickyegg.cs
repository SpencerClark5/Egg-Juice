using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class clickyegg : MonoBehaviour
{
    [SerializeField] private GameObject Chicken;
    [SerializeField] private GameObject EGG;


    // Start is called before the first frame update
    void Start()
    {
        if (EGG != null)
        {
            GameObject EggObject = Instantiate(EGG, this.transform.position, this.transform.rotation);
           
        }
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
        Debug.Log("Destroyed");
        Destroy(this.gameObject);
      
    }


    //when the egg is clicked
    public void OnMouseDown()
    {
        
        pickUpEgg();
        
       
    }

    
    void OnDestroy()
    {
        GameManager GM = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
        //increases currecny by 1
        GM.IncrementCurrency(1);
        
    }
   
    // Update is called once per frame
    void Update()
    {
      
    }
 
}
