using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomMovement : MonoBehaviour
{
    [SerializeField] private Testing testing;


    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(WalkToNewLoc());
    }

    IEnumerator WalkToNewLoc()
    {
        // choose new location
        // walk to location
        yield return new WaitForSeconds(2);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
