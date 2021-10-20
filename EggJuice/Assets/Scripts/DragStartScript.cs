using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class DragStartScript : MonoBehaviour, IPointerDownHandler, IPointerExitHandler, IPointerUpHandler
{
    [SerializeField] private int width;
    [SerializeField] private int height;
    [SerializeField] private GameObject tower;
    [SerializeField] private Image visual;
    [SerializeField] private Canvas canvas;
    private Vector3 startPos;
    private Vector3 exitPos;
    private bool clickStarted = false;
    private bool mouseExited = false;
    private bool dragging = false;
    private Image dragVisual;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    // Update is called once per frame
    void Update()
    {
        
        if (clickStarted)
        {
            Debug.Log("clickstarted");
            if (mouseExited)
            {
                mouseExited = false;
                dragging = true;
                Debug.Log("exited");
                dragVisual = Instantiate(visual, new Vector3(Input.mousePosition.x,
                    Input.mousePosition.y),
                    Quaternion.identity);
                dragVisual.transform.SetParent(canvas.transform);

            }
            if (Input.GetMouseButtonUp(0))
            {
                clickStarted = false;
                mouseExited = false;
                dragging = false;
                Destroy(dragVisual.gameObject);
                // make rad and greed squares no longer visible and spawn tower
            }
            if (dragging)
            {
                dragVisual.transform.SetPositionAndRotation(new Vector3(Input.mousePosition.x,
                    Input.mousePosition.y), Quaternion.identity);
                // calculate squares it is over to make red and green squares show for is placeable or not
            }
        }
    }
    
    
    public void OnMouseDrag()
    {
        Debug.Log("DragDetected");
        clickStarted = true;
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

    public void OnPointerUp(PointerEventData eventData)
    {
        throw new System.NotImplementedException();
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        Debug.Log("OnPointerExit called");
        if (clickStarted)
        {
            exitPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mouseExited = true;
        }
    }
}
