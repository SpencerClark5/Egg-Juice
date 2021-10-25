using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chicken : MonoBehaviour
{
    // Start is called before the first frame update
    float velX;
    float velY;
    float time;
    const float VEL_MIN = 0.5F;
    const float VEL_MAX = 2F;
    const float MIN_TIME = 1F;
    const float MAX_TIME = 5F;
    int positiveX;
    int positiveY;
    Rigidbody2D rb;
    void Start()
    {
        rb = this.gameObject.GetComponent<Rigidbody2D>();
        StartCoroutine(walkTimer());
    }

    // Update is called once per frame
    void Update()
    {
        

    }

    public void SpawnEgg()
    {



    }


    IEnumerator walkTimer()
    {
        velX = Random.Range(VEL_MIN, VEL_MAX);
        velY = Random.Range(VEL_MIN, VEL_MAX);
        time = Random.Range(MIN_TIME, MAX_TIME);
        positiveX = Random.Range(0, 2);
        positiveY = Random.Range(0, 2);
        if (positiveX == 0)
        {
            velX *= -1F;
        }
        if (positiveY == 0)
        {
            velY *= -1F;
        }
        rb.velocity = new Vector2(velX, velY);
        yield return new WaitForSeconds(time);
        rb.velocity = new Vector2(0, 0);
        yield return new WaitForSeconds(2);
        StartCoroutine(walkTimer());
    }

    public void OnCollisionEnter2D(Collision2D col)
    {
        //if chicken collides with enemy
        if (col.gameObject.name == "Enemy")
        {

            Debug.Log("kaboom");
            //grabs the script on the tower
            Destroy(this.gameObject);

            //TowerScript tower = col.gameObject.GetComponent<TowerScript>();
            // Debug.Log(tower.getDamage());

        }
    }
}
