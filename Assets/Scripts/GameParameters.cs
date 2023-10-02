using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="Parameters", menuName ="Game Parameters", order = 1)]
public class GameParameters : ScriptableObject
{
    public string stageName;
    [Multiline]
    public string description;
    public float truckSpawnMin = 30;
    public float truckSpawnMax = 50;
    public int piecesPerTruck = 3;
    public float truckDisapearTime = 20;
    public float fillPorcentage = .6f;
    public float minPoints = 50;
    public float maxPoints = 100;
    public float faultTruck = 80;
    public int maxTrucksFaults = 3;
    public float maxTime = float.PositiveInfinity;
}
