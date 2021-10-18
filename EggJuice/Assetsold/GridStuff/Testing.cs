/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Testing : MonoBehaviour
{
    private GridBoy grid;

    private void Start()
    {
        grid = new GridBoy(20, 10, 0.5f, new Vector3(0,0,0));

    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0)) {
            Vector3 worldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            worldPosition.z = 0f;
            grid.SetValue(worldPosition, 56);
            
        }

        if (Input.GetMouseButtonDown(1))
        {
            Vector3 worldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            worldPosition.z = 0f;
            Debug.Log(grid.GetValue(worldPosition));
        }
    }
}*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Testing : MonoBehaviour
{
    public PathFinding pathfinding;

    private void Start()
    {
        pathfinding = new PathFinding(20, 20);
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 mouseWorldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mouseWorldPosition.z = 0f;

            Vector2Int v = pathfinding.GetGrid().GetXY(mouseWorldPosition);
            Debug.Log("path x value: " + v.y);
            List<PathNode> path = pathfinding.FindPath(0, 0, v.x, v.y);
            if (path != null)
            {
                for (int i = 0; i < path.Count - 1; i++)
                {
                    Debug.DrawLine(new Vector3(path[i].x, path[i].y) * 10f + Vector3.one * 5f,
                        new Vector3(path[i + 1].x, path[i + 1].y));
                }
            }
        }
    }
}

