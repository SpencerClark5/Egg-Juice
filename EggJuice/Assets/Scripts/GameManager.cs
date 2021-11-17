using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


public class GameManager : MonoBehaviour {

   private int currency=0;
    public static GameManager Instance;
    public GameState State;
    public static event Action<GameState> OnGameStateChanged;
    // spawn rate delay
    [SerializeField] public float spawnRate;
    clickyegg Chicken;


    //round 1 enemies, 3 enemies
    // public List<GameObject> Enemies = new List<GameObject>();
    [SerializeField] private List<GameObject> Enemies;
    [SerializeField] private List<GameObject> SpawnPoints;
    private List<GameObject> RoundOne = new List<GameObject>();
    public int Round;
    int EnemyCount;
    int ChickenCount;
    //when we add eggs hatching this will have to be updated

    void Awake()
    {
        Instance = this;
    }

    public void  IncrementCurrency(int cur)
    {
        //increases currecy based off of what was clicked
        currency += cur;
        //this updates the text
        GameObject.Find("CurrencyText").GetComponent<UnityEngine.UI.Text>().text = "Currency: " + currency;

    }

    public void RemoveCurrency(int cost)
    {



        currency -= cost;
        GameObject.Find("CurrencyText").GetComponent<UnityEngine.UI.Text>().text = "Currency: " + currency;
    }

    public void UpdateGameState(GameState newState) {

        State = newState;
        switch (newState)
        {

     
            case GameState.PreRound:
            HandlePreRound();
                break;
            case GameState.Round:
            HandleRound();
                break;
            case GameState.Win:
                break;
            case GameState.Lose:
                handleLose();
                break;
            default:
               throw new ArgumentOutOfRangeException(nameof(newState), newState, null);



        }



       OnGameStateChanged?.Invoke(newState);
    }
   


    private void PrepareEnemys()
    {
        //  Enemy Round1Enemys = new ArrayList();


        //make round 1 array from enemies in the array
        //add the enemies in the array that I want to spawn round one
        RoundOne.Add(Enemies[0]);
      
        RoundOne.Add(Enemies[0]);
       
        RoundOne.Add(Enemies[0]);
    



    }
                                                        


    // Start is called before the first frame update
    void Start()
    {
        PrepareEnemys();
        //have to arrays, one of enemies that we could spawn, and one that we want to spawn this round
        //  PrepareEnemys();
        //get the enemy script?

        // Chicken = GameObject.
        ChickenCount = GameObject.FindGameObjectsWithTag("Chicken").Length;
        EnemyScript enemy = GameObject.FindWithTag("GameManager").GetComponent<EnemyScript>();
        
        GameObject.Find("CurrencyText").GetComponent<UnityEngine.UI.Text>().text = "Currency: " + currency;
        UpdateGameState(GameState.Round);
    }

    // Update is called once per frame
    void Update()
    {
        /*
        ChickenCount = GameObject.FindGameObjectsWithTag("Chicken").Length;
      //  Debug.Log(ChickenCount);
        if (ChickenCount == 0)
        {
            UpdateGameState(GameState.Lose);
         //   Debug.Log("updated!");
        }
        */
    }

 private void Spawn(List<GameObject> enemyArray)
    {
        //finds the amount of enemies left in the round
        //picks a random enemy to spawn from the list
        int EnemyToSpawn = UnityEngine.Random.Range(0,enemyArray.Count);
      //  Debug.Log("Picked enemy");


        //is there a way to find the amount of childs something has
        //an add it to an arrayList

        //picks a random index of the spawnpoint list
        int SpawnPoint = UnityEngine.Random.Range(0, SpawnPoints.Count);
      //  Debug.Log("Picked spawn");


        //instantiate enemy at the position of the spawn point

        Instantiate(enemyArray[EnemyToSpawn], SpawnPoints[SpawnPoint].transform.position,SpawnPoints[SpawnPoint].transform.rotation);
        //   Debug.Log("Spawned!");
        //give the enemy the stats

        //dont inlude this part for endless mode


       // enemyArray.RemoveAt(EnemyToSpawn);
        //remove enemy from the list
        
    }

private void HandlePreRound(){
 // do somthing?
 //have a play button

}
    
public List<GameObject> getRoundEnemies(int round)
    {
       
        return RoundOne;
        /*
        if (round == 1)
        {
            return RoundOne;
        }
        */
        /*
        if(round == 2)
        {
            return RoundTwo;
        }
        */
    }

    private void HandleRound()
    {
        Round++;
        //starts the counter for spawning enemies
        StartCoroutine(WaitForSpawn(spawnRate));

        GameObject[] chicknsForEvent = GameObject.FindGameObjectsWithTag("Chicken");

        //use this to hatch eggs
        GameObject[] eggsForEvent = GameObject.FindGameObjectsWithTag("Egg");

        


        for(int i=0; i < chicknsForEvent.Length; i++)
        {
            clickyegg Script = chicknsForEvent[i].GetComponent<clickyegg>();
            Script.GameStateChange(GameState.Round.ToString());
        }



        for (int i = 0; i < eggsForEvent.Length; i++)
        {
            clickyegg Script = eggsForEvent[i].GetComponent<clickyegg>();
            Script.GameStateChange(GameState.Round.ToString());
        }
        //determine a random time when it will spawn in the round between 0 and enemies*spawn rate









    }

    IEnumerator WaitForSpawn(float Wait)
    {
        
        while (Enemies.Count != 0)
        {
           
            Spawn(getRoundEnemies(Round));
            yield return new WaitForSecondsRealtime(Wait);
        }
    }

    private void handleWin()
    {

    }



private void handleLose()
{
        /*
        Debug.Log("You Lose");
        Debug.Log("You Lose");
        Debug.Log("You Lose");
        Debug.Log("You Lose");
        Debug.Log("You Lose");
        Debug.Log("You Lose");
        Debug.Log("You Lose");
        Debug.Log("You Lose");
        Debug.Log("You Lose");
        Debug.Log("You Lose");
        */
    }
    //make an array of enemies per level
    //make spawn function
    public int getCurrency()
    {
        return currency;
    }
    public enum GameState
    {
        PreRound,
        Round,
        Win,
        Lose
       
    }

}