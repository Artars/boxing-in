using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

public class Truck : MonoBehaviour, IInteractable
{
    public bool Visible
    {
        get; protected set;
    }

    public InteractionType InteractionType => InteractionType.EmptyHand;

    public List<int> currentElements = new List<int>();


    public void Appear(List<int> boxes, float expireTime)
    {
        
    }

    public void Disapear()
    {

    }

    public void TryToInteract(CharacterMovement character)
    {
        
    }
}
