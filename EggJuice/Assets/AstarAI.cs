using UnityEngine;
// Note this line, if it is left out, the script won't know that the class 'Path' exists and it will throw compiler errors
// This line should always be present at the top of scripts which use pathfinding
using Pathfinding;
using System.Collections;

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
    [SerializeField] private Testing testing;

    private Vector3 cPos;
    private Vector3 ePos;
    private float distance;
    private float shortestDistance;
    private GameObject closestChicken;

    public void Start()
    {
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
            if (EnemyOrChicken)
            {
                //Debug.Log("choosing new destination!");
                /*if (chicken)
                {
                    targetPosition = chicken.transform;
                }
                else
                {*/
                // find new chicken
                if (testing.getNumChickens() > 0 && testing.chickens[0].transform != null)
                {
                    shortestDistance = calculateDistance(testing.chickens[0].transform, transform);
                    closestChicken = testing.chickens[0];

                    for (int i = 0; i < testing.getNumChickens(); i++)
                    {
                        if (testing.chickens[i].transform != null)
                        {
                            cPos = testing.chickens[i].transform.position;
                            ePos = transform.position;
                            distance = calculateDistance(testing.chickens[i].transform, transform);
                            //Debug.Log(distance);

                            if (Mathf.Abs(distance) < Mathf.Abs(shortestDistance))
                            {
                                //Debug.Log("shortestDistance: " + shortestDistance);
                                shortestDistance = distance;
                                closestChicken = testing.chickens[i];
                            }
                        }
                    }
                    if (closestChicken.transform != null)
                    {
                        //targetPosition.position = closestChicken.transform.position;
                        //}
                        //Debug.Log("targetEnemyPosition: " + targetPosition);
                        seeker.StartPath(transform.position, closestChicken.transform.position, OnPathComplete);
                    }
                }
                //path.BlockUntilCalculated();
                yield return new WaitForSeconds(0.3f);
            }
            else
            {
                // pick random location
                /*int x = Random.Range(0, 48);
                int y = Random.Range(0, 20);
                Debug.Log("Range: " + x);
                Debug.Log("Ranch: " + y);*/
                //targetPosition.position = ; 
                //Debug.Log("targetPositionFor_Chicken: " + targetPosition.position);

                // Debug.Log("targetChickenPosition: " + targetPosition);
                //Debug.Log("Seekder: " + testing.getWorldPositionFromGrid(Random.Range(0, 48), Random.Range(0, 20)));
                this.seeker.StartPath(transform.position, new Vector3(Random.Range(-12, 10), Random.Range(-5, 5)), OnPathComplete);

                yield return new WaitForSeconds(5f);
            }
            //seeker.CancelCurrentPathRequest();
            //reachedEndOfPath = true;
            //path.Release(path, false);
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

        if (path == null)
        {
            // We have no path to follow yet, so don't do anything
            return;
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
}