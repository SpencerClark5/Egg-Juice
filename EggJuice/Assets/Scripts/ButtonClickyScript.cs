using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ButtonClickyScript : MonoBehaviour
{
    [SerializeField] private Button btn = null;
    [SerializeField] private GameObject tower = null;
    [SerializeField] private GameObject pf = null;
    private GridBoy<PathNode> gb;
    private PathFinding pfqe;
    private Testing pfq;
    // Start is called before the first frame update
    void Start()
    {
        btn.onClick.AddListener(ButtonClick);
        pfq = pf.GetComponent<Testing>();
        Debug.Log("pfqqqqqq: " + pfq);
        //pfqe = pfq.pathfinding;
        //gb = pfqe.GetGrid();
        
       // btn.OnPointerUp.AddListener(buttonClick);
    }
    bool placeTower = false;
    private void ButtonClick()
    {
        placeTower = true;
        Debug.Log("clicked!");
    }

    // Update is called once per frame
    void Update()
    {
        if (placeTower && Input.GetMouseButtonDown(0))
        {
            
            /*Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Debug.Log("pathfindingscript!!!!" + pfqe);
            //pfq.pathfinding.GetGrid().GetHeight();
            Vector2Int v = pfq.pathfinding.GetGrid().GetXY(mousePosition);
            Debug.Log("placedToewr");
            Vector3 v2 = pfq.pathfinding.GetGrid().GetWorldPosition(v.x, v.y);
            if (v2.x >= pfq.pathfinding.GetGrid().GetWorldPosition(0, 0).x
                && v2.x <= pfq.pathfinding.GetGrid().GetWorldPosition(pfq.pathfinding.GetGrid().GetWidth(), 0).x
                && v2.y >= pfq.pathfinding.GetGrid().GetWorldPosition(0, 0).y
                && v2.y <= pfq.pathfinding.GetGrid().GetWorldPosition(0, pfq.pathfinding.GetGrid().GetHeight()).y)
            {
                Instantiate(tower, v2, Quaternion.identity);
                placeTower = false;
            }*/
        }
    }
}
