using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EggHatching : MonoBehaviour
{
    public int Spawned;
    public int ToSpawn;
    // Start is called before the first frame update
    void Start()
    {
        GameManager GM = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
        Spawned = GM.Round;
        ToSpawn = Spawned +2;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
