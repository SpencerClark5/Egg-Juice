using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class DragStartScript : MonoBehaviour, IPointerDownHandler, IPointerExitHandler
{
    [SerializeField] private int width;
    [SerializeField] private int height;
    [SerializeField] private GameObject tower;
    [SerializeField] private Image visual;
    [SerializeField] private Canvas canvas;
    [SerializeField] private GameManager gameManager;
    private Testing testing;
    [SerializeField] private GameObject dragObject;
    [SerializeField] private int cost;
    [SerializeField] private GameObject darkTransparentSquare;
    // holds the world position of the top left tile
    private Vector3 topLeftCenter;
    private GameObject draggingDragObject;
    private Vector3 startPos;
    private Vector3 exitPos;
    private bool clickStarted = false;
    private bool mouseExited = false;
    private bool dragging = false;
    private Image dragVisual;
    private Vector3 topLeftLocal;
    private Vector3 topRightLocal;
    private Vector3 bottomLeftLocal;
    private Vector3 bottomRightLocal;
    private float cellSize = -5;
    private Vector3 center;
    private bool canAfford = false;
    // Start is called before the first frame update
    void Start()
    {
        testing = GameObject.FindGameObjectWithTag("Testing").GetComponent<Testing>();
    }
    // Update is called once per frame
    void Update()
    {
        if (cellSize <= 0)
        {
            cellSize = testing.GetComponent<Testing>().getGrid().GetCellSize();
        }
        if (gameManager.getCurrency() >= cost && !canAfford)
        {
            // can afford the tower
            darkTransparentSquare.SetActive(false);
            canAfford = true;
        }
        else if (gameManager.getCurrency() < cost && canAfford)
        {
            // cannot afford the tower
            darkTransparentSquare.SetActive(true);
            canAfford = false;
        }
        else if (canAfford)
        {
            if (clickStarted)
            {
                if (mouseExited)
                {
                    mouseExited = false;
                    dragging = true;
                    Debug.Log("exited");
                    //dragVisual = Instantiate(visual, new Vector3(Input.mousePosition.x,
                    //  Input.mousePosition.y),
                    //Quaternion.identity);

                    //testing.remakeListArray(width, height);

                    //dragVisual.transform.SetParent(canvas.transform);

                    draggingDragObject = Instantiate(dragObject, new Vector3(Camera.main.ScreenToWorldPoint(Input.mousePosition).x,
                        Camera.main.ScreenToWorldPoint(Input.mousePosition).y, 0), Quaternion.identity);

                    //draggingDragObject.transform.SetParent(canvas.transform);
                    draggingDragObject.GetComponent<BoxCollider2D>().enabled = true;
                    Debug.Log(draggingDragObject.transform.position);
                    testing.setThings(width * height, this);
                }
                if (dragging)
                {
                    //dragVisual.transform.SetPositionAndRotation(new Vector3(Input.mousePosition.x,
                    //  Input.mousePosition.y), Quaternion.identity);
                    if (draggingDragObject != null)
                    {
                        draggingDragObject.transform.SetPositionAndRotation(new Vector3(Camera.main.ScreenToWorldPoint(Input.mousePosition).x,
                            Camera.main.ScreenToWorldPoint(Input.mousePosition).y), Quaternion.identity);
                    }
                    if (Input.GetMouseButtonUp(0))
                    {
                        clickStarted = false;
                        mouseExited = false;
                        dragging = false;
                        // check if any tiles in tile array are occupied
                        if (testing.checkForOccupied())
                        {
                            // occupied
                            // if they are don't instatiate the tower and just set it up to be dragged again
                            Destroy(draggingDragObject);
                        }
                        else
                        {
                            // not occupied
                            testing.setTilesToOccupied();
                            Destroy(draggingDragObject);
                            Instantiate(tower, center, Quaternion.identity);
                            gameManager.RemoveCurrency(cost);
                        }

                        //Destroy(dragVisual.gameObject);
                        // make rad and greed squares no longer visible and spawn tower
                    }
                    // calculate squares it is over to make red and green squares show for is placeable or not
                    //calculateCorners();
                    //testing.GetComponent<Testing>().setSquares(topLeftLocal, topRightLocal, bottomLeftLocal, bottomRightLocal);
                }
            }
        }
    }

    private void calculateCorners()
    {
        topLeftLocal = new Vector3(Camera.main.ScreenToWorldPoint(Input.mousePosition).x,
            Camera.main.ScreenToWorldPoint(Input.mousePosition).y);
        //new Vector3(Camera.main.ScreenToWorldPoint(Input.mousePosition)/* - (testing.getGrid().GetCellSize() / 2f) * width*/, 
        //Input.mousePosition.y/* + (100f / 2f) * height*/);
        topRightLocal = new Vector3(Camera.main.ScreenToWorldPoint(Input.mousePosition).x + cellSize,
            Camera.main.ScreenToWorldPoint(Input.mousePosition).y + cellSize);
        bottomLeftLocal = new Vector3(Camera.main.ScreenToWorldPoint(Input.mousePosition).x - cellSize,
            Camera.main.ScreenToWorldPoint(Input.mousePosition).y - cellSize);
        bottomRightLocal = new Vector3(Camera.main.ScreenToWorldPoint(Input.mousePosition).x + cellSize,
            Camera.main.ScreenToWorldPoint(Input.mousePosition).y - cellSize);
    }

    public void recalculate(Vector3 center)
    {
        if (width % 2 == 0)//even
        {
            //Debug.Log(cellSize);
            this.center.x = center.x + (width / 2) * cellSize - (1 / 2) * cellSize;
        }
        else//odd
        {
            this.center.x = center.x + (width / 2) * cellSize;
        }
        if (height % 2 == 0)//even
        {
            this.center.y = center.y - (height / 2) * cellSize + (1 / 2) * cellSize;
        }
        else//odd
        {
            this.center.y = center.y - (height / 2) * cellSize;
        }
    }

    public void OnMouseDrag()
    {
        Debug.Log("DragDetected");
        //clickStarted = true;
    }
    private void OnMouseExit()
    {
        Debug.Log("MouseExited");
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        startPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        clickStarted = true;
    }

    /*public void OnPointerUp(PointerEventData eventData)
    {
        throw new System.NotImplementedException();
    }*/

    public void OnPointerExit(PointerEventData eventData)
    {
        Debug.Log("OnPointerExit called");
        if (clickStarted)
        {
            if (!dragging)
            {

                exitPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
               // if (Mathf.Abs(exitPos.magnitude - startPos.magnitude) > 1)
                //{
                    mouseExited = true;
                //}

            }
        }
    }

}
