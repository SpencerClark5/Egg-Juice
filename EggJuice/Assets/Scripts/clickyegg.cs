using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class clickyegg : MonoBehaviour
{
    [SerializeField] private GameObject Chicken;
    [SerializeField] private GameObject EGG;
    private Testing testing;
    GameManager GM;
    private bool KilledByEnemy = false;


    // Start is called before the first frame update
    void Start()
    {
        GM = GameObject.FindWithTag("GameManager").GetComponent<GameManager>();
        testing = GameObject.FindGameObjectWithTag("Testing").GetComponent<Testing>();

        if (EGG != null)
        {
            //   GameObject EggObject = Instantiate(EGG, this.transform.position, this.transform.rotation);
            // SpawnEgg();
        }
    }

    public void GameStateChange(string GameState)
    {      
    SpawnEgg();
    }



    public void setKilledByEnemy()
    {
        KilledByEnemy = true;
    }

    public void SpawnEgg()
    {
        //when the game state is changed
       
            Debug.Log("Looking to spawn");
            Debug.Log(GM.Round);
            Debug.Log(GM.getRoundEnemies(GM.Round).Count);
            //determine a random time when it will spawn in the round between 0 and enemies*spawn rate
            float SpawnTime = UnityEngine.Random.Range(0,(float)GM.getRoundEnemies(GM.Round).Count * GM.spawnRate);
            Debug.Log("Picked Spawn time " + SpawnTime);
            //start the counter to spawn the egg
            StartCoroutine(WaitToSpawn(SpawnTime));
        


        


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
        if (this.gameObject.tag != "Chicken") {
        pickUpEgg();
         }
       
    }

    
    void OnDestroy()
    {
        if (this.gameObject.tag != "Chicken" && !KilledByEnemy)
        {


            GameManager GM = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
            //increases currecny by 1
            GM.IncrementCurrency(1);
            testing.removeEgg(this.gameObject);
        }
    }
    
    // Update is called once per frame
    void Update()
    {
      
    }
 IEnumerator WaitToSpawn(float Wait)
    {
        yield return new WaitForSecondsRealtime(Wait);
        Debug.Log("spawning..");
        GameObject EggObject = Instantiate(EGG, Chicken.transform.position, Chicken.transform.rotation);
        testing.addEgg(EggObject);
    }

}
