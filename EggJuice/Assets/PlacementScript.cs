using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlacementScript : MonoBehaviour
{
    public GameObject selectedObject;
    Vector3 offset;
    Collider2D collider;
    Rigidbody2D rigidBody;
    //Rigidbody2D rigidBody;
    // Start is called before the first frame update
    void Start()
    {
        collider = this.gameObject.GetComponent<Collider2D>();
        rigidBody = this.gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        if (Input.GetMouseButtonDown(0) && !selectedObject)
        {
            Collider2D targetObject = Physics2D.OverlapPoint(mousePosition);

            if (targetObject && targetObject == collider)
            {
                selectedObject = targetObject.transform.gameObject;
                //rigidBody.detectCollisions = false;
                collider.enabled = false;
                //rigidBody = selectedObject.GetComponent<Rigidbody2D>();
                //collider.collisions = false;
                offset = selectedObject.transform.position - mousePosition;
            }
        }

        if (selectedObject)
        {
            selectedObject.transform.position = mousePosition + offset;
        }

        if (Input.GetMouseButtonUp(0) && selectedObject)
        {
            collider.enabled = true;
            //rigidBody.detectCollisions = true;
            //rigidBody.detectCollisions = true;
            selectedObject = null;
        }
    }
}
