using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerPlacementScript : MonoBehaviour
{

    public GameObject tower;

    // Start is called before the first frame update
    void Start()
    {

        Debug.Log("started");
        //float xPos = this.transform.position.x;
        //float yPos = this.transform.position.y;
        //flaot xMin = xPos - this.transform.
    }
    public void OnMouseUp()
    {
        Debug.Log("image clicked!");
    }
    public void OnMouseExit()
    {
        Debug.Log("mouse exited!");
    }
    
    // Update is called once per frame
    void Update()
    {
        /*Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        if (Input.GetMouseButtonDown(0) && !selectedObject)
        {
            Collider2D targetObject = Physics2D.OverlapPoint(mousePosition);

            if (targetObject && targetObject == collider)
            {
                selectedObject = targetObject.transform.gameObject;
                
                offset = selectedObject.transform.position - mousePosition;
            }
        }

        if (selectedObject)
        {
            //selectedObject.transform.position = mousePosition + offset;
        }

        if (Input.GetMouseButtonUp(0) && selectedObject)
        {
            
            selectedObject = null;
        }*/
    }

    

    
}
