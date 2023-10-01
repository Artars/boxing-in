using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnSystem : MonoBehaviour
{
    public int numberOfPieces;
    public GameObject[] prefabs;
    public Truck[] trucks;

    [Header("Properties")]
    public int boxesPerTruck = 3;
    public float minTime = 20;
    public float maxTime = 40;
    public float truckExpireTime = 20;


    protected List<int> randomSequence;

    public int GetNextRandom()
    {
        if(randomSequence.Count == 0)
        {
            GenerateNextSequence();
        }
        int result = randomSequence[0];
        randomSequence.RemoveAt(0);
        return result;
    }

    public void MakeNextTruckAppear()
    {
        List<int> possibleTrucks = new List<int>(); 
        for (int i = 0; i < trucks.Length; i++)
        {
            if(!trucks[i].Visible)
                possibleTrucks.Add(i);
        }

        if(possibleTrucks.Count > 0)
        {
            int nextTruck = possibleTrucks[Random.Range(0,possibleTrucks.Count)];
            SetupTruck(nextTruck);


        }
    }

    protected void SetupTruck(int index)
    {
        List<int> boxes = new List<int>();
        for (int i = 0; i < boxesPerTruck; i++)
        {
            boxes.Add(GetNextRandom());
        }
        trucks[index].Appear(boxes, truckExpireTime);
    }

    protected void GenerateNextSequence()
    {
        for (int i = 0; i < numberOfPieces; i++)
        {
            randomSequence.Add(i);
        }
        Shuffle(randomSequence);
    }

    protected void Shuffle(List<int> list)
    {
        int n = list.Count;  
        while (n > 1) {  
            n--;  
            int k = Random.Range(0,n + 1);  
            int value = list[k];  
            list[k] = list[n];  
            list[n] = value;  
        }  
    }
}
