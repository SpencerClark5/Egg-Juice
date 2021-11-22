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
using UnityEngine.UI;

public class Testing : MonoBehaviour
{
    //public PathFinding pathfinding;
    public List<GameObject> chickens;
    public List<GameObject> decoys;
    public List<GameObject> eggs;
    public List<GameObject> eggsAndChickens;
    [SerializeField] private GameObject square;
    [SerializeField] private int numChickens;
    [SerializeField] private int numDecoys;
    [SerializeField] private int numEggs;
    [SerializeField] private int numEggsChickens;
    
    public GridBoy<PathNode> grid;
    private const int WIDTH = 48;
    private const int HEIGHT = 20;
    private PathNode[] showingNodes;
    private ArrayList tiles;
    private int numTiles = 0;
    private int size = 0;
    private DragStartScript dragScript;

    private void Start()
    {
        //pathfinding = new PathFinding(20, 20);
        grid = new GridBoy<PathNode>(WIDTH, HEIGHT, 0.5f,
           new Vector3(-12, -5, 0), (GridBoy<PathNode> g, int x, int y)
            => new PathNode(g, x, y));

        for (int i = 0; i < WIDTH; i++)
        {
            for (int j = 0; j < HEIGHT; j++)
            {
                grid.GetValue(i, j).createSquare(grid.GetWorldPosition(i, j), square).setTesting(this);
            }
        }
        tiles = new ArrayList();
    }

    private void Update()
    {
        /*
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
            }
       }*/
    }

    public GridBoy<PathNode> getGrid()
    {
        return grid;
    }

    public int getNumChickens()
    {
        return numChickens;
    }
    // decrements numChickens
    public void destroyChicken()
    {
        numChickens--;
        numEggsChickens--;
    }
    
    public void destroyDecoy()
    {
        numDecoys--;
        //numEggsChickens--;
    }
    
    public void destroyEgg()
    {
        numEggs--;
        numEggsChickens--;
    }

    public void removeEgg(GameObject egg)
    {
        eggs.Remove(egg);
        eggsAndChickens.Remove(egg);
        destroyEgg();
    }

    public void setThings(int size, DragStartScript dragScript)
    {
        this.size = size;
        this.dragScript = dragScript;
    }

    public int addTileToArray(PathNode p)
    {
        //showingNodes[numTiles] = p;
        tiles.Add(p);
        numTiles++;
        return numTiles - 1;
    }

    public void removeTileFromArray(PathNode p)
    {
        tiles.Remove(p);
        numTiles--;
    }

    public void recalculate(Vector3 center)
    {
        dragScript.recalculate(center);
    }

    public void setSquares(Vector3 topLeft, Vector3 topRight, Vector3 bottomLeft, Vector3 bottomRight)
    {
        Debug.Log("topLeft: " + topLeft);
        grid.GetValue(topLeft).showSquare();
        grid.GetValue(topRight).showSquare();
        grid.GetValue(bottomLeft).showSquare();
        grid.GetValue(bottomRight).showSquare();
    }

    public void remakeListArray(int width, int height)
    {
        showingNodes = new PathNode[width * height];
    }

    public void setTilesToOccupied()
    {
        foreach (PathNode p in tiles)
        {
            p.setOccupied();
            p.hideSquare();
        }
        //showingNodes[i].setOccupied();
        //showingNodes[i].hideSquare();
    }
    // returns true if occupied, false otherwise
    public bool checkForOccupied()
    {
        foreach(PathNode p in tiles)
        {
            if (p.getOccupied())
            {
                return true;
            }
        }
        return false;
    }

    public Vector3 getWorldPositionFromGrid(int x, int y)
    {
        return grid.GetWorldPosition(x, y);
    }

    public void addChicken(GameObject chicken)
    {
        chickens.Add(chicken);
        numChickens++;
    }

    public void addDecoy(GameObject decoy)
    {
        decoys.Add(decoy);
        numDecoys++;
    }
    
    public void addEgg(GameObject egg)
    {
        eggs.Add(egg);
        eggsAndChickens.Add(egg);
        numEggs++;
        numEggsChickens++;
    }

    public int getNumDecoys()
    {
        return numDecoys;
    }
    
    public int getNumEggs()
    {
        return numEggs;
    }
    
    public int getEggsAndChickens()
    {
        return numEggs;
    }

    public void removeDecoy(GameObject decoy)
    {
        decoys.Remove(decoy);
        numDecoys--;
    }
}