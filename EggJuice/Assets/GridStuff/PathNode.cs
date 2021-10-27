using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathNode
{
    private GridBoy<PathNode> grid;
    public int x;
    public int y;
    // square
    private GameObject square;
    // occupied
    private bool occupied = false;
    public int gCost;
    public int hCost;
    public int fCost;
    private Color color1 = new Color(0F, 1F, 0F, 1F);
    private Color color2 = new Color(1F, 0F, 0F, 1F);
    private bool visible = false;

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

    public void createSquare(Vector3 position, GameObject nSquare)
    {
        // instantiate square to position
        GameObject obj = GameObject.Instantiate(nSquare, position, Quaternion.identity);
        square = obj;
        swapColor();
        square.SetActive(false);
    }

    public GameObject getSquare()
    {
        return square;
    }

    public void swapColor()
    {
        if (occupied)
        {
            square.transform.GetComponent<SpriteRenderer>().color = color2;
        }
        else
        {
            square.transform.GetComponent<SpriteRenderer>().color = color1;
        }
    }

    public void showSquare()
    {
        if (!visible)
        {
            square.SetActive(true);
            visible = true;
        }
    }
    
    public void hideSquare()
    {
        if (visible)
        {
            square.SetActive(false);
            visible = false;
        }
    }

    public override string ToString()
    {
        return x + ", " + y;
    }
}
