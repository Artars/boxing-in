using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Box : MonoBehaviour, IInteractable
{
    public enum Pieces
    {
                
    }
    
    public Pieces pieceType;

    public InteractionType InteractionType => InteractionType.EmptyHand;

    public void TryToInteract(CharacterMovement character)
    {
        character.PlayerGrab(gameObject);
    }
}
