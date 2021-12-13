using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour {

   private int currency=2;
    public static GameManager Instance;
    public GameState State;
    public static event Action<GameState> OnGameStateChanged;
    // spawn rate delay
    [SerializeField] public float spawnRate;
    clickyegg Chicken;
    [SerializeField] private GameObject NewChicken;
    Testing testingscript;
    GameObject objectToDisappear;
    Animator Animation;

    //round 1 enemies, 3 enemies
    // public List<GameObject> Enemies = new List<GameObject>();
    [SerializeField] private List<GameObject> Enemies;
    [SerializeField] private List<GameObject> SpawnPoints;
    private List<GameObject> RoundOne = new List<GameObject>();
    private List<GameObject> RoundTwo = new List<GameObject>();
    private List<GameObject> RoundThree = new List<GameObject>();
    private List<GameObject> RoundFour = new List<GameObject>();
    private List<GameObject> RoundFive = new List<GameObject>();
    private List<GameObject> RoundSix = new List<GameObject>();
    private List<GameObject> RoundSeven = new List<GameObject>();
    private List<GameObject> RoundEight= new List<GameObject>();

    public int Round;
    int ChickenCount;
    

    void Awake()
    {
        Instance = this;
    }

    public void  IncrementCurrency(int cur)
    {
        //increases currecy based off of what was clicked
        currency += cur;
        //this updates the text
        GameObject.Find("CurrencyText").GetComponent<UnityEngine.UI.Text>().text = "Egg Juice: " + currency;

    }

    public void RemoveCurrency(int cost)
    {
        currency -= cost;
        GameObject.Find("CurrencyText").GetComponent<UnityEngine.UI.Text>().text = "Egg Juice: " + currency;
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
                handleWin();
                break;
            case GameState.Lose:
                handleLose();
                break;
            default:
               throw new ArgumentOutOfRangeException(nameof(newState), newState, null);



        }



       OnGameStateChanged?.Invoke(newState);
    }

    public enum GameState
    {
        PreRound,
        Round,
        Win,
        Lose

    }

    private void PrepareEnemys()
    {
        //  Enemy Round1Enemys = new ArrayList();


        //make round 1 array from enemies in the array
        //add the enemies in the array that I want to spawn round one

        //Round 1
        addPlate(RoundOne, 3);
      
        //Round 2
        addPlate(RoundTwo, 2);
        addBook(RoundTwo, 2);
      

        //Round 3
        addBook(RoundThree, 2);
        addRacoon(RoundThree, 2);
        addPlate(RoundThree, 1);
        

        //Round 4
        addPlate(RoundFour, 2);
        addRacoon(RoundFour, 2);
        addBook(RoundFour, 3);
        addCat(RoundFour, 3);
       

        //Round 5
        addPlate(RoundFive, 4);
        addRacoon(RoundFive, 3);
        addBook(RoundFive, 1);
        addCat(RoundFive, 1);

        //Round 6

        addRacoon(RoundSix, 4);
        addBook(RoundSix, 4);
        addCat(RoundSix, 3);

        //Round 7

        addPlate(RoundSeven, 6);
        addRacoon(RoundSeven, 4);
        addBook(RoundSeven, 6);
        addCat(RoundSeven, 5);


        //Round 8

        addPlate(RoundEight, 12);
        addRacoon(RoundEight, 5);
        addBook(RoundEight, 6);
        addCat(RoundEight, 4);








    }
                 
    public void addPlate(List<GameObject> array,int amount)
    {
        for(int i = 0; i <amount; i++)
        {
            array.Add(Enemies[0]);
        }

    }

    public void addBook(List<GameObject> array, int amount)
    {
        for (int i = 0; i < amount; i++)
        {
            array.Add(Enemies[1]);
        }

    }

    public void addCat(List<GameObject> array, int amount)
    {
        for (int i = 0; i < amount; i++)
        {
            array.Add(Enemies[3]);
        }

    }

    public void addRacoon(List<GameObject> array, int amount)
    {
        for (int i = 0; i < amount; i++)
        {
            array.Add(Enemies[2]);
        }

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
        testingscript = GameObject.Find("Testing").GetComponent<Testing>();

        GameObject.Find("CurrencyText").GetComponent<UnityEngine.UI.Text>().text = "Egg Juice: " + currency;
        GameObject.Find("RoundText").GetComponent<UnityEngine.UI.Text>().text = "Round " + Round;
        // UpdateGameState(GameState.Round);
        objectToDisappear = GameObject.Find("PlayButton");
        Animation = GameObject.Find("ButtonImage").GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
        
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


        enemyArray.RemoveAt(EnemyToSpawn);
        //remove enemy from the list
        
    }

private void HandlePreRound(){
        // do somthing?
        //have a play button
        Animation.SetBool("PreRound", true);
        Animation.SetBool("OnClick", false);
    }

    public List<GameObject> getRoundEnemies(int round) {

        if (round == 1)
        {
            return RoundOne;
        }
        else if (round == 2)
        {
            return RoundTwo;
        }
        else if (round == 3)
        {
            return RoundThree;
        }
        else if (round == 4)
        {
            return RoundFour;
        }
        else if (round == 5)
        {
            return RoundFive;
        }
        else if (round == 6)
        {
            return RoundSix;
        }
        else if (round == 7)
        {
            return RoundSeven;
        }
        else if (round == 8)
        {
            return RoundEight;
        }
        else
        {
            return new List<GameObject>();
        }
    } 
    

    private void HandleRound()
    {
        //use this to hatch eggs

        Round++;
        GameObject.Find("RoundText").GetComponent<UnityEngine.UI.Text>().text = "Round " + Round;
        //starts the counter for spawning enemies
        StartCoroutine(WaitForSpawn(spawnRate));

        GameObject[] chicknsForEvent = GameObject.FindGameObjectsWithTag("Chicken");

        //use this to hatch eggs
        GameObject[] eggsForEvent = GameObject.FindGameObjectsWithTag("Egg");

        

        //this goes through all of the chickens and sets a random time for them to lay an egg
        for(int i=0; i < chicknsForEvent.Length; i++)
        {
            //gets each specific chicken and changes the game state
            clickyegg Script = chicknsForEvent[i].GetComponent<clickyegg>();
            Script.GameStateChange(GameState.Round.ToString());
        }


        //this goes through all of the eggs
        for (int i = 0; i < eggsForEvent.Length; i++)
        {
            //gets each specific egg and changes the game state
            clickyegg Script = eggsForEvent[i].GetComponent<clickyegg>();
            Script.GameStateChange(GameState.Round.ToString());
        }


        //this goes thru all of the eggs
        for (int i = 0; i < eggsForEvent.Length; i++)
        {
            //gets each specific egg
            EggHatching Egg = eggsForEvent[i].GetComponent<EggHatching>();
            Debug.Log(Egg.ToSpawn);
            //if the egg is ready to spawn
            if (Egg.ToSpawn == Round)
            {
                //spawn chicken at that spot
                GameObject chicken = Instantiate(NewChicken, Egg.transform.position, Egg.transform.rotation);
                testingscript.addChicken(chicken);
                //delete the egg
                Destroy(Egg.gameObject);

               
            }
            

            //gets the round for each egg 
            
        }
        //while the round is going on



        //find a way to make this not always true


        StartCoroutine(WaitingForRound());


        //check num of chickens and num of enemies
        //when either hit 0, change game state




        //get the hatching rounds from the script
        //compare them to when they need to be spawned
        //spawn them when round = spawnround






    }

    private int GetCurrentEnemiesOnScreen()
    {
        int count = GameObject.FindGameObjectsWithTag("Enemy").Length;
        return count;
    }



    IEnumerator WaitingForRound()
    {

        while (State == GameManager.GameState.Round)
        {
            //if all the enemies are dead
            if (GetCurrentEnemiesOnScreen() == 0 && getRoundEnemies(Round).Count == 0)
            {

                //player wins the round, switch game state to preround
                UpdateGameState(GameState.PreRound);
               
                objectToDisappear.SetActive(true);
                //make the button visable
            }
            //the chickens are dead
            if (testingscript.chickens.Count == 0)
            {
                //player loses, set game state to lose
                UpdateGameState(GameState.Lose);
               

            }
            //if player beats all rounds and has chickens left
            //player wins, set game state to win
            yield return new WaitForSecondsRealtime(.5f);
        }
        
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
        SceneManager.LoadScene("Lose Screen", LoadSceneMode.Additive);
    }
    //make an array of enemies per level
    //make spawn function
    public int getCurrency()
    {
        return currency;
    }
    

}