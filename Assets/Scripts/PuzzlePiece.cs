using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzlePiece : MonoBehaviour
{
    public class Configuration
    {
        public bool[,] validSlot;
        public Vector2Int dimension;
        public Vector2Int pivot;

        public Configuration (bool[] states, Vector2Int dimension, Vector2Int pivot)
        {
            this.dimension = dimension;
            this.pivot = pivot;

            validSlot = new bool[dimension.x,dimension.y];
            int counter = 0;
            for (int x = 0; x < dimension.x; x++)
            {
                for (int y = 0; y < dimension.y; y++)
                {
                    validSlot[x,y] = states[counter];
                    counter++;
                }
            }
        }

        public static Configuration GenerateAnticlockwise(Configuration original)
        {
            Vector2Int flippedSize = new Vector2Int(original.dimension.y, original.dimension.x);
            Configuration result = new Configuration(flippedSize, original.pivot);
            
            int newColumn, newRow = 0;
            for (int oldColumn = original.validSlot.GetLength(1) - 1; oldColumn >= 0; oldColumn--)
            {
                newColumn = 0;
                for (int oldRow = 0; oldRow < original.validSlot.GetLength(0); oldRow++)
                {
                    result.validSlot[newRow, newColumn] = original.validSlot[oldRow, oldColumn];
                    newColumn++;
                }
                newRow++;
            }
            result.pivot = new Vector2Int(original.pivot.y, original.validSlot.GetLength(0) - original.pivot.x);
            return result;
        }
        
        public Configuration(Vector2Int dimension, Vector2Int pivot)
        {
            this.dimension = dimension;
            this.pivot = pivot;

            validSlot = new bool[dimension.x,dimension.y];
        }

    }

    public bool[] space;
    public Vector2Int size;
    public Vector2Int drawPivot;

    protected Configuration[] configurations = new Configuration[4];

    protected int currentConfiguration = 0;

    protected int rotation;


    void Start()
    {
        ConstructArray();
    }

    void ConstructArray()
    {
        configurations[0] = new Configuration(space, size, drawPivot);
        configurations[1] = Configuration.GenerateAnticlockwise(configurations[0]);
        configurations[2] = Configuration.GenerateAnticlockwise(configurations[1]);
        configurations[3] = Configuration.GenerateAnticlockwise(configurations[2]);
    }

    public void RotateClockwise()
    {
        currentConfiguration = currentConfiguration -1;
        if(currentConfiguration < 0)
            currentConfiguration = 3;

        transform.Rotate(Vector3.up * -90);
    }
    
    public void RotateAnticlockwise()
    {
        currentConfiguration = currentConfiguration +1;
        if(currentConfiguration > 3)
            currentConfiguration = 0;

        transform.Rotate(Vector3.up * 90);
    }


    bool GetArray(bool[] array, Vector2Int position, Vector2Int size)
    {
        return array[size.x * position.x + position.y];
    }

    void SetArray(bool[] array, Vector2Int position, Vector2Int size, bool value)
    {
        array[size.x * position.x + position.y] = value;
    }

    public Configuration GetCurrentConfiguration()
    {
        return configurations[currentConfiguration];
    }
}


// public const int[,,] combinations = {
//     //Z
//     {
//         {1,1,0,0,1,1},{0,1,1,1,1,0},{1,1,0,0,1,1},{0,1,1,1,1,0}
//     },
//     //L
//     {
//         {1,0,1,0,1,1}, {1,1,1,1,1,0}, {1,1,0,1,0,1}, {0,0,1,1,1,1}
//     },
//     // I
//     {
//         {1,1,1,1},{1,1,1,1},{1,1,1,1},{1,1,1,1}
//     }
// };

// public const int[,,] sizes = {
//     //Z
//     {
//         {3,2},{2,3},{3,2},{2,3}
//     },
//     // L
//     {
//         {2,3},{3,2},{2,3},{3,2}
//     },
//     //I
//     {
//         {}
//     }
// };