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
    [SerializeField] private GameObject square;
    private GridBoy<PathNode> grid;
    private const int WIDTH = 20;
    private const int HEIGHT = 20;
    private PathNode[] showingNodes;
    private void Start()
    {
        //pathfinding = new PathFinding(20, 20);
        grid = new GridBoy<PathNode>(WIDTH, HEIGHT, 0.5f,
           new Vector3(-5, -5, 0), (GridBoy<PathNode> g, int x, int y)
            => new PathNode(g, x, y));

        for (int i = 0; i < WIDTH; i++)
        {
            for (int j = 0; j < HEIGHT; j++)
            {
                grid.GetValue(i, j).createSquare(grid.GetWorldPosition(i, j), square);
            }
        }
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 mouseWorldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mouseWorldPosition.z = 0f;
            
            Vector2Int v = grid.GetXY(mouseWorldPosition);
            //Debug.Log("path x value: " + v.y);
            /*List<PathNode> path = pathfinding.FindPath(0, 0, v.x, v.y);
            if (path != null)
            {
                for (int i = 0; i < path.Count - 1; i++)
                {
                    Debug.DrawLine(new Vector3(path[i].x, path[i].y) * 10f + Vector3.one * 5f,
                        new Vector3(path[i + 1].x, path[i + 1].y));
                }
            }*/
        }
    }

    public GridBoy<PathNode> getGrid()
    {
        return grid;
    }

    public void setSquares(Vector3 topLeft, Vector3 topRight, Vector3 bottomLeft, Vector3 bottomRight)
    {
        Debug.Log("topLeft: " + topLeft);
        grid.GetValue(topLeft).showSquare();
        grid.GetValue(topRight).showSquare();
        grid.GetValue(bottomLeft).showSquare();
        grid.GetValue(bottomRight).showSquare();
    }
}

