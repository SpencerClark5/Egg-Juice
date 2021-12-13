using UnityEngine;
// Note this line, if it is left out, the script won't know that the class 'Path' exists and it will throw compiler errors
// This line should always be present at the top of scripts which use pathfinding
using Pathfinding;
using System.Collections;
using System.Collections.Generic;

[HelpURL("http://arongranberg.com/astar/docs/class_partial1_1_1_astar_a_i.php")]
public class AstarAI : MonoBehaviour
{
    private Transform targetPosition;

    [SerializeField] private Seeker seeker;
    private CharacterController controller;
    // was public
    private Path path;
    // was public
    [SerializeField] private float speed = 2;
    // was public
    private float nextWaypointDistance = 3;

    private int currentWaypoint = 0;
    //was public
    private bool reachedEndOfPath;

    [SerializeField] private bool EnemyOrChicken;
    [SerializeField] private bool targetChicken;
    [SerializeField] private bool targetEgg;
    [SerializeField] private List<GameObject> decoys;
    private int numDecoys = 0;
    private Testing testing;
    private bool destroying = false;

    private Vector3 cPos;
    private Vector3 ePos;
    private float distance;
    private float shortestDistance;
    private GameObject closestChicken;
    private bool runOffMap = false;

    public void Start()
    {
        testing = GameObject.FindGameObjectWithTag("Testing").GetComponent<Testing>();
        //seeker = GetComponent<Seeker>();
        // If you are writing a 2D game you should remove this line
        // and use the alternative way to move sugggested further below.
        //controller = GetComponent<CharacterController>();

        // Start a new path to the targetPosition, call the the OnPathComplete function
        // when the path has been calculated (which may take a few frames depending on the complexity)
        StartCoroutine(ChooseNewDestination());
        //seeker.StartPath(transform.position, targetPosition.position, OnPathComplete);
    }

    IEnumerator ChooseNewDestination()
    {
        // set new destination
        while (true)
        {
            if (!runOffMap)
            {
                //Debug.Log("RunOffMap: " + runOffMap);
                if (EnemyOrChicken)
                {
                    if (targetEgg && targetChicken)
                    {
                        // finds decoy
                        if (numDecoys > 0 && decoys[0].transform != null)
                        {
                            calculatePath(numDecoys, decoys);
                        }
                        // find new chicken
                        else if (testing.getEggsAndChickens() > 0 && testing.eggsAndChickens[0].transform != null)
                        {
                            calculatePath(testing.getEggsAndChickens(), testing.eggsAndChickens);
                        }
                        yield return new WaitForSeconds(0.3f);
                    }
                    else if (targetChicken)
                    {
                        // finds decoy
                        if (numDecoys > 0 && decoys[0].transform != null)
                        {
                            calculatePath(numDecoys, decoys);
                        }
                        // find new chicken
                        else if (testing.getNumChickens() > 0 && testing.chickens[0].transform != null)
                        {
                            calculatePath(testing.getNumChickens(), testing.chickens);
                        }
                        yield return new WaitForSeconds(0.3f);
                    }
                    else if (targetEgg)
                    {
                        if (testing.getNumEggs() > 0 && testing.eggs[0].transform != null)
                        {
                            calculatePath(testing.getNumEggs(), testing.eggs);
                        }
                        yield return new WaitForSeconds(0.3f);
                    }
                    
                    yield return new WaitForSeconds(0.3f);

                }
                else
                {
                    this.seeker.StartPath(transform.position, new Vector3(Random.Range(-8, 7), Random.Range(-5, 5)), OnPathComplete);

                    yield return new WaitForSeconds(5f);
                }

            }
            else
            {
                // start path to somewhere off map
                if (transform.position.x > 5)
                {
                    // go right
                    seeker.StartPath(transform.position, new Vector3(transform.position.x + (10 - transform.position.x),
                        transform.position.y, transform.position.z), OnPathComplete);
                }
                else if (transform.position.x < -5)
                {
                    // go left
                    seeker.StartPath(transform.position, new Vector3(transform.position.x + (-5 + transform.position.x),
                        transform.position.y, transform.position.z), OnPathComplete);
                }
                else if (transform.position.y < 0)
                {
                    // go down
                    seeker.StartPath(transform.position, new Vector3(transform.position.x, transform.position.y +
                        (-7 + transform.position.y), transform.position.z), OnPathComplete);
                }
                else
                {
                    // go up
                    seeker.StartPath(transform.position, new Vector3(transform.position.x, transform.position.y +
                        (7 - transform.position.y), transform.position.z), OnPathComplete);
                }
                yield return new WaitForSeconds(0.5f);
            }
        }
    }

    private void calculatePath(int num, List<GameObject> list)
    {
        shortestDistance = calculateDistance(list[0].transform, transform);
        closestChicken = list[0];

        for (int i = 0; i < num; i++)
        {
            if (list[i].transform != null)
            {
                cPos = list[i].transform.position;
                ePos = transform.position;
                distance = calculateDistance(list[i].transform, transform);

                if (Mathf.Abs(distance) < Mathf.Abs(shortestDistance))
                {
                    shortestDistance = distance;
                    closestChicken = list[i];
                }
            }
        }
        if (closestChicken.transform != null)
        {
            seeker.StartPath(transform.position, closestChicken.transform.position, OnPathComplete);
        }
    }

    // calculates distance between two transforms. t1 chicken and t2 is enemy.
    private float calculateDistance(Transform t1, Transform t2)
    {
        return Mathf.Sqrt(Mathf.Pow((t1.position.x - t2.position.x), 2) + Mathf.Pow((t1.position.y - t2.position.y), 2));
    }

    public void OnPathComplete(Path p)
    {
        //Debug.Log("A path was calculated. Did it fail with an error? " + p.error);

        if (!p.error)
        {
            path = p;
            // Reset the waypoint counter so that we start to move towards the first point in the path
            currentWaypoint = 0;
        }
    }

    public void Update()
    {
        if (targetEgg && !targetChicken && testing.getNumEggs() == 0)
        {
            Debug.Log("made it to where couruoutine should start");
            StartCoroutine(WaitForEgg());
        }

        if (path == null)
        {

            // We have no path to follow yet, so don't do anything
            return;
        }

        if (gameObject.name == "Raccoon(Clone)")
        {
            if (gameObject.transform.position.x < -9 || gameObject.transform.position.x > 9 ||
                gameObject.transform.position.y < -6 || gameObject.transform.position.y > 6)
            {
                runOffMap = false;
            }
        }
        // Check in a loop if we are close enough to the current waypoint to switch to the next one.
        // We do this in a loop because many waypoints might be close to each other and we may reach
        // several of them in the same frame.
        reachedEndOfPath = false;
        // The distance to the next waypoint in the path
        float distanceToWaypoint;
        while (true)
        {
            // If you want maximum performance you can check the squared distance instead to get rid of a
            // square root calculation. But that is outside the scope of this tutorial.
            distanceToWaypoint = Vector3.Distance(transform.position, path.vectorPath[currentWaypoint]);
            if (distanceToWaypoint < nextWaypointDistance)
            {
                // Check if there is another waypoint or if we have reached the end of the path
                if (currentWaypoint + 1 < path.vectorPath.Count)
                {
                    currentWaypoint++;
                }
                else
                {
                    // Set a status variable to indicate that the agent has reached the end of the path.
                    // You can use this to trigger some special code if your game requires that.
                    reachedEndOfPath = true;
                    break;
                }
            }
            else
            {
                break;
            }
        }

        // Slow down smoothly upon approaching the end of the path
        // This value will smoothly go from 1 to 0 as the agent approaches the last waypoint in the path.
        var speedFactor = reachedEndOfPath ? Mathf.Sqrt(distanceToWaypoint / nextWaypointDistance) : 1f;

        // Direction to the next waypoint
        // Normalize it so that it has a length of 1 world unit
        Vector3 dir = (path.vectorPath[currentWaypoint] - transform.position).normalized;
        // Multiply the direction by our desired speed to get a velocity
        Vector3 velocity = dir * speed * speedFactor;

        // Move the agent using the CharacterController component
        // Note that SimpleMove takes a velocity in meters/second, so we should not multiply by Time.deltaTime
        //controller.SimpleMove(velocity);

        // If you are writing a 2D game you should remove the CharacterController code above and instead move the transform directly by uncommenting the next line
        transform.position += velocity * Time.deltaTime;

    }

    private IEnumerator WaitForEgg()
    {
        yield return new WaitForSeconds(5f);
        Debug.Log("waitedForEgg");
        if (testing.getNumEggs() == 0)
        {
            Debug.Log("no eggs");
            Destroy(this.gameObject);
            Debug.Log("should be destroyed");
        }
    }

    public void removeDecoy(GameObject decoy)
    {
        decoys.Remove(decoy);
        numDecoys--;
    }

    public int getNumDecoys()
    {
        return numDecoys;
    }

    public void addDecoys(GameObject decoy)
    {
        decoys.Add(decoy);
        numDecoys++;
    }

    public bool getDestroying()
    {
        return destroying;
    }

    public void setDestroying(bool destroying)
    {
        this.destroying = destroying;
    }

    public void setRunOffMap(bool onOrOff)
    {
        runOffMap = onOrOff;
    }

    public bool getRunOffMap()
    {
        return runOffMap;
    }

    public bool getTargetEgg()
    {
        return targetEgg;
    }
    
    public bool getTargetChicken()
    {
        return targetChicken;
    }
}