using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridBoy<T>
{
    //public event EventHandler<OnGridObjectChangedEventArgs> OnGridObjectChanged;
    /*public class OnGridObjectChangedEventArgs : EventArgs
    {
        public int x;
        public int y;
    }*/
    private int width;
    private int height;
    private T[,] gridArray;
    private Vector3 originPosition;
    private float cellSize;

    public GridBoy(int width, int height, float cellSize, Vector3 originPosition, Func<GridBoy<T>, int, int, T> createGrid)
    {


        this.width = width;
        this.height = height;
        this.cellSize = cellSize;
        this.originPosition = originPosition;

        gridArray = new T[width, height];

        for (int i = 0; i < gridArray.GetLength(0); i++)
        {
            for (int j = 0; j < gridArray.GetLength(1); j++)
            {
                gridArray[i, j] = createGrid(this, i, j);
                // ignore create world mesh
                Debug.DrawLine(GetWorldPosition(i, j), GetWorldPosition(i, j + 1), Color.white, 100f);
                Debug.DrawLine(GetWorldPosition(i, j), GetWorldPosition(i + 1, j), Color.white, 100f);

            }
        }
        Debug.DrawLine(GetWorldPosition(0, height), GetWorldPosition(width, height), Color.white, 100f);
        Debug.DrawLine(GetWorldPosition(width, 0), GetWorldPosition(width, height), Color.white, 100f);

        //SetValue(2, 1, 56);
    }

    public int GetWidth()
    {
        return width;
    }

    public int GetHeight()
    {
        return height;
    }

    public float GetCellSize()
    {
        return cellSize;
    }

    public Vector3 GetWorldPosition(int x, int y)
    {
            return new Vector3(x, y) * cellSize + originPosition;
    }

    public Vector2Int GetXY(Vector3 worldPosition)
    {
        int x = Mathf.FloorToInt((worldPosition - originPosition).x / cellSize);
        int y = Mathf.FloorToInt((worldPosition - originPosition).y / cellSize);
    //    Debug.Log("xxxxxxxxxxx: " + x);
        return new Vector2Int(x, y);
    }

    public void SetValue(int x, int y, T value)
    {
        if (x >= 0 && y >= 0 && x < width && y < height)
        {
            gridArray[x, y] = value;
            /*if (OnGridObjectChanged != null)
            {
                OnGridObjectChanged(this, new OnGridObjectChangedEventArgs { x = x, y = y });
            }*/
        }
    }

    /*public void TriggerGridObjectChanged(int x, int y)
    {
        if (OnGridObjectChanged != null)
        {
            OnGridObjectChanged(this, new OnGridObjectChangedEventArgs { x = x, y = y });
        }
    }*/

    public void SetValue(Vector3 worldPosition, T value)
    {
        Vector2Int v = GetXY(worldPosition);

        SetValue(v.x, v.y, value);
    }

    public T GetValue(int x, int y)
    {
        if (x >= 0 && y >= 0 && x < width && y < height)
        {
            return gridArray[x, y];
        }
        else
        {
            return default(T);
        }
    }

    public T GetValue(Vector3 worldPosition)
    {
        Vector2Int v = GetXY(worldPosition);
        return GetValue(v.x, v.y);
    }
}
