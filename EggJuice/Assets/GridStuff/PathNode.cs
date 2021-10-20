using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathNode
{
    private GridBoy<PathNode> grid;
    public int x;
    public int y;
    // square
    [SerializeField] private GameObject square;
    // occupied
    private bool occupied = false;
    public int gCost;
    public int hCost;
    public int fCost;

    public PathNode cameFromNode;

    public PathNode(GridBoy<PathNode> grid, int x, int y)
    {
        this.grid = grid;
        this.x = x;
        this.y = y;
    }

    public void CalculateFCost()
    {
        fCost = gCost + hCost;
    }

    public void createSquare(Vector3 position)
    {
        // instantiate square to position
        GameObject.Instantiate(square);
    }

    public override string ToString()
    {
        return x + ", " + y;
    }
}
