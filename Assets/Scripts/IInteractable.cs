using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IInteractable 
{
    public InteractionType InteractionType
    {
        get;
    }
    public void TryToInteract(CharacterMovement character);
}


public enum InteractionType
{
    EmptyHand, BusyHand, Any
}