using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

#if UNITY_EDITOR
using UnityEditor;
#endif

public class TileSystem : MonoBehaviour
{
    public Transform min;
    public Transform max;
    public Vector2Int size;

    public MeshRenderer grid;

    public GameObject[][] busyCells;

    void Start()
    {
        SetSize(size);
    }

    public Transform dTransform;
    public int dX;
    public int dY;
    void Update()
    {
        GetPosition(dTransform.position, out dX, out dY);
    }

    public Vector3 GetScale()
    {
        Vector3 direction = max.position - min.position;
        return new Vector3(direction.x / size.x, 1, direction.z / size.y);;
    }

    public void SetSize(Vector2Int size)
    {
        this.size = size;

        grid.material.SetTextureScale("_BaseMap", size);
        busyCells = new GameObject[size.x][];
        for (int i = 0; i < size.x; i++)
        {
            busyCells[i] = new GameObject[size.y];
        }
    }

    public bool GetPosition(Vector3 position, out int x, out int y)
    {
        Vector3 direction = max.position - min.position;
        Vector3 dif = position - min.position;
        float Xpct = Mathf.InverseLerp(0, direction.x, dif.x);
        float Ypct = Mathf.InverseLerp(0, direction.z, dif.z);

        x = Mathf.FloorToInt(Xpct * size.x);
        y = Mathf.FloorToInt(Ypct * size.y);

        if(x < 0 || x >= size.x || y < 0 || y >= size.y)
            return false;
        return true;
    }

    public Vector3 GetCenterOfCell(int x, int y)
    {
        Vector3 direction = max.position - min.position;
        Vector2 tileSize = new Vector2(direction.x / size.x, direction.z / size.y);
        return min.position + Vector3.right * tileSize.x * (.5f+x) + Vector3.forward * tileSize.y * (.5f+y);
    }

    public GameObject GetCellInFront(Vector3 position, Vector3 direction, out int x, out int y)
    {
        bool found = GetPosition(position, out x, out y);
        direction.Normalize();
        Vector2Int intDirection = new Vector2Int(0,0);
        if(Math.Abs(direction.z) > Math.Abs(direction.x))
        {
            intDirection.y = (int) Mathf.Sign(direction.z);
        }
        else
        {
            intDirection.x = (int) Mathf.Sign(direction.x);
        }
        Vector2Int targetPosition =  new Vector2Int(x,y) + intDirection;
        x = targetPosition.x;
        y = targetPosition.y;

        if(targetPosition.x < 0 || targetPosition.x >= size.x || targetPosition.y < 0 || targetPosition.y >= size.y)
            return null;

        return busyCells[targetPosition.x][targetPosition.y];
    }

    public void SetTile(GameObject gameObject, int x, int y)
    {
        if(x < 0 || x >= size.x || y < 0 || y >= size.y) return;

        busyCells[x][y] = gameObject;

    }

    public GameObject GetTile(int x, int y)
    {
        if(x < 0 || x >= size.x || y < 0 || y >= size.y) return null;
        return busyCells[x][y];
    }

    public bool InsideRange(int x, int y)
    {
        if(x < 0 || x >= size.x || y < 0 || y >= size.y) return false;
        return true;
    }

    /// <summary>
    /// Callback to draw gizmos that are pickable and always drawn.
    /// </summary>
    void OnDrawGizmos()
    {
        Vector3 direction = max.position - min.position;
        Vector3 scale = new Vector3(direction.x / size.x, 5, direction.z / size.y);

        if(busyCells != null)
        {
            for (int i = 0; i < busyCells.Length; i++)
            {
                for (int j = 0; j < busyCells[i].Length; j++)
                {
                    if(busyCells[i][j] != null)
                    {
                        Gizmos.color = Color.red;
                        Gizmos.DrawCube(GetCenterOfCell(i,j), scale);
                    }
                }
            }
        }
    }
}

#if UNITY_EDITOR
[CustomEditor(typeof(TileSystem))]
public class TileEditor : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        TileSystem tile = (TileSystem) target;
        if(tile.busyCells != null)
        {
            GUILayout.BeginVertical();
            for (int i = 0; i < tile.busyCells.Length; i++)
            {
                GUILayout.BeginHorizontal();
                for (int j = 0; j < tile.busyCells[i].Length; j++)
                {
                    GUILayout.Label((tile.busyCells[i][j] == null ? "-" : tile.busyCells[i][j].name.Substring(0,2)));
                }
                GUILayout.EndHorizontal();
            }
            GUILayout.EndVertical();
        }


    }
}
#endif
